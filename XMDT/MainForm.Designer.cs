﻿namespace XMDT
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataInput = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.addProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.config = new System.Windows.Forms.ToolStripMenuItem();
            this.configXMDT = new System.Windows.Forms.ToolStripMenuItem();
            this.dgViewInput = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTwoFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSelectAll = new System.Windows.Forms.ToolStripTextBox();
            this.cmsSelectHightlight = new System.Windows.Forms.ToolStripTextBox();
            this.cmsUnselectedAll = new System.Windows.Forms.ToolStripTextBox();
            this.cmsFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCheckPoint282 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCheckPoint956 = new System.Windows.Forms.ToolStripTextBox();
            this.cmsCheckStatusAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFile = new System.Windows.Forms.ComboBox();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbLoginCookie = new System.Windows.Forms.RadioButton();
            this.rbLoginUP = new System.Windows.Forms.RadioButton();
            this.cmsCP282MBasic = new System.Windows.Forms.ToolStripTextBox();
            this.cmsCP282M = new System.Windows.Forms.ToolStripTextBox();
            this.cmsCP282 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewInput)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataInput,
            this.config});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataInput
            // 
            this.dataInput.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccount,
            this.addUserAgent,
            this.addProxy});
            this.dataInput.Name = "dataInput";
            this.dataInput.Size = new System.Drawing.Size(101, 22);
            this.dataInput.Text = "Dữ liệu đầu vào";
            // 
            // addAccount
            // 
            this.addAccount.Name = "addAccount";
            this.addAccount.Size = new System.Drawing.Size(162, 22);
            this.addAccount.Text = "Thêm tài khoản";
            this.addAccount.Click += new System.EventHandler(this.addAccount_Click);
            // 
            // addUserAgent
            // 
            this.addUserAgent.Name = "addUserAgent";
            this.addUserAgent.Size = new System.Drawing.Size(162, 22);
            this.addUserAgent.Text = "Thêm user agent";
            this.addUserAgent.Click += new System.EventHandler(this.addUserAgent_Click);
            // 
            // addProxy
            // 
            this.addProxy.Name = "addProxy";
            this.addProxy.Size = new System.Drawing.Size(162, 22);
            this.addProxy.Text = "Thêm proxy";
            this.addProxy.Click += new System.EventHandler(this.addProxy_Click);
            // 
            // config
            // 
            this.config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configXMDT});
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(67, 22);
            this.config.Text = "Cấu hình";
            // 
            // configXMDT
            // 
            this.configXMDT.Name = "configXMDT";
            this.configXMDT.Size = new System.Drawing.Size(204, 22);
            this.configXMDT.Text = "Phôi xác minh danh tính";
            this.configXMDT.Click += new System.EventHandler(this.configXMDT_Click);
            // 
            // dgViewInput
            // 
            this.dgViewInput.AllowUserToAddRows = false;
            this.dgViewInput.AllowUserToOrderColumns = true;
            this.dgViewInput.AllowUserToResizeRows = false;
            this.dgViewInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgViewInput.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colIndex,
            this.colID,
            this.colPass,
            this.colTwoFA,
            this.colCookie,
            this.colEmail,
            this.colPassMail,
            this.colAccountInfo,
            this.colProxy,
            this.colUserAgent,
            this.colStatus,
            this.colNote});
            this.dgViewInput.ContextMenuStrip = this.contextMenuStrip;
            this.dgViewInput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgViewInput.Location = new System.Drawing.Point(0, 84);
            this.dgViewInput.Name = "dgViewInput";
            this.dgViewInput.RowHeadersVisible = false;
            this.dgViewInput.RowHeadersWidth = 62;
            this.dgViewInput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgViewInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewInput.Size = new System.Drawing.Size(1058, 459);
            this.dgViewInput.TabIndex = 3;
            // 
            // colCheck
            // 
            this.colCheck.FalseValue = "false";
            this.colCheck.HeaderText = "Chọn";
            this.colCheck.IndeterminateValue = "false";
            this.colCheck.MinimumWidth = 8;
            this.colCheck.Name = "colCheck";
            this.colCheck.TrueValue = "true";
            this.colCheck.Width = 50;
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "STT";
            this.colIndex.MinimumWidth = 8;
            this.colIndex.Name = "colIndex";
            this.colIndex.Width = 50;
            // 
            // colID
            // 
            this.colID.HeaderText = "UID";
            this.colID.MinimumWidth = 8;
            this.colID.Name = "colID";
            this.colID.Width = 80;
            // 
            // colPass
            // 
            this.colPass.HeaderText = "Mật khẩu";
            this.colPass.MinimumWidth = 8;
            this.colPass.Name = "colPass";
            this.colPass.Width = 80;
            // 
            // colTwoFA
            // 
            this.colTwoFA.HeaderText = "Mã 2 FA";
            this.colTwoFA.MinimumWidth = 8;
            this.colTwoFA.Name = "colTwoFA";
            this.colTwoFA.Width = 80;
            // 
            // colCookie
            // 
            this.colCookie.HeaderText = "Cookie";
            this.colCookie.MinimumWidth = 8;
            this.colCookie.Name = "colCookie";
            this.colCookie.Width = 150;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 8;
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 80;
            // 
            // colPassMail
            // 
            this.colPassMail.HeaderText = "Pass email";
            this.colPassMail.MinimumWidth = 8;
            this.colPassMail.Name = "colPassMail";
            this.colPassMail.Width = 80;
            // 
            // colAccountInfo
            // 
            this.colAccountInfo.HeaderText = "Thông tin tài khoản";
            this.colAccountInfo.MinimumWidth = 8;
            this.colAccountInfo.Name = "colAccountInfo";
            this.colAccountInfo.Width = 150;
            // 
            // colProxy
            // 
            this.colProxy.HeaderText = "Proxy";
            this.colProxy.MinimumWidth = 8;
            this.colProxy.Name = "colProxy";
            this.colProxy.Width = 80;
            // 
            // colUserAgent
            // 
            this.colUserAgent.HeaderText = "User Agent";
            this.colUserAgent.MinimumWidth = 8;
            this.colUserAgent.Name = "colUserAgent";
            this.colUserAgent.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Tình trạng";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 80;
            // 
            // colNote
            // 
            this.colNote.HeaderText = "Ghi chú";
            this.colNote.MinimumWidth = 8;
            this.colNote.Name = "colNote";
            this.colNote.Width = 150;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSelected,
            this.cmsUnselectedAll,
            this.cmsFacebook,
            this.cmsCheckStatusAccount});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip.ShowCheckMargin = true;
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 117);
            // 
            // cmsSelected
            // 
            this.cmsSelected.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSelectAll,
            this.cmsSelectHightlight});
            this.cmsSelected.Name = "cmsSelected";
            this.cmsSelected.Size = new System.Drawing.Size(180, 22);
            this.cmsSelected.Text = "Chọn";
            // 
            // cmsSelectAll
            // 
            this.cmsSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsSelectAll.Name = "cmsSelectAll";
            this.cmsSelectAll.Size = new System.Drawing.Size(100, 23);
            this.cmsSelectAll.Text = "Tất cả";
            this.cmsSelectAll.Click += new System.EventHandler(this.cmsSelectAll_Click);
            // 
            // cmsSelectHightlight
            // 
            this.cmsSelectHightlight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsSelectHightlight.Name = "cmsSelectHightlight";
            this.cmsSelectHightlight.Size = new System.Drawing.Size(100, 23);
            this.cmsSelectHightlight.Text = "Bôi đen";
            this.cmsSelectHightlight.Click += new System.EventHandler(this.cmsSelectHightlight_Click);
            // 
            // cmsUnselectedAll
            // 
            this.cmsUnselectedAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsUnselectedAll.Name = "cmsUnselectedAll";
            this.cmsUnselectedAll.Size = new System.Drawing.Size(100, 23);
            this.cmsUnselectedAll.Text = "Bỏ chọn tất cả";
            this.cmsUnselectedAll.Click += new System.EventHandler(this.cmsUnselectedAll_Click);
            // 
            // cmsFacebook
            // 
            this.cmsFacebook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCheckPoint282,
            this.cmsCheckPoint956});
            this.cmsFacebook.Name = "cmsFacebook";
            this.cmsFacebook.Size = new System.Drawing.Size(180, 22);
            this.cmsFacebook.Text = "Giải check point";
            // 
            // cmsCheckPoint282
            // 
            this.cmsCheckPoint282.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCP282MBasic,
            this.cmsCP282M,
            this.cmsCP282});
            this.cmsCheckPoint282.Name = "cmsCheckPoint282";
            this.cmsCheckPoint282.Size = new System.Drawing.Size(180, 22);
            this.cmsCheckPoint282.Text = "Checkpoint 282";
            // 
            // cmsCheckPoint956
            // 
            this.cmsCheckPoint956.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCheckPoint956.Name = "cmsCheckPoint956";
            this.cmsCheckPoint956.Size = new System.Drawing.Size(100, 23);
            this.cmsCheckPoint956.Text = "Check point 956";
            // 
            // cmsCheckStatusAccount
            // 
            this.cmsCheckStatusAccount.Name = "cmsCheckStatusAccount";
            this.cmsCheckStatusAccount.Size = new System.Drawing.Size(180, 22);
            this.cmsCheckStatusAccount.Text = "Check tài khoản";
            this.cmsCheckStatusAccount.Click += new System.EventHandler(this.checkStatusAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn thư mục";
            // 
            // cbFile
            // 
            this.cbFile.FormattingEnabled = true;
            this.cbFile.Location = new System.Drawing.Point(92, 40);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(121, 21);
            this.cbFile.TabIndex = 8;
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.BackgroundImage = global::XMDT.Properties.Resources.minus;
            this.btnRemoveAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveAccount.Location = new System.Drawing.Point(339, 40);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(30, 23);
            this.btnRemoveAccount.TabIndex = 9;
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Xoá tài khoản";
            // 
            // rbLoginCookie
            // 
            this.rbLoginCookie.AutoSize = true;
            this.rbLoginCookie.Checked = true;
            this.rbLoginCookie.Location = new System.Drawing.Point(398, 43);
            this.rbLoginCookie.Name = "rbLoginCookie";
            this.rbLoginCookie.Size = new System.Drawing.Size(113, 17);
            this.rbLoginCookie.TabIndex = 11;
            this.rbLoginCookie.TabStop = true;
            this.rbLoginCookie.Text = "Đăng nhập cookie";
            this.rbLoginCookie.UseVisualStyleBackColor = true;
            // 
            // rbLoginUP
            // 
            this.rbLoginUP.AutoSize = true;
            this.rbLoginUP.Location = new System.Drawing.Point(518, 45);
            this.rbLoginUP.Name = "rbLoginUP";
            this.rbLoginUP.Size = new System.Drawing.Size(101, 17);
            this.rbLoginUP.TabIndex = 12;
            this.rbLoginUP.TabStop = true;
            this.rbLoginUP.Text = "Đăng nhập U/P";
            this.rbLoginUP.UseVisualStyleBackColor = true;
            // 
            // cmsCP282MBasic
            // 
            this.cmsCP282MBasic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCP282MBasic.Name = "cmsCP282MBasic";
            this.cmsCP282MBasic.Size = new System.Drawing.Size(100, 23);
            this.cmsCP282MBasic.Text = "MBasic Facebook";
            this.cmsCP282MBasic.Click += new System.EventHandler(this.cmsCP282MBasic_Click);
            // 
            // cmsCP282M
            // 
            this.cmsCP282M.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCP282M.Name = "cmsCP282M";
            this.cmsCP282M.Size = new System.Drawing.Size(100, 23);
            this.cmsCP282M.Text = "M Facebook";
            this.cmsCP282M.Click += new System.EventHandler(this.cmsCP282M_Click);
            // 
            // cmsCP282
            // 
            this.cmsCP282.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCP282.Name = "cmsCP282";
            this.cmsCP282.Size = new System.Drawing.Size(100, 23);
            this.cmsCP282.Text = "Facebook";
            this.cmsCP282.Click += new System.EventHandler(this.cmsCP282_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 544);
            this.Controls.Add(this.rbLoginUP);
            this.Controls.Add(this.rbLoginCookie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemoveAccount);
            this.Controls.Add(this.cbFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgViewInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewInput)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem config;
        private System.Windows.Forms.ToolStripMenuItem configXMDT;
        private System.Windows.Forms.ToolStripMenuItem addAccount;
        private System.Windows.Forms.DataGridView dgViewInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cmsSelected;
        private System.Windows.Forms.ToolStripTextBox cmsSelectAll;
        private System.Windows.Forms.ToolStripTextBox cmsSelectHightlight;
        private System.Windows.Forms.ToolStripTextBox cmsUnselectedAll;
        private System.Windows.Forms.ToolStripMenuItem cmsFacebook;
        private System.Windows.Forms.ToolStripTextBox cmsCheckPoint956;
        private System.Windows.Forms.ToolStripMenuItem dataInput;
        private System.Windows.Forms.ToolStripMenuItem addUserAgent;
        private System.Windows.Forms.ToolStripMenuItem addProxy;
        private System.Windows.Forms.ToolStripMenuItem cmsCheckPoint282;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbLoginCookie;
        private System.Windows.Forms.RadioButton rbLoginUP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTwoFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCookie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.ToolStripMenuItem cmsCheckStatusAccount;
        private System.Windows.Forms.ToolStripTextBox cmsCP282MBasic;
        private System.Windows.Forms.ToolStripTextBox cmsCP282M;
        private System.Windows.Forms.ToolStripTextBox cmsCP282;
    }
}

