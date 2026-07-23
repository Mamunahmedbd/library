using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Library
{
    public partial class BookCategory : Form
    {
        private DataTable dtCategories;

        public BookCategory()
        {
            InitializeComponent();
            LoadCategories();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(74, 50, 34),
                Color.FromArgb(42, 27, 18),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void LoadCategories()
        {
            string query = "SELECT CategoryID, CategoryName, Description FROM BookCategory ORDER BY CategoryID";
            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtCategories = ds.Tables[0];
            else
                dtCategories = new DataTable();

            dataGridView1.DataSource = dtCategories;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text) || string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("CategoryID and CategoryName are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO BookCategory (CategoryID, CategoryName, Description) VALUES ('" +
                txtCategoryID.Text.Trim().Replace("'", "''") + "', '" +
                txtCategoryName.Text.Trim().Replace("'", "''") + "', '" +
                txtDescription.Text.Trim().Replace("'", "''") + "')";

            int n = SQLHelper.ExecuteCmd(query);
            if (n > 0)
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadCategories();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Please select a Category to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE BookCategory SET CategoryName = '" +
                txtCategoryName.Text.Trim().Replace("'", "''") + "', Description = '" +
                txtDescription.Text.Trim().Replace("'", "''") + "' WHERE CategoryID = '" +
                txtCategoryID.Text.Trim().Replace("'", "''") + "'";

            int n = SQLHelper.ExecuteCmd(query);
            if (n > 0)
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Please select a Category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this Category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM BookCategory WHERE CategoryID = '" + txtCategoryID.Text.Trim().Replace("'", "''") + "'";
                int n = SQLHelper.ExecuteCmd(query);
                if (n > 0)
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCategories();
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
                dtCategories.DefaultView.RowFilter = $"CategoryID LIKE '%{term}%' OR CategoryName LIKE '%{term}%'";
            }
        }
    }
}