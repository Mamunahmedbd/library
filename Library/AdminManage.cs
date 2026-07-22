using System;
using System.Data;
using System.Windows.Forms;

namespace Library
{
    public partial class AdminManage : Form
    {
        private DataTable dtAdmins;

        public AdminManage()
        {
            InitializeComponent();
            LoadAdmins();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                System.Drawing.Color.FromArgb(74, 50, 34),
                System.Drawing.Color.FromArgb(42, 27, 18),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void LoadAdmins()
        {
            string query = @"SELECT * FROM AdminList ORDER BY AdminID";

            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtAdmins = ds.Tables[0];
            else
                dtAdmins = new DataTable();

            dataGridView1.DataSource = dtAdmins;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAdmins();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string insertQuery = string.Format(
                "INSERT INTO AdminList (AdminID, Username, Password, RealName, Phone) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                txtAdminID.Text.Trim(),
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                txtRealName.Text.Trim(),
                txtPhone.Text.Trim());

            int n = SQLHelper.ExecuteCmd(insertQuery);
            if (n > 0)
                MessageBox.Show("Admin added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadAdmins();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = string.Format(
                "UPDATE AdminList SET Username = '{0}', Password = '{1}', RealName = '{2}', Phone = '{3}' WHERE AdminID = '{4}'",
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                txtRealName.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAdminID.Text.Trim());

            int n = SQLHelper.ExecuteCmd(updateQuery);
            if (n > 0)
                MessageBox.Show("Admin updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadAdmins();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this Admin?", "Confirm",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string deleteQuery = string.Format("DELETE FROM AdminList WHERE AdminID = '{0}'",
                                                    txtAdminID.Text.Trim());

                int n = SQLHelper.ExecuteCmd(deleteQuery);
                if (n > 0)
                    MessageBox.Show("Admin deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadAdmins();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows.Count > e.RowIndex)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtAdminID.Text = row.Cells["AdminID"].Value?.ToString() ?? string.Empty;
                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? string.Empty;
                txtPassword.Text = row.Cells["Password"].Value?.ToString() ?? string.Empty;
                txtRealName.Text = row.Cells["RealName"].Value?.ToString() ?? string.Empty;
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
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

            string filter = $"AdminID LIKE '%{term}%' OR Username LIKE '%{term}%' OR RealName LIKE '%{term}%'";
            try
            {
                dtAdmins.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid filter expression: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}