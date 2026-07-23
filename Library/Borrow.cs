using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class Borrow : Form
    {
        private DataTable dtBorrows;
        private DataTable dtBooks;
        private DataTable dtReaders;
        private int borrowDays = 30; // Standard 30-day borrow period

        public Borrow()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(250, 246, 238);
            dtpBorrowDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(borrowDays);
            
            loadBorrows();
            LoadAvailableBooks();
            LoadReaders();
        }

        private void loadBorrows()
        {
            try
            {
                string query = @"SELECT b.RecordID, b.BookID, bk.BookName, b.ReaderID, r.ReaderName, 
                                b.BorrowDate, b.DueDate, b.ReturnDate, b.IsReturn, b.Remark
                                FROM BorrowRecord b
                                INNER JOIN BookInfo bk ON b.BookID = bk.BookID
                                INNER JOIN ReaderInfo r ON b.ReaderID = r.ReaderID
                                WHERE b.IsReturn = 'borrowed'
                                ORDER BY b.BorrowDate DESC";

                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtBorrows = ds.Tables[0];
                else
                    dtBorrows = new DataTable();

                this.dgvBorrowHistory.DataSource = dtBorrows;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading active borrow records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableBooks()
        {
            try
            {
                dtpDueDate.Value = dtpBorrowDate.Value.AddDays(borrowDays);

                string query = @"SELECT BookID, (BookID + ' - ' + BookName) AS DisplayTitle
                                FROM BookInfo a
                                WHERE NOT EXISTS (SELECT 1 FROM BorrowRecord b WHERE a.BookID = b.BookID AND b.IsReturn = 'borrowed')
                                ORDER BY BookName";

                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtBooks = ds.Tables[0];
                else
                    dtBooks = new DataTable();

                cboBook.DataSource = dtBooks;
                cboBook.DisplayMember = "DisplayTitle";
                cboBook.ValueMember = "BookID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReaders()
        {
            try
            {
                string query = @"SELECT ReaderID, (ReaderID + ' - ' + ReaderName) AS DisplayName
                                FROM ReaderInfo
                                ORDER BY ReaderName";

                DataSet ds = SQLHelper.GetData(query);
                if (ds != null && ds.Tables.Count > 0)
                    dtReaders = ds.Tables[0];
                else
                    dtReaders = new DataTable();

                cboReader.DataSource = dtReaders;
                cboReader.DisplayMember = "DisplayName";
                cboReader.ValueMember = "ReaderID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading readers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboBook.SelectedValue == null || cboReader.SelectedValue == null)
                {
                    MessageBox.Show("Please select a book and a reader.", "Validation Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string recordId = "L" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string bookId = cboBook.SelectedValue.ToString();
                string readerId = cboReader.SelectedValue.ToString();
                DateTime borrowDate = dtpBorrowDate.Value;
                DateTime dueDate = dtpDueDate.Value;
                string remark = txtRemark.Text.Trim();

                string insertQuery = @"INSERT INTO BorrowRecord (RecordID, BookID, ReaderID, BorrowDate, DueDate, Remark, IsReturn) 
                                      VALUES (@recordId, @bookId, @readerId, @borrowDate, @dueDate, @remark, 'borrowed')";

                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@recordId", recordId),
                    new SqlParameter("@bookId", bookId),
                    new SqlParameter("@readerId", readerId),
                    new SqlParameter("@borrowDate", borrowDate),
                    new SqlParameter("@dueDate", dueDate),
                    new SqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark)
                };

                int n = SQLHelper.ExecuteNonQuery(insertQuery, insertParams);

                if (n > 0)
                {
                    MessageBox.Show($"Book borrowed successfully!\nDue Date: {dueDate.ToShortDateString()}",
                        "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemark.Clear();
                    loadBorrows();
                    LoadAvailableBooks();
                }
                else
                {
                    MessageBox.Show("Borrow transaction failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing borrow transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrowHistory.CurrentRow == null || dgvBorrowHistory.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a borrow record from the table to return.", "Validation Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvBorrowHistory.CurrentRow;
                string recordID = row.Cells["RecordID"].Value?.ToString();

                if (string.IsNullOrEmpty(recordID))
                {
                    MessageBox.Show("Invalid record selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string bookName = row.Cells["BookName"].Value?.ToString() ?? "the book";
                string readerName = row.Cells["ReaderName"].Value?.ToString() ?? "the reader";

                var confirm = MessageBox.Show($"Confirm return of '{bookName}' from '{readerName}'?", "Confirm Return",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string query = "UPDATE BorrowRecord SET IsReturn = 'returned', ReturnDate = GETDATE() WHERE RecordID = @id";
                    SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@id", recordID) };
                    int n = SQLHelper.ExecuteNonQuery(query, pms);

                    if (n > 0)
                    {
                        MessageBox.Show("Book returned successfully to inventory!", "Return Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadBorrows();
                        LoadAvailableBooks();
                    }
                    else
                    {
                        MessageBox.Show("Return transaction failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing return: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            dtpDueDate.Value = dtpBorrowDate.Value.AddDays(borrowDays);
        }

        private void dgvBorrowHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Grid cell click selection handled automatically via DataGridView CurrentRow
        }
    }
}