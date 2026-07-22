namespace Library
{
    partial class Borrow
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

        private void InitializeComponent()
        {
            this.dgvBorrowHistory = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.cboReader = new System.Windows.Forms.ComboBox();
            this.lblReader = new System.Windows.Forms.Label();
            this.cboBook = new System.Windows.Forms.ComboBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowHistory)).BeginInit();
            this.SuspendLayout();
            this.dgvBorrowHistory.AllowUserToAddRows = false;
            this.dgvBorrowHistory.AllowUserToDeleteRows = false;
            this.dgvBorrowHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowHistory.BackgroundColor = System.Drawing.Color.FromArgb(250, 241, 221);
            this.dgvBorrowHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBorrowHistory.GridColor = System.Drawing.Color.FromArgb(216, 200, 160);
            this.dgvBorrowHistory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(122, 46, 46);
            this.dgvBorrowHistory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBorrowHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvBorrowHistory.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 241, 221);
            this.dgvBorrowHistory.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.dgvBorrowHistory.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.dgvBorrowHistory.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBorrowHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowHistory.Location = new System.Drawing.Point(24, 234);
            this.dgvBorrowHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBorrowHistory.Name = "dgvBorrowHistory";
            this.dgvBorrowHistory.ReadOnly = true;
            this.dgvBorrowHistory.RowHeadersWidth = 51;
            this.dgvBorrowHistory.Size = new System.Drawing.Size(748, 184);
            this.dgvBorrowHistory.TabIndex = 20;
            this.dgvBorrowHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrowHistory_CellClick);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(122, 46, 46);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(294, 177);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnBorrow.BackColor = System.Drawing.Color.FromArgb(184, 134, 59);
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.FlatAppearance.BorderSize = 0;
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBorrow.Location = new System.Drawing.Point(100, 177);
            this.btnBorrow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(75, 24);
            this.btnBorrow.TabIndex = 18;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48);
            this.lblBorrowDate.Location = new System.Drawing.Point(40, 106);
            this.lblBorrowDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(77, 12);
            this.lblBorrowDate.TabIndex = 17;
            this.lblBorrowDate.Text = "Borrow Date:";
            this.dtpBorrowDate.Location = new System.Drawing.Point(122, 101);
            this.dtpBorrowDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(125, 21);
            this.dtpBorrowDate.TabIndex = 16;
            this.dtpBorrowDate.Value = new System.DateTime(2026, 7, 8, 23, 52, 5, 423);
            this.cboReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReader.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.cboReader.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.cboReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboReader.Location = new System.Drawing.Point(100, 69);
            this.cboReader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboReader.Name = "cboReader";
            this.cboReader.Size = new System.Drawing.Size(430, 20);
            this.cboReader.TabIndex = 15;
            this.lblReader.AutoSize = true;
            this.lblReader.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48);
            this.lblReader.Location = new System.Drawing.Point(40, 71);
            this.lblReader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(47, 12);
            this.lblReader.TabIndex = 14;
            this.lblReader.Text = "Reader:";
            this.cboBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBook.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.cboBook.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.cboBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBook.Location = new System.Drawing.Point(100, 41);
            this.cboBook.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboBook.Name = "cboBook";
            this.cboBook.Size = new System.Drawing.Size(430, 20);
            this.cboBook.TabIndex = 13;
            this.lblBook.AutoSize = true;
            this.lblBook.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48);
            this.lblBook.Location = new System.Drawing.Point(40, 41);
            this.lblBook.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(35, 12);
            this.lblBook.TabIndex = 12;
            this.lblBook.Text = "Book:";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.lblTitle.Location = new System.Drawing.Point(20, 7);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(222, 24);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Borrow or Return Book";
            this.dtpDueDate.Location = new System.Drawing.Point(391, 98);
            this.dtpDueDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(139, 21);
            this.dtpDueDate.TabIndex = 16;
            this.dtpDueDate.Value = new System.DateTime(2026, 7, 8, 23, 52, 5, 423);
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48);
            this.label1.Location = new System.Drawing.Point(327, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Due Date:";
            this.txtRemark.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.txtRemark.Location = new System.Drawing.Point(100, 137);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(430, 21);
            this.txtRemark.TabIndex = 21;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48);
            this.label2.Location = new System.Drawing.Point(40, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Remark:";
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(217, 174, 109);
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(43, 27, 18);
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReturn.Location = new System.Drawing.Point(200, 177);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 24);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(62, 42, 30);
            this.ClientSize = new System.Drawing.Size(790, 440);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.dgvBorrowHistory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.cboReader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblReader);
            this.Controls.Add(this.cboBook);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Borrow";
            this.Text = "Borrow";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataGridView dgvBorrowHistory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.ComboBox cboReader;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.ComboBox cboBook;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReturn;
    }
}