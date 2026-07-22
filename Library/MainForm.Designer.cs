namespace Library
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button tsBtnCatrgoryManage;
        private System.Windows.Forms.Button tsBtnBookManage;
        private System.Windows.Forms.Button tsBtnReaderManage;
        private System.Windows.Forms.Button tsBtnBorrowManage;
        private System.Windows.Forms.Button tsBtnUser;
        private System.Windows.Forms.Button tsBtnExit;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.tsBtnCatrgoryManage = new System.Windows.Forms.Button();
            this.tsBtnBookManage = new System.Windows.Forms.Button();
            this.tsBtnReaderManage = new System.Windows.Forms.Button();
            this.tsBtnBorrowManage = new System.Windows.Forms.Button();
            this.tsBtnUser = new System.Windows.Forms.Button();
            this.tsBtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(217, 174, 109);
            this.lblTitle.Location = new System.Drawing.Point(60, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Library Dashboard";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.lblSubtitle.Location = new System.Drawing.Point(64, 95);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(300, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Choose a section to manage";

            this.tsBtnCatrgoryManage.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.tsBtnCatrgoryManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnCatrgoryManage.FlatAppearance.BorderSize = 0;
            this.tsBtnCatrgoryManage.ForeColor = System.Drawing.Color.White;
            this.tsBtnCatrgoryManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsBtnCatrgoryManage.Location = new System.Drawing.Point(60, 150);
            this.tsBtnCatrgoryManage.Name = "tsBtnCatrgoryManage";
            this.tsBtnCatrgoryManage.Size = new System.Drawing.Size(320, 60);
            this.tsBtnCatrgoryManage.TabIndex = 2;
            this.tsBtnCatrgoryManage.Text = "Book Category Management";
            this.tsBtnCatrgoryManage.UseVisualStyleBackColor = false;
            this.tsBtnCatrgoryManage.Click += new System.EventHandler(this.tsBtnCatrgoryManage_Click);

            this.tsBtnBookManage.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.tsBtnBookManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnBookManage.FlatAppearance.BorderSize = 0;
            this.tsBtnBookManage.ForeColor = System.Drawing.Color.White;
            this.tsBtnBookManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsBtnBookManage.Location = new System.Drawing.Point(60, 226);
            this.tsBtnBookManage.Name = "tsBtnBookManage";
            this.tsBtnBookManage.Size = new System.Drawing.Size(320, 60);
            this.tsBtnBookManage.TabIndex = 3;
            this.tsBtnBookManage.Text = "Book Management";
            this.tsBtnBookManage.UseVisualStyleBackColor = false;
            this.tsBtnBookManage.Click += new System.EventHandler(this.tsBtnBookManage_Click); this.tsBtnReaderManage.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.tsBtnReaderManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnReaderManage.FlatAppearance.BorderSize = 0;
            this.tsBtnReaderManage.ForeColor = System.Drawing.Color.White;
            this.tsBtnReaderManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsBtnReaderManage.Location = new System.Drawing.Point(60, 302);
            this.tsBtnReaderManage.Name = "tsBtnReaderManage";
            this.tsBtnReaderManage.Size = new System.Drawing.Size(320, 60);
            this.tsBtnReaderManage.TabIndex = 4;
            this.tsBtnReaderManage.Text = "Reader Management";
            this.tsBtnReaderManage.UseVisualStyleBackColor = false;
            this.tsBtnReaderManage.Click += new System.EventHandler(this.tsBtnReaderManage_Click);

            this.tsBtnBorrowManage.BackColor = System.Drawing.Color.FromArgb(217, 174, 109);
            this.tsBtnBorrowManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnBorrowManage.FlatAppearance.BorderSize = 0;
            this.tsBtnBorrowManage.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.tsBtnBorrowManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsBtnBorrowManage.Location = new System.Drawing.Point(420, 150);
            this.tsBtnBorrowManage.Name = "tsBtnBorrowManage";
            this.tsBtnBorrowManage.Size = new System.Drawing.Size(320, 60);
            this.tsBtnBorrowManage.TabIndex = 5;
            this.tsBtnBorrowManage.Text = "Borrow / Return Books";
            this.tsBtnBorrowManage.UseVisualStyleBackColor = false;
            this.tsBtnBorrowManage.Click += new System.EventHandler(this.tsBtnBorrowManage_Click);

            this.tsBtnUser.BackColor = System.Drawing.Color.FromArgb(122, 46, 46);
            this.tsBtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnUser.FlatAppearance.BorderSize = 0;
            this.tsBtnUser.ForeColor = System.Drawing.Color.White;
            this.tsBtnUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsBtnUser.Location = new System.Drawing.Point(420, 226);
            this.tsBtnUser.Name = "tsBtnUser";
            this.tsBtnUser.Size = new System.Drawing.Size(320, 60);
            this.tsBtnUser.TabIndex = 6;
            this.tsBtnUser.Text = "Admin / User Management";
            this.tsBtnUser.UseVisualStyleBackColor = false;
            this.tsBtnUser.Click += new System.EventHandler(this.tsBtnUser_Click);

            this.tsBtnExit.BackColor = System.Drawing.Color.FromArgb(122, 46, 46);
            this.tsBtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnExit.FlatAppearance.BorderSize = 0;
            this.tsBtnExit.ForeColor = System.Drawing.Color.White;
            this.tsBtnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsBtnExit.Location = new System.Drawing.Point(420, 302);
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(320, 60);
            this.tsBtnExit.TabIndex = 7;
            this.tsBtnExit.Text = "Exit";
            this.tsBtnExit.UseVisualStyleBackColor = false;
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(62, 42, 30);
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.tsBtnCatrgoryManage);
            this.Controls.Add(this.tsBtnBookManage);
            this.Controls.Add(this.tsBtnReaderManage);
            this.Controls.Add(this.tsBtnBorrowManage);
            this.Controls.Add(this.tsBtnUser);
            this.Controls.Add(this.tsBtnExit);
            this.Name = "MainForm";
            this.Text = "Library Management System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}