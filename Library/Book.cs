using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Book : Form
    {
        private DataTable dtBooks;
        private DataTable dtCategories;

        public Book()
        {
            InitializeComponent();
            loadBooks();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadBooks();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtBooks != null)
            {
                string filter = "BookID LIKE '%" + this.textBox1.Text + "%' OR BookName LIKE '%" + this.textBox1.Text + "%' OR Author LIKE '%" + this.textBox1.Text + "%'";
                dtBooks.DefaultView.RowFilter = filter;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = string.Format(
                           "UPDATE BookInfo SET BookName = '{0}', CategoryID = '{1}', Publisher = '{2}', Author = '{3}', Price = {4}, PublishDate = '{5}',Introduction='{6}' WHERE BookID = '{7}'",
                           txtBookName.Text.Trim(),
                           cboCategory.SelectedValue?.ToString() ?? "",
                           txtPublisher.Text.Trim(),
                           txtAuthor.Text.Trim(),
                           string.IsNullOrWhiteSpace(txtPrice.Text) ? "0" : txtPrice.Text.Trim(),
                           dtpPublishDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                           txtIntro.Text.Trim(),
                           txtBookID.Text.Trim());
            int n = SQLHelper.ExecuteCmd(updateQuery);
            if (n > 0)
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadBooks();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtBookID.Text = row.Cells["BookID"].Value?.ToString() ?? "";
                txtBookName.Text = row.Cells["BookName"].Value?.ToString() ?? "";
                txtPublisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                cboCategory.SelectedValue = row.Cells["CategoryID"].Value?.ToString() ?? "";
                txtIntro.Text = row.Cells["Introduction"].Value?.ToString() ?? "";
                if (row.Cells["PublishDate"].Value != DBNull.Value && row.Cells["PublishDate"].Value != null)
                {
                    dtpPublishDate.Value = Convert.ToDateTime(row.Cells["PublishDate"].Value);
                }
            }
        }

        private void LoadCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM BookCategory ORDER BY CategoryName";

            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtCategories = ds.Tables[0];
            else
                dtCategories = new DataTable();

            cboCategory.DataSource = dtCategories;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryID";
        }

        private void loadBooks()
        {
            string query = @"SELECT b.*, c.CategoryName 
                            FROM BookInfo b 
                            LEFT JOIN BookCategory c ON b.CategoryID = c.CategoryID
                            ORDER BY b.BookID";

            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtBooks = ds.Tables[0];
            else
                dtBooks = new DataTable();

            dataGridView1.DataSource = dtBooks;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string deleteQuery = string.Format("DELETE FROM BookInfo WHERE BookID = '{0}'",
                                                    txtBookID.Text.Trim());

                int n = SQLHelper.ExecuteCmd(deleteQuery);
                if (n > 0)
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadBooks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string insertQuery = string.Format(
                         "INSERT INTO BookInfo (BookID, BookName, CategoryID, Publisher, Author, Price, PublishDate,Introduction) " +
                         "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}','{7}')",
                         txtBookID.Text.Trim().Replace("'", "''"),
                         txtBookName.Text.Trim().Replace("'", "''"),
                         cboCategory.SelectedValue?.ToString().Replace("'", "''") ?? "",
                         txtPublisher.Text.Trim().Replace("'", "''"),
                         txtAuthor.Text.Trim().Replace("'", "''"),
                         string.IsNullOrWhiteSpace(txtPrice.Text) ? "0" : txtPrice.Text.Trim(),
                         dtpPublishDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                         txtIntro.Text.Trim()
                     );

            int n = SQLHelper.ExecuteCmd(insertQuery);
            if (n > 0)
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadBooks();
        }
    }
}
