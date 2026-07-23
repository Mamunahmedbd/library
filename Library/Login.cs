using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbUserName.Focus();
            LoadBannerImage();
            CenterLayout();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CenterLayout();
        }

        private void LoadBannerImage()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] candidatePaths = new string[]
                {
                    System.IO.Path.Combine(baseDir, "Resources", "library_banner.png"),
                    System.IO.Path.Combine(baseDir, "..", "..", "Resources", "library_banner.png"),
                    System.IO.Path.Combine(baseDir, "Resources", "loginBackgroud.jpg")
                };

                foreach (string path in candidatePaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        if (picHero != null)
                        {
                            picHero.Image = Image.FromFile(path);
                        }
                        break;
                    }
                }
            }
            catch
            {
                // Graceful fallback if image load fails
            }
        }

        private void CenterLayout()
        {
            if (panel1 == null) return;

            int left = (this.ClientSize.Width - panel1.Width) / 2;
            int top = (this.ClientSize.Height - panel1.Height) / 2;

            if (left < 15) left = 15;
            if (top < 15) top = 15;

            panel1.Left = left;
            panel1.Top = top;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text.Trim();
            string password = tbPwd.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your Username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPwd.Focus();
                return;
            }

            try
            {
                // Secure parameterized query preventing SQL Injection
                string query = "SELECT AdminID, Username, Password, RealName FROM AdminList WHERE Username = @username";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username)
                };

                DataSet ds = SQLHelper.GetData(query, parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow userRow = ds.Tables[0].Rows[0];
                    string storedPassword = userRow["Password"]?.ToString() ?? "";
                    string adminId = userRow["AdminID"]?.ToString() ?? "";

                    bool isPasswordValid = false;

                    // Check PBKDF2 hashed password
                    if (SecurityHelper.VerifyPassword(password, storedPassword))
                    {
                        isPasswordValid = true;
                    }
                    // Fallback for legacy plaintext password entries
                    else if (password == storedPassword)
                    {
                        isPasswordValid = true;

                        // Auto-upgrade legacy plaintext password to PBKDF2 hash
                        try
                        {
                            string newHash = SecurityHelper.CreateHash(password);
                            string updateSql = "UPDATE AdminList SET Password = @newHash WHERE AdminID = @adminId";
                            SqlParameter[] updateParams = new SqlParameter[]
                            {
                                new SqlParameter("@newHash", newHash),
                                new SqlParameter("@adminId", adminId)
                            };
                            SQLHelper.ExecuteNonQuery(updateSql, updateParams);
                        }
                        catch
                        {
                            // Silent fallback if hash upgrade fails
                        }
                    }

                    if (isPasswordValid)
                    {
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbPwd.Clear();
                        tbPwd.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPwd.Clear();
                    tbUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to the database. Please verify SQL Server service is running.\n\nError: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPwd.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkForgotPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your System Administrator to reset your password.",
                "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminManage adminForm = new AdminManage();
            adminForm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}