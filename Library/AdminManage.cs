using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class AdminManage : Form
    {
        private DataTable dtAdmins;

        public AdminManage()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(250, 246, 238);
            LoadAdmins();
        }

        private void LoadAdmins()
        {
            try
            {
                string query = "SELECT AdminID, Username, RealName, Phone FROM AdminList ORDER BY AdminID";
                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtAdmins = ds.Tables[0];
                else
                    dtAdmins = new DataTable();

                dataGridView1.DataSource = dtAdmins;

                if (string.IsNullOrWhiteSpace(txtAdminID.Text))
                {
                    txtAdminID.Text = GenerateNextAdminID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admins: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateNextAdminID()
        {
            try
            {
                string sql = "SELECT TOP 1 AdminID FROM AdminList WHERE AdminID LIKE 'A%' ORDER BY LEN(AdminID) DESC, AdminID DESC";
                object val = SQLHelper.ExecuteScalar(sql);
                if (val != null && !string.IsNullOrEmpty(val.ToString()))
                {
                    string currentNum = val.ToString().Substring(1);
                    if (int.TryParse(currentNum, out int num))
                    {
                        return $"A{(num + 1):D3}";
                    }
                }
            }
            catch { }
            return "A001";
        }

        private void ClearInputs()
        {
            txtAdminID.Text = GenerateNextAdminID();
            txtUsername.Clear();
            txtPassword.Clear();
            txtRealName.Clear();
            txtPhone.Clear();
            txtUsername.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadAdmins();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string adminId = txtAdminID.Text.Trim();
            string username = txtUsername.Text.Trim();
            string rawPassword = txtPassword.Text;
            string realName = txtRealName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(adminId) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(rawPassword))
            {
                MessageBox.Show("Admin ID, Username, and Password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Securely hash password using PBKDF2
                string hashedPassword = SecurityHelper.CreateHash(rawPassword);

                string query = @"INSERT INTO AdminList (AdminID, Username, Password, RealName, Phone) 
                                VALUES (@adminId, @username, @pwd, @realName, @phone)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@adminId", adminId),
                    new SqlParameter("@username", username),
                    new SqlParameter("@pwd", hashedPassword),
                    new SqlParameter("@realName", (object)realName ?? DBNull.Value),
                    new SqlParameter("@phone", (object)phone ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Admin account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadAdmins();
                }
                else
                {
                    MessageBox.Show("Failed to create admin account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string adminId = txtAdminID.Text.Trim();
            string username = txtUsername.Text.Trim();
            string rawPassword = txtPassword.Text;
            string realName = txtRealName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(adminId))
            {
                MessageBox.Show("Please select an Admin account to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query;
                SqlParameter[] parameters;

                // Update with new hashed password if password field is provided
                if (!string.IsNullOrWhiteSpace(rawPassword))
                {
                    string hashedPassword = SecurityHelper.CreateHash(rawPassword);
                    query = @"UPDATE AdminList SET Username = @username, Password = @pwd, 
                             RealName = @realName, Phone = @phone WHERE AdminID = @adminId";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@adminId", adminId),
                        new SqlParameter("@username", username),
                        new SqlParameter("@pwd", hashedPassword),
                        new SqlParameter("@realName", (object)realName ?? DBNull.Value),
                        new SqlParameter("@phone", (object)phone ?? DBNull.Value)
                    };
                }
                else
                {
                    query = @"UPDATE AdminList SET Username = @username, 
                             RealName = @realName, Phone = @phone WHERE AdminID = @adminId";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@adminId", adminId),
                        new SqlParameter("@username", username),
                        new SqlParameter("@realName", (object)realName ?? DBNull.Value),
                        new SqlParameter("@phone", (object)phone ?? DBNull.Value)
                    };
                }

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Admin account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadAdmins();
                }
                else
                {
                    MessageBox.Show("No admin account updated. Check Admin ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string adminId = txtAdminID.Text.Trim();
            if (string.IsNullOrWhiteSpace(adminId))
            {
                MessageBox.Show("Please select an Admin to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete Admin account '{adminId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM AdminList WHERE AdminID = @adminId";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@adminId", adminId) };
                    int n = SQLHelper.ExecuteNonQuery(query, parameters);
                    if (n > 0)
                    {
                        MessageBox.Show("Admin account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        LoadAdmins();
                    }
                    else
                    {
                        MessageBox.Show("No admin account deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtAdminID.Text = row.Cells["AdminID"].Value?.ToString() ?? "";
                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtPassword.Clear(); // Clear password input for security
                txtRealName.Text = row.Cells["RealName"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            }
        }

        private static string EscapeForRowFilter(string s) => s?.Replace("'", "''") ?? string.Empty;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtAdmins == null) return;

            string term = EscapeForRowFilter(this.textBoxSearch.Text);
            if (string.IsNullOrEmpty(term))
            {
                dtAdmins.DefaultView.RowFilter = string.Empty;
                return;
            }

            string filter = $"AdminID LIKE '%{term}%' OR Username LIKE '%{term}%' OR RealName LIKE '%{term}%' OR Phone LIKE '%{term}%'";
            try
            {
                dtAdmins.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filter error: {ex.Message}", "Filter Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}