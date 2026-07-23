namespace Library
{
    partial class AdminManage
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlRule;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label labelAdminID;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRealName;
        private System.Windows.Forms.Label labelPhone;

        private System.Windows.Forms.TextBox txtAdminID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.TextBox txtPhone;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlRule = new System.Windows.Forms.Panel();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelAdminID = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelRealName = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.txtAdminID = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(217, 174, 109);
            this.lblHeader.Location = new System.Drawing.Point(24, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(280, 32);
            this.lblHeader.TabIndex = 100;
            this.lblHeader.Text = "Admin Management";

            this.pnlRule.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.pnlRule.Location = new System.Drawing.Point(26, 54);
            this.pnlRule.Name = "pnlRule";
            this.pnlRule.Size = new System.Drawing.Size(120, 3);
            this.pnlRule.TabIndex = 101;

            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.labelSearch.Location = new System.Drawing.Point(24, 70);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(79, 15);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Text = "Search By";
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.textBoxSearch.Location = new System.Drawing.Point(120, 67);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 25);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(250, 241, 221);
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(216, 200, 160);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(122, 46, 46);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 241, 221);
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(680, 240);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.labelAdminID.AutoSize = true;
            this.labelAdminID.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.labelAdminID.Location = new System.Drawing.Point(24, 370);
            this.labelAdminID.Name = "labelAdminID";
            this.labelAdminID.Size = new System.Drawing.Size(71, 15);
            this.labelAdminID.TabIndex = 3;
            this.labelAdminID.Text = "AdminID:";
            this.labelUsername.AutoSize = true;
            this.labelUsername.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.labelUsername.Location = new System.Drawing.Point(24, 410);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(79, 15);
            this.labelUsername.TabIndex = 5;
            this.labelUsername.Text = "Username:";
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.labelPassword.Location = new System.Drawing.Point(24, 450);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(79, 15);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password:";
            this.labelRealName.AutoSize = true;
            this.labelRealName.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.labelRealName.Location = new System.Drawing.Point(340, 370);
            this.labelRealName.Name = "labelRealName";
            this.labelRealName.Size = new System.Drawing.Size(87, 15);
            this.labelRealName.TabIndex = 9;
            this.labelRealName.Text = "Real Name:";
            this.labelPhone.AutoSize = true;
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(217, 200, 170);
            this.labelPhone.Location = new System.Drawing.Point(340, 410);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(55, 15);
            this.labelPhone.TabIndex = 11;
            this.labelPhone.Text = "Phone:"; this.txtAdminID.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtAdminID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAdminID.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.txtAdminID.Location = new System.Drawing.Point(110, 366);
            this.txtAdminID.Name = "txtAdminID";
            this.txtAdminID.Size = new System.Drawing.Size(200, 25);
            this.txtAdminID.TabIndex = 4;
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.txtUsername.Location = new System.Drawing.Point(110, 407);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 25);
            this.txtUsername.TabIndex = 6;
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.txtPassword.Location = new System.Drawing.Point(110, 447);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 25);
            this.txtPassword.TabIndex = 8;
            this.txtRealName.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtRealName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRealName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRealName.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.txtRealName.Location = new System.Drawing.Point(440, 366);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(200, 25);
            this.txtRealName.TabIndex = 10;
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.txtPhone.Location = new System.Drawing.Point(440, 407);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 25);
            this.txtPhone.TabIndex = 12;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(760, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(760, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(217, 174, 109);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(760, 206);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(122, 46, 46);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(760, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(62, 42, 30);
            this.ClientSize = new System.Drawing.Size(905, 595);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pnlRule);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.labelRealName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.txtAdminID);
            this.Controls.Add(this.labelAdminID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Name = "AdminManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin & User Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}