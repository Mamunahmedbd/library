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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.pnlSidebarDivider = new System.Windows.Forms.Panel();
            this.btnDashboardNav = new System.Windows.Forms.Button();
            this.tsBtnCatrgoryManage = new System.Windows.Forms.Button();
            this.tsBtnBookManage = new System.Windows.Forms.Button();
            this.tsBtnReaderManage = new System.Windows.Forms.Button();
            this.tsBtnBorrowManage = new System.Windows.Forms.Button();
            this.tsBtnUser = new System.Windows.Forms.Button();
            this.tsBtnExit = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlDashboardOverview = new System.Windows.Forms.Panel();
            this.cardBooks = new System.Windows.Forms.Panel();
            this.lblBooksIcon = new System.Windows.Forms.Label();
            this.lblBooksVal = new System.Windows.Forms.Label();
            this.lblBooksTitle = new System.Windows.Forms.Label();
            this.cardBorrows = new System.Windows.Forms.Panel();
            this.lblBorrowIcon = new System.Windows.Forms.Label();
            this.lblBorrowVal = new System.Windows.Forms.Label();
            this.lblBorrowTitle = new System.Windows.Forms.Label();
            this.cardReaders = new System.Windows.Forms.Panel();
            this.lblReadersIcon = new System.Windows.Forms.Label();
            this.lblReadersVal = new System.Windows.Forms.Label();
            this.lblReadersTitle = new System.Windows.Forms.Label();
            this.cardCategories = new System.Windows.Forms.Panel();
            this.lblCatIcon = new System.Windows.Forms.Label();
            this.lblCatVal = new System.Windows.Forms.Label();
            this.lblCatTitle = new System.Windows.Forms.Label();
            this.pnlRecentActivity = new System.Windows.Forms.Panel();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlDashboardOverview.SuspendLayout();
            this.cardBooks.SuspendLayout();
            this.cardBorrows.SuspendLayout();
            this.cardReaders.SuspendLayout();
            this.cardCategories.SuspendLayout();
            this.pnlRecentActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(28)))), ((int)(((byte)(21)))));
            this.pnlSidebar.Controls.Add(this.lblBrandTitle);
            this.pnlSidebar.Controls.Add(this.lblBrandSub);
            this.pnlSidebar.Controls.Add(this.pnlSidebarDivider);
            this.pnlSidebar.Controls.Add(this.btnDashboardNav);
            this.pnlSidebar.Controls.Add(this.tsBtnCatrgoryManage);
            this.pnlSidebar.Controls.Add(this.tsBtnBookManage);
            this.pnlSidebar.Controls.Add(this.tsBtnReaderManage);
            this.pnlSidebar.Controls.Add(this.tsBtnBorrowManage);
            this.pnlSidebar.Controls.Add(this.tsBtnUser);
            this.pnlSidebar.Controls.Add(this.tsBtnExit);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 720);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.AutoSize = true;
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblBrandTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(174)))), ((int)(((byte)(109)))));
            this.lblBrandTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(215, 30);
            this.lblBrandTitle.TabIndex = 0;
            this.lblBrandTitle.Text = "UNIVERSITY LIBRARY";
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(139)))), ((int)(((byte)(122)))));
            this.lblBrandSub.Location = new System.Drawing.Point(22, 48);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(168, 20);
            this.lblBrandSub.TabIndex = 1;
            this.lblBrandSub.Text = "Lab Management System";
            // 
            // pnlSidebarDivider
            // 
            this.pnlSidebarDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(34)))));
            this.pnlSidebarDivider.Location = new System.Drawing.Point(20, 78);
            this.pnlSidebarDivider.Name = "pnlSidebarDivider";
            this.pnlSidebarDivider.Size = new System.Drawing.Size(220, 1);
            this.pnlSidebarDivider.TabIndex = 2;
            // 
            // btnDashboardNav
            // 
            this.btnDashboardNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(59)))));
            this.btnDashboardNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboardNav.FlatAppearance.BorderSize = 0;
            this.btnDashboardNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboardNav.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDashboardNav.ForeColor = System.Drawing.Color.White;
            this.btnDashboardNav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboardNav.Location = new System.Drawing.Point(15, 95);
            this.btnDashboardNav.Name = "btnDashboardNav";
            this.btnDashboardNav.Size = new System.Drawing.Size(230, 46);
            this.btnDashboardNav.TabIndex = 3;
            this.btnDashboardNav.Text = " 📊   Dashboard";
            this.btnDashboardNav.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboardNav.UseVisualStyleBackColor = false;
            this.btnDashboardNav.Click += new System.EventHandler(this.btnDashboardNav_Click);
            // 
            // tsBtnCatrgoryManage
            // 
            this.tsBtnCatrgoryManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(28)))), ((int)(((byte)(21)))));
            this.tsBtnCatrgoryManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsBtnCatrgoryManage.FlatAppearance.BorderSize = 0;
            this.tsBtnCatrgoryManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnCatrgoryManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsBtnCatrgoryManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(170)))));
            this.tsBtnCatrgoryManage.Location = new System.Drawing.Point(15, 150);
            this.tsBtnCatrgoryManage.Name = "tsBtnCatrgoryManage";
            this.tsBtnCatrgoryManage.Size = new System.Drawing.Size(230, 46);
            this.tsBtnCatrgoryManage.TabIndex = 4;
            this.tsBtnCatrgoryManage.Text = " 📚   Book Categories";
            this.tsBtnCatrgoryManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnCatrgoryManage.UseVisualStyleBackColor = false;
            this.tsBtnCatrgoryManage.Click += new System.EventHandler(this.tsBtnCatrgoryManage_Click);
            // 
            // tsBtnBookManage
            // 
            this.tsBtnBookManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(28)))), ((int)(((byte)(21)))));
            this.tsBtnBookManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsBtnBookManage.FlatAppearance.BorderSize = 0;
            this.tsBtnBookManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnBookManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsBtnBookManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(170)))));
            this.tsBtnBookManage.Location = new System.Drawing.Point(15, 205);
            this.tsBtnBookManage.Name = "tsBtnBookManage";
            this.tsBtnBookManage.Size = new System.Drawing.Size(230, 46);
            this.tsBtnBookManage.TabIndex = 5;
            this.tsBtnBookManage.Text = " 📖   Book Inventory";
            this.tsBtnBookManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnBookManage.UseVisualStyleBackColor = false;
            this.tsBtnBookManage.Click += new System.EventHandler(this.tsBtnBookManage_Click);
            // 
            // tsBtnReaderManage
            // 
            this.tsBtnReaderManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(28)))), ((int)(((byte)(21)))));
            this.tsBtnReaderManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsBtnReaderManage.FlatAppearance.BorderSize = 0;
            this.tsBtnReaderManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnReaderManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsBtnReaderManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(170)))));
            this.tsBtnReaderManage.Location = new System.Drawing.Point(15, 260);
            this.tsBtnReaderManage.Name = "tsBtnReaderManage";
            this.tsBtnReaderManage.Size = new System.Drawing.Size(230, 46);
            this.tsBtnReaderManage.TabIndex = 6;
            this.tsBtnReaderManage.Text = " 👥   Reader Directory";
            this.tsBtnReaderManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnReaderManage.UseVisualStyleBackColor = false;
            this.tsBtnReaderManage.Click += new System.EventHandler(this.tsBtnReaderManage_Click);
            // 
            // tsBtnBorrowManage
            // 
            this.tsBtnBorrowManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(28)))), ((int)(((byte)(21)))));
            this.tsBtnBorrowManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsBtnBorrowManage.FlatAppearance.BorderSize = 0;
            this.tsBtnBorrowManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnBorrowManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsBtnBorrowManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(170)))));
            this.tsBtnBorrowManage.Location = new System.Drawing.Point(15, 315);
            this.tsBtnBorrowManage.Name = "tsBtnBorrowManage";
            this.tsBtnBorrowManage.Size = new System.Drawing.Size(230, 46);
            this.tsBtnBorrowManage.TabIndex = 7;
            this.tsBtnBorrowManage.Text = " 🔄   Borrow && Return";
            this.tsBtnBorrowManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnBorrowManage.UseVisualStyleBackColor = false;
            this.tsBtnBorrowManage.Click += new System.EventHandler(this.tsBtnBorrowManage_Click);
            // 
            // tsBtnUser
            // 
            this.tsBtnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(28)))), ((int)(((byte)(21)))));
            this.tsBtnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsBtnUser.FlatAppearance.BorderSize = 0;
            this.tsBtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsBtnUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(170)))));
            this.tsBtnUser.Location = new System.Drawing.Point(15, 370);
            this.tsBtnUser.Name = "tsBtnUser";
            this.tsBtnUser.Size = new System.Drawing.Size(230, 46);
            this.tsBtnUser.TabIndex = 8;
            this.tsBtnUser.Text = " ⚙️   Admin && Users";
            this.tsBtnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnUser.UseVisualStyleBackColor = false;
            this.tsBtnUser.Click += new System.EventHandler(this.tsBtnUser_Click);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tsBtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.tsBtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsBtnExit.FlatAppearance.BorderSize = 0;
            this.tsBtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsBtnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsBtnExit.ForeColor = System.Drawing.Color.White;
            this.tsBtnExit.Location = new System.Drawing.Point(15, 650);
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(230, 44);
            this.tsBtnExit.TabIndex = 9;
            this.tsBtnExit.Text = " 🚪   Exit Application";
            this.tsBtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnExit.UseVisualStyleBackColor = false;
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(34)))), ((int)(((byte)(25)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(260, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(920, 65);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(238)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(25, 18);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(400, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "System Dashboard Overview";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(174)))), ((int)(((byte)(109)))));
            this.lblUserInfo.Location = new System.Drawing.Point(620, 22);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(275, 21);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "👤 System Administrator | DB: library";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(238)))));
            this.pnlMainContent.Controls.Add(this.pnlDashboardOverview);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(260, 65);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(920, 655);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pnlDashboardOverview
            // 
            this.pnlDashboardOverview.Controls.Add(this.cardBooks);
            this.pnlDashboardOverview.Controls.Add(this.cardBorrows);
            this.pnlDashboardOverview.Controls.Add(this.cardReaders);
            this.pnlDashboardOverview.Controls.Add(this.cardCategories);
            this.pnlDashboardOverview.Controls.Add(this.pnlRecentActivity);
            this.pnlDashboardOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboardOverview.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboardOverview.Name = "pnlDashboardOverview";
            this.pnlDashboardOverview.Size = new System.Drawing.Size(920, 655);
            this.pnlDashboardOverview.TabIndex = 0;
            // 
            // cardBooks
            // 
            this.cardBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(249)))));
            this.cardBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardBooks.Controls.Add(this.lblBooksIcon);
            this.cardBooks.Controls.Add(this.lblBooksVal);
            this.cardBooks.Controls.Add(this.lblBooksTitle);
            this.cardBooks.Location = new System.Drawing.Point(25, 25);
            this.cardBooks.Name = "cardBooks";
            this.cardBooks.Size = new System.Drawing.Size(200, 105);
            this.cardBooks.TabIndex = 0;
            // 
            // lblBooksIcon
            // 
            this.lblBooksIcon.AutoSize = true;
            this.lblBooksIcon.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblBooksIcon.Location = new System.Drawing.Point(135, 25);
            this.lblBooksIcon.Name = "lblBooksIcon";
            this.lblBooksIcon.Size = new System.Drawing.Size(62, 50);
            this.lblBooksIcon.TabIndex = 2;
            this.lblBooksIcon.Text = "📖";
            // 
            // lblBooksVal
            // 
            this.lblBooksVal.AutoSize = true;
            this.lblBooksVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBooksVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(59)))));
            this.lblBooksVal.Location = new System.Drawing.Point(15, 42);
            this.lblBooksVal.Name = "lblBooksVal";
            this.lblBooksVal.Size = new System.Drawing.Size(39, 46);
            this.lblBooksVal.TabIndex = 1;
            this.lblBooksVal.Text = "0";
            // 
            // lblBooksTitle
            // 
            this.lblBooksTitle.AutoSize = true;
            this.lblBooksTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBooksTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(102)))), ((int)(((byte)(88)))));
            this.lblBooksTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBooksTitle.Name = "lblBooksTitle";
            this.lblBooksTitle.Size = new System.Drawing.Size(102, 20);
            this.lblBooksTitle.TabIndex = 0;
            this.lblBooksTitle.Text = "TOTAL BOOKS";
            // 
            // cardBorrows
            // 
            this.cardBorrows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(249)))));
            this.cardBorrows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardBorrows.Controls.Add(this.lblBorrowIcon);
            this.cardBorrows.Controls.Add(this.lblBorrowVal);
            this.cardBorrows.Controls.Add(this.lblBorrowTitle);
            this.cardBorrows.Location = new System.Drawing.Point(245, 25);
            this.cardBorrows.Name = "cardBorrows";
            this.cardBorrows.Size = new System.Drawing.Size(200, 105);
            this.cardBorrows.TabIndex = 1;
            // 
            // lblBorrowIcon
            // 
            this.lblBorrowIcon.AutoSize = true;
            this.lblBorrowIcon.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblBorrowIcon.Location = new System.Drawing.Point(135, 25);
            this.lblBorrowIcon.Name = "lblBorrowIcon";
            this.lblBorrowIcon.Size = new System.Drawing.Size(62, 50);
            this.lblBorrowIcon.TabIndex = 2;
            this.lblBorrowIcon.Text = "🔄";
            // 
            // lblBorrowVal
            // 
            this.lblBorrowVal.AutoSize = true;
            this.lblBorrowVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBorrowVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(59)))));
            this.lblBorrowVal.Location = new System.Drawing.Point(15, 42);
            this.lblBorrowVal.Name = "lblBorrowVal";
            this.lblBorrowVal.Size = new System.Drawing.Size(39, 46);
            this.lblBorrowVal.TabIndex = 1;
            this.lblBorrowVal.Text = "0";
            // 
            // lblBorrowTitle
            // 
            this.lblBorrowTitle.AutoSize = true;
            this.lblBorrowTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBorrowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(102)))), ((int)(((byte)(88)))));
            this.lblBorrowTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBorrowTitle.Name = "lblBorrowTitle";
            this.lblBorrowTitle.Size = new System.Drawing.Size(126, 20);
            this.lblBorrowTitle.TabIndex = 0;
            this.lblBorrowTitle.Text = "ACTIVE BORROWS";
            // 
            // cardReaders
            // 
            this.cardReaders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(249)))));
            this.cardReaders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardReaders.Controls.Add(this.lblReadersIcon);
            this.cardReaders.Controls.Add(this.lblReadersVal);
            this.cardReaders.Controls.Add(this.lblReadersTitle);
            this.cardReaders.Location = new System.Drawing.Point(465, 25);
            this.cardReaders.Name = "cardReaders";
            this.cardReaders.Size = new System.Drawing.Size(200, 105);
            this.cardReaders.TabIndex = 2;
            // 
            // lblReadersIcon
            // 
            this.lblReadersIcon.AutoSize = true;
            this.lblReadersIcon.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblReadersIcon.Location = new System.Drawing.Point(135, 25);
            this.lblReadersIcon.Name = "lblReadersIcon";
            this.lblReadersIcon.Size = new System.Drawing.Size(62, 50);
            this.lblReadersIcon.TabIndex = 2;
            this.lblReadersIcon.Text = "👥";
            // 
            // lblReadersVal
            // 
            this.lblReadersVal.AutoSize = true;
            this.lblReadersVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblReadersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(59)))));
            this.lblReadersVal.Location = new System.Drawing.Point(15, 42);
            this.lblReadersVal.Name = "lblReadersVal";
            this.lblReadersVal.Size = new System.Drawing.Size(39, 46);
            this.lblReadersVal.TabIndex = 1;
            this.lblReadersVal.Text = "0";
            // 
            // lblReadersTitle
            // 
            this.lblReadersTitle.AutoSize = true;
            this.lblReadersTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblReadersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(102)))), ((int)(((byte)(88)))));
            this.lblReadersTitle.Location = new System.Drawing.Point(15, 15);
            this.lblReadersTitle.Name = "lblReadersTitle";
            this.lblReadersTitle.Size = new System.Drawing.Size(120, 20);
            this.lblReadersTitle.TabIndex = 0;
            this.lblReadersTitle.Text = "TOTAL READERS";
            // 
            // cardCategories
            // 
            this.cardCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(249)))));
            this.cardCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardCategories.Controls.Add(this.lblCatIcon);
            this.cardCategories.Controls.Add(this.lblCatVal);
            this.cardCategories.Controls.Add(this.lblCatTitle);
            this.cardCategories.Location = new System.Drawing.Point(685, 25);
            this.cardCategories.Name = "cardCategories";
            this.cardCategories.Size = new System.Drawing.Size(200, 105);
            this.cardCategories.TabIndex = 3;
            // 
            // lblCatIcon
            // 
            this.lblCatIcon.AutoSize = true;
            this.lblCatIcon.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblCatIcon.Location = new System.Drawing.Point(135, 25);
            this.lblCatIcon.Name = "lblCatIcon";
            this.lblCatIcon.Size = new System.Drawing.Size(62, 50);
            this.lblCatIcon.TabIndex = 2;
            this.lblCatIcon.Text = "📚";
            // 
            // lblCatVal
            // 
            this.lblCatVal.AutoSize = true;
            this.lblCatVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCatVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(59)))));
            this.lblCatVal.Location = new System.Drawing.Point(15, 42);
            this.lblCatVal.Name = "lblCatVal";
            this.lblCatVal.Size = new System.Drawing.Size(39, 46);
            this.lblCatVal.TabIndex = 1;
            this.lblCatVal.Text = "0";
            // 
            // lblCatTitle
            // 
            this.lblCatTitle.AutoSize = true;
            this.lblCatTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCatTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(102)))), ((int)(((byte)(88)))));
            this.lblCatTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCatTitle.Name = "lblCatTitle";
            this.lblCatTitle.Size = new System.Drawing.Size(96, 20);
            this.lblCatTitle.TabIndex = 0;
            this.lblCatTitle.Text = "CATEGORIES";
            // 
            // pnlRecentActivity
            // 
            this.pnlRecentActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRecentActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(249)))));
            this.pnlRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecentActivity.Controls.Add(this.dgvRecent);
            this.pnlRecentActivity.Controls.Add(this.lblRecentTitle);
            this.pnlRecentActivity.Location = new System.Drawing.Point(25, 150);
            this.pnlRecentActivity.Name = "pnlRecentActivity";
            this.pnlRecentActivity.Size = new System.Drawing.Size(860, 475);
            this.pnlRecentActivity.TabIndex = 4;
            // 
            // dgvRecent
            // 
            this.dgvRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(238)))));
            this.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(27)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecent.EnableHeadersVisualStyles = false;
            this.dgvRecent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(214)))), ((int)(((byte)(197)))));
            this.dgvRecent.Location = new System.Drawing.Point(15, 55);
            this.dgvRecent.Name = "dgvRecent";
            this.dgvRecent.RowHeadersWidth = 51;
            this.dgvRecent.RowTemplate.Height = 28;
            this.dgvRecent.Size = new System.Drawing.Size(828, 400);
            this.dgvRecent.TabIndex = 1;
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(39)))), ((int)(((byte)(26)))));
            this.lblRecentTitle.Location = new System.Drawing.Point(15, 16);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(360, 27);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "Recent Circulation Activity Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "University Library Management System - Portal Dashboard";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlDashboardOverview.ResumeLayout(false);
            this.cardBooks.ResumeLayout(false);
            this.cardBooks.PerformLayout();
            this.cardBorrows.ResumeLayout(false);
            this.cardBorrows.PerformLayout();
            this.cardReaders.ResumeLayout(false);
            this.cardReaders.PerformLayout();
            this.cardCategories.ResumeLayout(false);
            this.cardCategories.PerformLayout();
            this.pnlRecentActivity.ResumeLayout(false);
            this.pnlRecentActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel pnlSidebarDivider;
        private System.Windows.Forms.Button btnDashboardNav;
        private System.Windows.Forms.Button tsBtnCatrgoryManage;
        private System.Windows.Forms.Button tsBtnBookManage;
        private System.Windows.Forms.Button tsBtnReaderManage;
        private System.Windows.Forms.Button tsBtnBorrowManage;
        private System.Windows.Forms.Button tsBtnUser;
        private System.Windows.Forms.Button tsBtnExit;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlDashboardOverview;
        private System.Windows.Forms.Panel cardBooks;
        private System.Windows.Forms.Label lblBooksIcon;
        private System.Windows.Forms.Label lblBooksVal;
        private System.Windows.Forms.Label lblBooksTitle;
        private System.Windows.Forms.Panel cardBorrows;
        private System.Windows.Forms.Label lblBorrowIcon;
        private System.Windows.Forms.Label lblBorrowVal;
        private System.Windows.Forms.Label lblBorrowTitle;
        private System.Windows.Forms.Panel cardReaders;
        private System.Windows.Forms.Label lblReadersIcon;
        private System.Windows.Forms.Label lblReadersVal;
        private System.Windows.Forms.Label lblReadersTitle;
        private System.Windows.Forms.Panel cardCategories;
        private System.Windows.Forms.Label lblCatIcon;
        private System.Windows.Forms.Label lblCatVal;
        private System.Windows.Forms.Label lblCatTitle;
        private System.Windows.Forms.Panel pnlRecentActivity;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvRecent;
    }
}