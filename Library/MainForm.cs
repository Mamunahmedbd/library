using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsBtnCatrgoryManage_Click(object sender, EventArgs e)
        {
            BookCategory bookCategory = new BookCategory();
            bookCategory.ShowDialog();
        }

        private void tsBtnBookManage_Click(object sender, EventArgs e)
        { 
           Book book = new Book();  
            book.ShowDialog();

        }

        private void tsBtnReaderManage_Click(object sender, EventArgs e)
        {
            Reader reader = new Reader();
            reader.ShowDialog();
        }

        private void tsBtnBorrowManage_Click(object sender, EventArgs e)
        {
            Borrow borrow = new Borrow();
            borrow.ShowDialog();
        }

        private void tsBtnUser_Click(object sender, EventArgs e)
        {
            AdminManage adminManage = new AdminManage();    
            adminManage.ShowDialog();   
        }
    }
}
