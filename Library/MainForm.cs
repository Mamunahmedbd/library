using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class MainForm : Form
    {
        private Form activeChildForm = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowDashboardView();
        }

        private void ShowDashboardView()
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
                activeChildForm = null;
            }

            pnlDashboardOverview.Visible = true;
            lblHeaderTitle.Text = "System Dashboard Overview";
            HighlightNavButton(btnDashboardNav);
            LoadDashboardStats();
            LoadRecentActivity();
        }

        private void OpenChildForm(Form childForm, Button navButton, string title)
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
            }

            pnlDashboardOverview.Visible = false;

            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(childForm);
            pnlMainContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblHeaderTitle.Text = title;
            HighlightNavButton(navButton);
        }

        private void HighlightNavButton(Button activeButton)
        {
            Button[] navButtons = new Button[]
            {
                btnDashboardNav, tsBtnCatrgoryManage, tsBtnBookManage,
                tsBtnReaderManage, tsBtnBorrowManage, tsBtnUser
            };

            foreach (Button btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(184, 134, 59); // Warm Gold Accent
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(37, 28, 21); // Dark Sidebar
                    btn.ForeColor = Color.FromArgb(217, 200, 170);
                    btn.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                }
            }
        }

        private void LoadDashboardStats()
        {
            try
            {
                object books = SQLHelper.ExecuteScalar("SELECT COUNT(*) FROM BookInfo");
                object borrows = SQLHelper.ExecuteScalar("SELECT COUNT(*) FROM BorrowRecord WHERE IsReturn = 'borrowed'");
                object readers = SQLHelper.ExecuteScalar("SELECT COUNT(*) FROM ReaderInfo");
                object cats = SQLHelper.ExecuteScalar("SELECT COUNT(*) FROM BookCategory");

                lblBooksVal.Text = books != null ? books.ToString() : "0";
                lblBorrowVal.Text = borrows != null ? borrows.ToString() : "0";
                lblReadersVal.Text = readers != null ? readers.ToString() : "0";
                lblCatVal.Text = cats != null ? cats.ToString() : "0";
            }
            catch
            {
                // Graceful fallback
            }
        }

        private void LoadRecentActivity()
        {
            try
            {
                string sql = "SELECT TOP 10 RecordID, BookID, ReaderID, BorrowDate, DueDate, IsReturn FROM BorrowRecord ORDER BY BorrowDate DESC";
                DataSet ds = SQLHelper.GetData(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvRecent.DataSource = ds.Tables[0];
                }
            }
            catch
            {
                // Graceful fallback
            }
        }

        private void btnDashboardNav_Click(object sender, EventArgs e)
        {
            ShowDashboardView();
        }

        private void tsBtnCatrgoryManage_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BookCategory(), tsBtnCatrgoryManage, "Book Category Management");
        }

        private void tsBtnBookManage_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Book(), tsBtnBookManage, "Book Inventory Management");
        }

        private void tsBtnReaderManage_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reader(), tsBtnReaderManage, "Reader Directory Management");
        }

        private void tsBtnBorrowManage_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Borrow(), tsBtnBorrowManage, "Borrow & Return Management");
        }

        private void tsBtnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AdminManage(), tsBtnUser, "Admin & User Accounts");
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
