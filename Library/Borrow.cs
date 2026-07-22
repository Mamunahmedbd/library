using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Borrow : Form
    {
        private DataTable dtBorrows;
        private DataTable dtBooks;
        private DataTable dtReaders;
        private int borrowDays = 30; // Default borrow days, can be adjusted based on category

        public Borrow()
        {
            InitializeComponent();
            loadBorrows();
            LoadAvailableBooks();
            LoadReaders();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboBook.SelectedValue == null || cboReader.SelectedValue == null)
                {
                    MessageBox.Show("Please select a book and a reader!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string recordId = "L" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string bookId = cboBook.SelectedValue.ToString();
                string readerId = cboReader.SelectedValue.ToString();
                string borrowDate = dtpBorrowDate.Value.ToString("yyyy-MM-dd");
                string dueDate = dtpDueDate.Value.ToString("yyyy-MM-dd");
                string remark = txtRemark.Text.Trim() ?? "";

                // Insert borrow record
                string insertQuery = @"INSERT INTO BorrowRecord (RecordID, BookID, ReaderID, BorrowDate,DueDate, Remark,IsReturn) 
                                      VALUES (@recordId, @bookId, @readerId, @borrowDate,@dueDate,@remark,@isReturn)";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@recordId", recordId),
                    new SqlParameter("@bookId", bookId),
                    new SqlParameter("@readerId", readerId),
                    new SqlParameter("@borrowDate", borrowDate),
                    new SqlParameter("@dueDate", dueDate),
                    new SqlParameter("@remark",  (object)remark ?? DBNull.Value),
                    new SqlParameter("@isReturn","borrowed")
                };

                int n = SQLHelper.ExecuteNonQuery(insertQuery, insertParams);

                if (n > 0)
                    MessageBox.Show($"Book borrowed successfully!\nDue date: {dtpBorrowDate.Value.AddDays(borrowDays).ToShortDateString()}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No book borrowed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadBorrows();
                LoadAvailableBooks();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadBorrows()
        {
            string query = @"SELECT b.RecordID, b.BookID, bk.BookName, b.ReaderID, r.ReaderName, 
                            b.BorrowDate,b.DueDate, b.ReturnDate, b.IsReturn,b.Remark
                            FROM BorrowRecord b,BookInfo bk, ReaderInfo r
                            WHERE b.BookID = bk.BookID
                                    AND b.ReaderID = r.ReaderID
                                    AND b.IsReturn = 'borrowed'
                            ORDER BY b.BorrowDate";
            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtBorrows = ds.Tables[0];
            else
                dtBorrows = new DataTable();

            this.dgvBorrowHistory.DataSource = dtBorrows;
        }

        private void LoadAvailableBooks()
        {
            dtpDueDate.Value = dtpBorrowDate.Value.AddDays(borrowDays);
            // load books
            string query = @"SELECT BookID,BookName
                    FROM BookInfo a
                    WHERE NOT EXISTS (SELECT 1 FROM BorrowRecord b WHERE a.BookID=b.BookID and IsReturn='borrowed')
                    ORDER BY BookName";

            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtBooks = ds.Tables[0];
            else
                dtBooks = new DataTable();

            cboBook.DataSource = dtBooks;
            cboBook.DisplayMember = "BookName";
            cboBook.ValueMember = "BookID";
        }
        private void LoadReaders()
        {
            // load readers
            string query1 = @" SELECT ReaderID,ReaderName
                FROM ReaderInfo
                ORDER BY ReaderName";

            DataSet ds1 = SQLHelper.GetData(query1);
            if (ds1 != null && ds1.Tables.Count > 0)
                dtReaders = ds1.Tables[0];
            else
                dtReaders = new DataTable();

            cboReader.DataSource = dtReaders;
            cboReader.DisplayMember = "ReaderName";
            cboReader.ValueMember = "ReaderID";

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selected < 0 || selected >= dtBorrows.Rows.Count)
            {
                MessageBox.Show("Please select a borrow record to return.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {   //取选中行
                DataGridViewRow row = this.dgvBorrowHistory.Rows[selected];

                string recordID = row.Cells["RecordID"].Value.ToString();
                string query = "UPDATE BorrowRecord SET IsReturn='returned', ReturnDate=GETDATE() WHERE RecordID=@id";
                SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@id", recordID) };
                int n = SQLHelper.ExecuteNonQuery(query, pms);
                if (n > 0)
                {
                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBorrows();
                    LoadAvailableBooks();
                }
                else
                {
                    MessageBox.Show("No book returned.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private int selected = -1;
        private void dgvBorrowHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = e.RowIndex;
        }
    }
}