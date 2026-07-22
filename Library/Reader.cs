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
    public partial class Reader : Form
    {
        private DataTable dtReaders;
        public Reader()
        {
            InitializeComponent();
            loadReaders();
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
        private void loadReaders()
        {
            string query = @"SELECT b.*
                            FROM readerInfo b                           
                            ORDER BY b.ReaderID";


            DataSet ds = SQLHelper.GetData(query);
            if (ds != null && ds.Tables.Count > 0)
                dtReaders = ds.Tables[0];
            else
                dtReaders = new DataTable();

            dataGridView1.DataSource = dtReaders;
        
        }

        private void Reader_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadReaders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this reader?", "Confirm",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string deleteQuery = string.Format("DELETE FROM ReaderInfo WHERE ReaderID = '{0}'",
                                                    txtReaderID.Text.Trim());

                int n = SQLHelper.ExecuteCmd(deleteQuery);
                if (n > 0)
                    MessageBox.Show("Reader deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadReaders();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string insertQuery = string.Format(
                       "INSERT INTO ReaderInfo (ReaderID, ReaderName, Gender, Phone, Address) " +
                       "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                       txtReaderID.Text.Trim(),
                       txtReaderName.Text.Trim(),
                       this.comboBox1.SelectedItem.ToString(),
                       txtPhone.Text.Trim().Replace("'", "''"),
                       txtAddress.Text.Trim().Replace("'", "''")                       
                   );

            int n = SQLHelper.ExecuteCmd(insertQuery);
            if (n > 0)
                MessageBox.Show("Reader added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadReaders();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = string.Format(
                          "UPDATE ReaderInfo SET ReaderName = '{0}', Gender = '{1}', Phone = '{2}', Address = '{3}' WHERE ReaderID = '{4}'",
                       txtReaderName.Text.Trim(),
                       this.comboBox1.SelectedItem.ToString(),
                       txtPhone.Text.Trim().Replace("'", "''"),
                       txtAddress.Text.Trim().Replace("'", "''"),
                       txtReaderID.Text.Trim());
            int n = SQLHelper.ExecuteCmd(updateQuery);
            if (n > 0)
                MessageBox.Show("Reader updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No rows affected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadReaders();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtReaderID.Text = row.Cells["ReaderID"].Value.ToString();
                txtReaderName.Text = row.Cells["ReaderName"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["Gender"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtReaders != null)
            {
                string filter = "ReaderID LIKE '%" + this.textBox1.Text + "%' OR ReaderName LIKE '%" + this.textBox1.Text + "%' OR Gender LIKE '%" + this.textBox1.Text + "%'";
                dtReaders.DefaultView.RowFilter = filter;
            }
        }
    }
}
