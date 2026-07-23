using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class Reader : Form
    {
        private DataTable dtReaders;

        public Reader()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(250, 246, 238);
            loadReaders();
        }

        private void Reader_Load(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0 && comboBox1.SelectedIndex < 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void loadReaders()
        {
            try
            {
                string query = "SELECT ReaderID, ReaderName, Gender, Phone, Address FROM ReaderInfo ORDER BY ReaderID";
                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtReaders = ds.Tables[0];
                else
                    dtReaders = new DataTable();

                dataGridView1.DataSource = dtReaders;

                if (string.IsNullOrWhiteSpace(txtReaderID.Text))
                {
                    txtReaderID.Text = GenerateNextReaderID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading readers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateNextReaderID()
        {
            try
            {
                string sql = "SELECT TOP 1 ReaderID FROM ReaderInfo WHERE ReaderID LIKE 'R%' ORDER BY LEN(ReaderID) DESC, ReaderID DESC";
                object val = SQLHelper.ExecuteScalar(sql);
                if (val != null && !string.IsNullOrEmpty(val.ToString()))
                {
                    string currentNum = val.ToString().Substring(1);
                    if (int.TryParse(currentNum, out int num))
                    {
                        return $"R{(num + 1):D3}";
                    }
                }
            }
            catch { }
            return "R001";
        }

        private void ClearInputs()
        {
            txtReaderID.Text = GenerateNextReaderID();
            txtReaderName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            txtReaderName.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            loadReaders();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string readerId = txtReaderID.Text.Trim();
            string readerName = txtReaderName.Text.Trim();
            string gender = comboBox1.SelectedItem?.ToString() ?? "Male";
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(readerId) || string.IsNullOrWhiteSpace(readerName))
            {
                MessageBox.Show("Reader ID and Reader Name are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO ReaderInfo (ReaderID, ReaderName, Gender, Phone, Address) 
                                VALUES (@readerId, @readerName, @gender, @phone, @address)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@readerId", readerId),
                    new SqlParameter("@readerName", readerName),
                    new SqlParameter("@gender", (object)gender ?? DBNull.Value),
                    new SqlParameter("@phone", (object)phone ?? DBNull.Value),
                    new SqlParameter("@address", (object)address ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Reader added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    loadReaders();
                }
                else
                {
                    MessageBox.Show("Failed to add reader.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding reader: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string readerId = txtReaderID.Text.Trim();
            string readerName = txtReaderName.Text.Trim();
            string gender = comboBox1.SelectedItem?.ToString() ?? "Male";
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(readerId))
            {
                MessageBox.Show("Please select a Reader to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE ReaderInfo SET ReaderName = @readerName, Gender = @gender, 
                                Phone = @phone, Address = @address WHERE ReaderID = @readerId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@readerId", readerId),
                    new SqlParameter("@readerName", readerName),
                    new SqlParameter("@gender", (object)gender ?? DBNull.Value),
                    new SqlParameter("@phone", (object)phone ?? DBNull.Value),
                    new SqlParameter("@address", (object)address ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Reader updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    loadReaders();
                }
                else
                {
                    MessageBox.Show("No reader was updated. Check Reader ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reader: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string readerId = txtReaderID.Text.Trim();
            if (string.IsNullOrWhiteSpace(readerId))
            {
                MessageBox.Show("Please select a Reader to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete Reader '{readerId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM ReaderInfo WHERE ReaderID = @readerId";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@readerId", readerId) };
                    int n = SQLHelper.ExecuteNonQuery(query, parameters);
                    if (n > 0)
                    {
                        MessageBox.Show("Reader deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        loadReaders();
                    }
                    else
                    {
                        MessageBox.Show("No reader was deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting reader: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtReaderID.Text = row.Cells["ReaderID"].Value?.ToString() ?? "";
                txtReaderName.Text = row.Cells["ReaderName"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";

                string g = row.Cells["Gender"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(g))
                {
                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        if (comboBox1.Items[i].ToString().Equals(g, StringComparison.OrdinalIgnoreCase))
                        {
                            comboBox1.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtReaders != null)
            {
                string term = textBox1.Text.Trim().Replace("'", "''");
                dtReaders.DefaultView.RowFilter = $"ReaderID LIKE '%{term}%' OR ReaderName LIKE '%{term}%' OR Phone LIKE '%{term}%' OR Address LIKE '%{term}%' OR Gender LIKE '%{term}%'";
            }
        }
    }
}
