using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class BookCategory : Form
    {
        private DataTable dtCategories;

        public BookCategory()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(250, 246, 238);
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                string query = "SELECT CategoryID, CategoryName, Description FROM BookCategory ORDER BY CategoryID";
                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtCategories = ds.Tables[0];
                else
                    dtCategories = new DataTable();

                dataGridView1.DataSource = dtCategories;
                
                // Auto-suggest next ID if ID box is empty
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
                {
                    txtCategoryID.Text = GenerateNextCategoryID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateNextCategoryID()
        {
            try
            {
                string sql = "SELECT TOP 1 CategoryID FROM BookCategory WHERE CategoryID LIKE 'C%' ORDER BY LEN(CategoryID) DESC, CategoryID DESC";
                object val = SQLHelper.ExecuteScalar(sql);
                if (val != null && !string.IsNullOrEmpty(val.ToString()))
                {
                    string currentNum = val.ToString().Substring(1);
                    if (int.TryParse(currentNum, out int num))
                    {
                        return $"C{(num + 1):D3}";
                    }
                }
            }
            catch { }
            return "C001";
        }

        private void ClearInputs()
        {
            txtCategoryID.Text = GenerateNextCategoryID();
            txtCategoryName.Clear();
            txtDescription.Clear();
            txtCategoryName.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string catId = txtCategoryID.Text.Trim();
            string catName = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(catId) || string.IsNullOrWhiteSpace(catName))
            {
                MessageBox.Show("Category ID and Category Name are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO BookCategory (CategoryID, CategoryName, Description) VALUES (@id, @name, @desc)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", catId),
                    new SqlParameter("@name", catName),
                    new SqlParameter("@desc", (object)desc ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string catId = txtCategoryID.Text.Trim();
            string catName = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(catId))
            {
                MessageBox.Show("Please select a Category to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE BookCategory SET CategoryName = @name, Description = @desc WHERE CategoryID = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", catId),
                    new SqlParameter("@name", catName),
                    new SqlParameter("@desc", (object)desc ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("No rows updated. Please check the Category ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string catId = txtCategoryID.Text.Trim();
            if (string.IsNullOrWhiteSpace(catId))
            {
                MessageBox.Show("Please select a Category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete Category '{catId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM BookCategory WHERE CategoryID = @id";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", catId) };
                    int n = SQLHelper.ExecuteNonQuery(query, parameters);
                    if (n > 0)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show("No category was deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCategoryID.Text = row.Cells["CategoryID"].Value?.ToString() ?? "";
                txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtCategories != null)
            {
                string term = textBox1.Text.Trim().Replace("'", "''");
                dtCategories.DefaultView.RowFilter = $"CategoryID LIKE '%{term}%' OR CategoryName LIKE '%{term}%' OR Description LIKE '%{term}%'";
            }
        }
    }
}