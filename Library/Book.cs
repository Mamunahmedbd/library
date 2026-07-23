using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            this.BackColor = Color.FromArgb(250, 246, 238);
            LoadCategories();
            loadBooks();
        }

        private void LoadCategories()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadBooks()
        {
            try
            {
                string query = @"SELECT b.BookID, b.BookName, b.CategoryID, c.CategoryName, b.Publisher, b.Author, b.Price, b.PublishDate, b.Introduction 
                                FROM BookInfo b 
                                LEFT JOIN BookCategory c ON b.CategoryID = c.CategoryID
                                ORDER BY b.BookID";

                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtBooks = ds.Tables[0];
                else
                    dtBooks = new DataTable();

                dataGridView1.DataSource = dtBooks;

                if (string.IsNullOrWhiteSpace(txtBookID.Text))
                {
                    txtBookID.Text = GenerateNextBookID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateNextBookID()
        {
            try
            {
                string sql = "SELECT TOP 1 BookID FROM BookInfo WHERE BookID LIKE 'B%' ORDER BY LEN(BookID) DESC, BookID DESC";
                object val = SQLHelper.ExecuteScalar(sql);
                if (val != null && !string.IsNullOrEmpty(val.ToString()))
                {
                    string currentNum = val.ToString().Substring(1);
                    if (int.TryParse(currentNum, out int num))
                    {
                        return $"B{(num + 1):D3}";
                    }
                }
            }
            catch { }
            return "B001";
        }

        private void ClearInputs()
        {
            txtBookID.Text = GenerateNextBookID();
            txtBookName.Clear();
            txtPublisher.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            txtIntro.Clear();
            dtpPublishDate.Value = DateTime.Now;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            txtBookName.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadCategories();
            loadBooks();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string bookId = txtBookID.Text.Trim();
            string bookName = txtBookName.Text.Trim();
            string categoryId = cboCategory.SelectedValue?.ToString() ?? "";
            string publisher = txtPublisher.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string intro = txtIntro.Text.Trim();

            if (string.IsNullOrWhiteSpace(bookId) || string.IsNullOrWhiteSpace(bookName))
            {
                MessageBox.Show("Book ID and Book Name are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                price = 0;
            }

            try
            {
                string query = @"INSERT INTO BookInfo (BookID, BookName, CategoryID, Publisher, Author, Price, PublishDate, Introduction) 
                                VALUES (@bookId, @bookName, @catId, @publisher, @author, @price, @publishDate, @intro)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@bookId", bookId),
                    new SqlParameter("@bookName", bookName),
                    new SqlParameter("@catId", string.IsNullOrEmpty(categoryId) ? DBNull.Value : (object)categoryId),
                    new SqlParameter("@publisher", (object)publisher ?? DBNull.Value),
                    new SqlParameter("@author", (object)author ?? DBNull.Value),
                    new SqlParameter("@price", price),
                    new SqlParameter("@publishDate", dtpPublishDate.Value),
                    new SqlParameter("@intro", (object)intro ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    loadBooks();
                }
                else
                {
                    MessageBox.Show("Failed to add book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string bookId = txtBookID.Text.Trim();
            string bookName = txtBookName.Text.Trim();
            string categoryId = cboCategory.SelectedValue?.ToString() ?? "";
            string publisher = txtPublisher.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string intro = txtIntro.Text.Trim();

            if (string.IsNullOrWhiteSpace(bookId))
            {
                MessageBox.Show("Please select a Book to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                price = 0;
            }

            try
            {
                string query = @"UPDATE BookInfo SET BookName = @bookName, CategoryID = @catId, Publisher = @publisher, 
                                Author = @author, Price = @price, PublishDate = @publishDate, Introduction = @intro 
                                WHERE BookID = @bookId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@bookId", bookId),
                    new SqlParameter("@bookName", bookName),
                    new SqlParameter("@catId", string.IsNullOrEmpty(categoryId) ? DBNull.Value : (object)categoryId),
                    new SqlParameter("@publisher", (object)publisher ?? DBNull.Value),
                    new SqlParameter("@author", (object)author ?? DBNull.Value),
                    new SqlParameter("@price", price),
                    new SqlParameter("@publishDate", dtpPublishDate.Value),
                    new SqlParameter("@intro", (object)intro ?? DBNull.Value)
                };

                int n = SQLHelper.ExecuteNonQuery(query, parameters);
                if (n > 0)
                {
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    loadBooks();
                }
                else
                {
                    MessageBox.Show("No book was updated. Check Book ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string bookId = txtBookID.Text.Trim();
            if (string.IsNullOrWhiteSpace(bookId))
            {
                MessageBox.Show("Please select a Book to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete Book '{bookId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM BookInfo WHERE BookID = @bookId";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@bookId", bookId) };
                    int n = SQLHelper.ExecuteNonQuery(query, parameters);
                    if (n > 0)
                    {
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        loadBooks();
                    }
                    else
                    {
                        MessageBox.Show("No book was deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtBookID.Text = row.Cells["BookID"].Value?.ToString() ?? "";
                txtBookName.Text = row.Cells["BookName"].Value?.ToString() ?? "";
                txtPublisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txtIntro.Text = row.Cells["Introduction"].Value?.ToString() ?? "";

                if (row.Cells["CategoryID"].Value != null)
                {
                    cboCategory.SelectedValue = row.Cells["CategoryID"].Value.ToString();
                }

                if (row.Cells["PublishDate"].Value != null && row.Cells["PublishDate"].Value != DBNull.Value)
                {
                    if (DateTime.TryParse(row.Cells["PublishDate"].Value.ToString(), out DateTime pubDate))
                    {
                        dtpPublishDate.Value = pubDate;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtBooks != null)
            {
                string term = textBox1.Text.Trim().Replace("'", "''");
                dtBooks.DefaultView.RowFilter = $"BookID LIKE '%{term}%' OR BookName LIKE '%{term}%' OR Author LIKE '%{term}%' OR Publisher LIKE '%{term}%' OR CategoryName LIKE '%{term}%'";
            }
        }
    }
}
