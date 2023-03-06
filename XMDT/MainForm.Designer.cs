namespace XMDT
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xửLýLỗiFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookerr282 = new System.Windows.Forms.ToolStripMenuItem();
            this.config = new System.Windows.Forms.ToolStripMenuItem();
            this.configXMDT = new System.Windows.Forms.ToolStripMenuItem();
            this.configInputData = new System.Windows.Forms.ToolStripMenuItem();
            this.configUserAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.configProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.dgViewInput = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTwoFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmailRecover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUserAgent = new System.Windows.Forms.Button();
            this.btnProxy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFile = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewInput)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xửLýLỗiFacebookToolStripMenuItem,
            this.config});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xửLýLỗiFacebookToolStripMenuItem
            // 
            this.xửLýLỗiFacebookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facebookerr282});
            this.xửLýLỗiFacebookToolStripMenuItem.Name = "xửLýLỗiFacebookToolStripMenuItem";
            this.xửLýLỗiFacebookToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.xửLýLỗiFacebookToolStripMenuItem.Text = "Xử lý lỗi facebook";
            // 
            // facebookerr282
            // 
            this.facebookerr282.Name = "facebookerr282";
            this.facebookerr282.Size = new System.Drawing.Size(120, 22);
            this.facebookerr282.Text = "Error 282";
            this.facebookerr282.Click += new System.EventHandler(this.facebookerr282_Click);
            // 
            // config
            // 
            this.config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configXMDT,
            this.configInputData,
            this.configUserAgent,
            this.configProxy});
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
            // configInputData
            // 
            this.configInputData.Name = "configInputData";
            this.configInputData.Size = new System.Drawing.Size(204, 22);
            this.configInputData.Text = "Dữ liệu đầu vào";
            this.configInputData.Click += new System.EventHandler(this.configInputData_Click);
            // 
            // configUserAgent
            // 
            this.configUserAgent.Name = "configUserAgent";
            this.configUserAgent.Size = new System.Drawing.Size(204, 22);
            this.configUserAgent.Text = "User Agent";
            this.configUserAgent.Click += new System.EventHandler(this.configUserAgent_Click);
            // 
            // configProxy
            // 
            this.configProxy.Name = "configProxy";
            this.configProxy.Size = new System.Drawing.Size(204, 22);
            this.configProxy.Text = "Proxy";
            this.configProxy.Click += new System.EventHandler(this.configProxy_Click);
            // 
            // dgViewInput
            // 
            this.dgViewInput.AllowUserToOrderColumns = true;
            this.dgViewInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colIndex,
            this.colID,
            this.colPass,
            this.colTwoFA,
            this.colCookie,
            this.colEmailRecover,
            this.colPassMail,
            this.colAccountInfo,
            this.colProxy,
            this.colUserAgent,
            this.colStatus,
            this.colNote});
            this.dgViewInput.Location = new System.Drawing.Point(0, 84);
            this.dgViewInput.Name = "dgViewInput";
            this.dgViewInput.RowHeadersVisible = false;
            this.dgViewInput.RowHeadersWidth = 62;
            this.dgViewInput.Size = new System.Drawing.Size(1058, 459);
            this.dgViewInput.TabIndex = 3;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "Chọn";
            this.colCheck.MinimumWidth = 8;
            this.colCheck.Name = "colCheck";
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
            // colEmailRecover
            // 
            this.colEmailRecover.HeaderText = "Email khôi phục";
            this.colEmailRecover.MinimumWidth = 8;
            this.colEmailRecover.Name = "colEmailRecover";
            this.colEmailRecover.Width = 80;
            // 
            // colPassMail
            // 
            this.colPassMail.HeaderText = "Mật khẩu mail";
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
            // btnUserAgent
            // 
            this.btnUserAgent.Location = new System.Drawing.Point(231, 29);
            this.btnUserAgent.Name = "btnUserAgent";
            this.btnUserAgent.Size = new System.Drawing.Size(103, 23);
            this.btnUserAgent.TabIndex = 5;
            this.btnUserAgent.Text = "Nhập UserAgent";
            this.btnUserAgent.UseVisualStyleBackColor = true;
            this.btnUserAgent.Click += new System.EventHandler(this.btnUserAgent_Click);
            // 
            // btnProxy
            // 
            this.btnProxy.Location = new System.Drawing.Point(360, 29);
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.Size = new System.Drawing.Size(90, 23);
            this.btnProxy.TabIndex = 6;
            this.btnProxy.Text = "Nhập Proxy";
            this.btnProxy.UseVisualStyleBackColor = true;
            this.btnProxy.Click += new System.EventHandler(this.btnProxy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn thư mục";
            // 
            // cbFile
            // 
            this.cbFile.FormattingEnabled = true;
            this.cbFile.Location = new System.Drawing.Point(104, 31);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(121, 21);
            this.cbFile.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 544);
            this.Controls.Add(this.cbFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProxy);
            this.Controls.Add(this.btnUserAgent);
            this.Controls.Add(this.dgViewInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xửLýLỗiFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem config;
        private System.Windows.Forms.ToolStripMenuItem configXMDT;
        private System.Windows.Forms.ToolStripMenuItem facebookerr282;
        private System.Windows.Forms.ToolStripMenuItem configInputData;
        private System.Windows.Forms.DataGridView dgViewInput;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTwoFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCookie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmailRecover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.ToolStripMenuItem configUserAgent;
        private System.Windows.Forms.ToolStripMenuItem configProxy;
        private System.Windows.Forms.Button btnUserAgent;
        private System.Windows.Forms.Button btnProxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFile;
    }
}

