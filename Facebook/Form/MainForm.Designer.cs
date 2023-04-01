namespace Facebook
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            config = new ToolStripMenuItem();
            configXMDT = new ToolStripMenuItem();
            oTPToolStripMenuItem = new ToolStripMenuItem();
            dataInput = new ToolStripMenuItem();
            addAccount = new ToolStripMenuItem();
            addUserAgent = new ToolStripMenuItem();
            addProxy = new ToolStripMenuItem();
            dgViewInput = new DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            cmsSelected = new ToolStripMenuItem();
            cmsSelectAll = new ToolStripTextBox();
            cmsSelectHightlight = new ToolStripTextBox();
            cmsUnselectedAll = new ToolStripTextBox();
            cmsCheckpointFacebook = new ToolStripMenuItem();
            cmsCheckPoint956 = new ToolStripTextBox();
            cmsCheckPoint282 = new ToolStripTextBox();
            cmsCheckStatusAccount = new ToolStripMenuItem();
            cmsAccountQuality = new ToolStripTextBox();
            cmsLogin = new ToolStripTextBox();
            label1 = new Label();
            cbFile = new ComboBox();
            btnRemoveAccount = new Button();
            rbLoginCookie = new RadioButton();
            rbLoginUP = new RadioButton();
            gbLogin = new GroupBox();
            gbAccount = new GroupBox();
            btnAddAccount = new Button();
            gbProxy = new GroupBox();
            btnProxyAdd = new Button();
            btnProxyRemove = new Button();
            gpUserAgent = new GroupBox();
            btnUserAgentAdd = new Button();
            btnUserAgentRemove = new Button();
            colCheck = new DataGridViewCheckBoxColumn();
            colIndex = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            colPass = new DataGridViewTextBoxColumn();
            colTwoFA = new DataGridViewTextBoxColumn();
            colCookie = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPassMail = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colBirthday = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colAccountInfo = new DataGridViewTextBoxColumn();
            colProxy = new DataGridViewTextBoxColumn();
            colUserAgent = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colNote = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgViewInput).BeginInit();
            contextMenuStrip.SuspendLayout();
            gbLogin.SuspendLayout();
            gbAccount.SuspendLayout();
            gbProxy.SuspendLayout();
            gpUserAgent.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { config });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.Size = new Size(1234, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // config
            // 
            config.DropDownItems.AddRange(new ToolStripItem[] { configXMDT, oTPToolStripMenuItem });
            config.Name = "config";
            config.Size = new Size(67, 22);
            config.Text = "Cấu hình";
            // 
            // configXMDT
            // 
            configXMDT.Name = "configXMDT";
            configXMDT.Size = new Size(204, 22);
            configXMDT.Text = "Phôi xác minh danh tính";
            configXMDT.Click += configXMDT_Click;
            // 
            // oTPToolStripMenuItem
            // 
            oTPToolStripMenuItem.Name = "oTPToolStripMenuItem";
            oTPToolStripMenuItem.Size = new Size(204, 22);
            oTPToolStripMenuItem.Text = "OTP";
            oTPToolStripMenuItem.Click += oTPToolStripMenuItem_Click;
            // 
            // dataInput
            // 
            dataInput.Name = "dataInput";
            dataInput.Size = new Size(32, 19);
            // 
            // addAccount
            // 
            addAccount.Name = "addAccount";
            addAccount.Size = new Size(32, 19);
            // 
            // addUserAgent
            // 
            addUserAgent.Name = "addUserAgent";
            addUserAgent.Size = new Size(32, 19);
            // 
            // addProxy
            // 
            addProxy.Name = "addProxy";
            addProxy.Size = new Size(32, 19);
            // 
            // dgViewInput
            // 
            dgViewInput.AllowUserToAddRows = false;
            dgViewInput.AllowUserToDeleteRows = false;
            dgViewInput.AllowUserToResizeColumns = false;
            dgViewInput.AllowUserToResizeRows = false;
            dgViewInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgViewInput.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgViewInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgViewInput.Columns.AddRange(new DataGridViewColumn[] { colCheck, colIndex, colID, colPass, colTwoFA, colCookie, colEmail, colPassMail, colFullName, colBirthday, colGender, colAccountInfo, colProxy, colUserAgent, colStatus, colNote });
            dgViewInput.ContextMenuStrip = contextMenuStrip;
            dgViewInput.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgViewInput.Location = new Point(0, 93);
            dgViewInput.Margin = new Padding(4, 3, 4, 3);
            dgViewInput.Name = "dgViewInput";
            dgViewInput.ReadOnly = true;
            dgViewInput.RowHeadersVisible = false;
            dgViewInput.RowHeadersWidth = 62;
            dgViewInput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgViewInput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgViewInput.Size = new Size(1234, 534);
            dgViewInput.TabIndex = 3;
            dgViewInput.CellClick += dgViewInput_CellClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { cmsSelected, cmsUnselectedAll, cmsCheckpointFacebook, cmsCheckStatusAccount, cmsAccountQuality, cmsLogin });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip.ShowCheckMargin = true;
            contextMenuStrip.ShowImageMargin = false;
            contextMenuStrip.Size = new Size(161, 145);
            // 
            // cmsSelected
            // 
            cmsSelected.DropDownItems.AddRange(new ToolStripItem[] { cmsSelectAll, cmsSelectHightlight });
            cmsSelected.Name = "cmsSelected";
            cmsSelected.Size = new Size(160, 22);
            cmsSelected.Text = "Chọn";
            // 
            // cmsSelectAll
            // 
            cmsSelectAll.Name = "cmsSelectAll";
            cmsSelectAll.ReadOnly = true;
            cmsSelectAll.Size = new Size(100, 23);
            cmsSelectAll.Text = "Tất cả";
            cmsSelectAll.Click += cmsSelectAll_Click;
            // 
            // cmsSelectHightlight
            // 
            cmsSelectHightlight.Name = "cmsSelectHightlight";
            cmsSelectHightlight.ReadOnly = true;
            cmsSelectHightlight.Size = new Size(100, 23);
            cmsSelectHightlight.Text = "Bôi đen";
            cmsSelectHightlight.Click += cmsSelectHightlight_Click;
            // 
            // cmsUnselectedAll
            // 
            cmsUnselectedAll.Name = "cmsUnselectedAll";
            cmsUnselectedAll.ReadOnly = true;
            cmsUnselectedAll.Size = new Size(100, 23);
            cmsUnselectedAll.Text = "Bỏ chọn tất cả";
            cmsUnselectedAll.Click += cmsUnselectedAll_Click;
            // 
            // cmsCheckpointFacebook
            // 
            cmsCheckpointFacebook.DropDownItems.AddRange(new ToolStripItem[] { cmsCheckPoint956, cmsCheckPoint282 });
            cmsCheckpointFacebook.Name = "cmsCheckpointFacebook";
            cmsCheckpointFacebook.Size = new Size(160, 22);
            cmsCheckpointFacebook.Text = "Giải check point";
            // 
            // cmsCheckPoint956
            // 
            cmsCheckPoint956.Name = "cmsCheckPoint956";
            cmsCheckPoint956.ReadOnly = true;
            cmsCheckPoint956.Size = new Size(100, 23);
            cmsCheckPoint956.Text = "Check point 956";
            // 
            // cmsCheckPoint282
            // 
            cmsCheckPoint282.Name = "cmsCheckPoint282";
            cmsCheckPoint282.ReadOnly = true;
            cmsCheckPoint282.Size = new Size(100, 23);
            cmsCheckPoint282.Text = "Check point 282";
            cmsCheckPoint282.Click += cmsCheckPoint282_Click;
            // 
            // cmsCheckStatusAccount
            // 
            cmsCheckStatusAccount.Name = "cmsCheckStatusAccount";
            cmsCheckStatusAccount.Size = new Size(160, 22);
            cmsCheckStatusAccount.Text = "Check tài khoản";
            cmsCheckStatusAccount.Click += checkStatusAccount_Click;
            // 
            // cmsAccountQuality
            // 
            cmsAccountQuality.Name = "cmsAccountQuality";
            cmsAccountQuality.ReadOnly = true;
            cmsAccountQuality.Size = new Size(100, 23);
            cmsAccountQuality.Text = "Xác minh danh tính";
            cmsAccountQuality.Click += cmsAccountQuality_Click;
            // 
            // cmsLogin
            // 
            cmsLogin.Name = "cmsLogin";
            cmsLogin.ReadOnly = true;
            cmsLogin.Size = new Size(100, 23);
            cmsLogin.Text = "Đăng nhập";
            cmsLogin.Click += cmsLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 7;
            label1.Text = "Thư mục lưu";
            // 
            // cbFile
            // 
            cbFile.FormattingEnabled = true;
            cbFile.Location = new Point(102, 25);
            cbFile.Margin = new Padding(4, 3, 4, 3);
            cbFile.Name = "cbFile";
            cbFile.Size = new Size(140, 23);
            cbFile.TabIndex = 8;
            cbFile.SelectedValueChanged += cbFile_SelectedValueChanged;
            // 
            // btnRemoveAccount
            // 
            btnRemoveAccount.BackgroundImage = Properties.Resources.minus;
            btnRemoveAccount.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemoveAccount.Location = new Point(250, 22);
            btnRemoveAccount.Margin = new Padding(4, 3, 4, 3);
            btnRemoveAccount.Name = "btnRemoveAccount";
            btnRemoveAccount.Size = new Size(35, 27);
            btnRemoveAccount.TabIndex = 9;
            btnRemoveAccount.UseVisualStyleBackColor = true;
            btnRemoveAccount.Click += btnRemoveAccount_Click;
            // 
            // rbLoginCookie
            // 
            rbLoginCookie.AutoSize = true;
            rbLoginCookie.Location = new Point(22, 33);
            rbLoginCookie.Margin = new Padding(4, 3, 4, 3);
            rbLoginCookie.Name = "rbLoginCookie";
            rbLoginCookie.Size = new Size(62, 19);
            rbLoginCookie.TabIndex = 11;
            rbLoginCookie.Text = "Cookie";
            rbLoginCookie.UseVisualStyleBackColor = true;
            // 
            // rbLoginUP
            // 
            rbLoginUP.AutoSize = true;
            rbLoginUP.Checked = true;
            rbLoginUP.Location = new Point(92, 33);
            rbLoginUP.Margin = new Padding(4, 3, 4, 3);
            rbLoginUP.Name = "rbLoginUP";
            rbLoginUP.Size = new Size(74, 19);
            rbLoginUP.TabIndex = 12;
            rbLoginUP.TabStop = true;
            rbLoginUP.Text = "User pass";
            rbLoginUP.UseVisualStyleBackColor = true;
            // 
            // gbLogin
            // 
            gbLogin.Controls.Add(rbLoginUP);
            gbLogin.Controls.Add(rbLoginCookie);
            gbLogin.Location = new Point(370, 23);
            gbLogin.Name = "gbLogin";
            gbLogin.Size = new Size(176, 60);
            gbLogin.TabIndex = 13;
            gbLogin.TabStop = false;
            gbLogin.Text = "Đăng nhập";
            // 
            // gbAccount
            // 
            gbAccount.Controls.Add(btnAddAccount);
            gbAccount.Controls.Add(cbFile);
            gbAccount.Controls.Add(label1);
            gbAccount.Controls.Add(btnRemoveAccount);
            gbAccount.Location = new Point(12, 27);
            gbAccount.Name = "gbAccount";
            gbAccount.Size = new Size(335, 60);
            gbAccount.TabIndex = 14;
            gbAccount.TabStop = false;
            gbAccount.Text = "Tài khoản";
            // 
            // btnAddAccount
            // 
            btnAddAccount.BackgroundImage = (Image)resources.GetObject("btnAddAccount.BackgroundImage");
            btnAddAccount.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddAccount.Location = new Point(293, 21);
            btnAddAccount.Margin = new Padding(4, 3, 4, 3);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(35, 27);
            btnAddAccount.TabIndex = 10;
            btnAddAccount.UseVisualStyleBackColor = true;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // gbProxy
            // 
            gbProxy.Controls.Add(btnProxyAdd);
            gbProxy.Controls.Add(btnProxyRemove);
            gbProxy.Location = new Point(562, 31);
            gbProxy.Name = "gbProxy";
            gbProxy.Size = new Size(93, 52);
            gbProxy.TabIndex = 15;
            gbProxy.TabStop = false;
            gbProxy.Text = "Proxy";
            // 
            // btnProxyAdd
            // 
            btnProxyAdd.BackgroundImage = (Image)resources.GetObject("btnProxyAdd.BackgroundImage");
            btnProxyAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnProxyAdd.Location = new Point(7, 18);
            btnProxyAdd.Margin = new Padding(4, 3, 4, 3);
            btnProxyAdd.Name = "btnProxyAdd";
            btnProxyAdd.Size = new Size(35, 27);
            btnProxyAdd.TabIndex = 14;
            btnProxyAdd.UseVisualStyleBackColor = true;
            btnProxyAdd.Click += btnProxyAdd_Click;
            // 
            // btnProxyRemove
            // 
            btnProxyRemove.BackgroundImage = Properties.Resources.minus;
            btnProxyRemove.BackgroundImageLayout = ImageLayout.Stretch;
            btnProxyRemove.Location = new Point(50, 17);
            btnProxyRemove.Margin = new Padding(4, 3, 4, 3);
            btnProxyRemove.Name = "btnProxyRemove";
            btnProxyRemove.Size = new Size(35, 27);
            btnProxyRemove.TabIndex = 13;
            btnProxyRemove.UseVisualStyleBackColor = true;
            btnProxyRemove.Click += btnProxyRemove_Click;
            // 
            // gpUserAgent
            // 
            gpUserAgent.Controls.Add(btnUserAgentAdd);
            gpUserAgent.Controls.Add(btnUserAgentRemove);
            gpUserAgent.Location = new Point(661, 31);
            gpUserAgent.Name = "gpUserAgent";
            gpUserAgent.Size = new Size(95, 52);
            gpUserAgent.TabIndex = 16;
            gpUserAgent.TabStop = false;
            gpUserAgent.Text = "UserAgent";
            // 
            // btnUserAgentAdd
            // 
            btnUserAgentAdd.BackgroundImage = (Image)resources.GetObject("btnUserAgentAdd.BackgroundImage");
            btnUserAgentAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnUserAgentAdd.Location = new Point(7, 18);
            btnUserAgentAdd.Margin = new Padding(4, 3, 4, 3);
            btnUserAgentAdd.Name = "btnUserAgentAdd";
            btnUserAgentAdd.Size = new Size(35, 27);
            btnUserAgentAdd.TabIndex = 12;
            btnUserAgentAdd.UseVisualStyleBackColor = true;
            btnUserAgentAdd.Click += btnUserAgentAdd_Click;
            // 
            // btnUserAgentRemove
            // 
            btnUserAgentRemove.BackgroundImage = Properties.Resources.minus;
            btnUserAgentRemove.BackgroundImageLayout = ImageLayout.Stretch;
            btnUserAgentRemove.Location = new Point(50, 17);
            btnUserAgentRemove.Margin = new Padding(4, 3, 4, 3);
            btnUserAgentRemove.Name = "btnUserAgentRemove";
            btnUserAgentRemove.Size = new Size(35, 27);
            btnUserAgentRemove.TabIndex = 11;
            btnUserAgentRemove.UseVisualStyleBackColor = true;
            btnUserAgentRemove.Click += btnUserAgentRemove_Click;
            // 
            // colCheck
            // 
            colCheck.FalseValue = "false";
            colCheck.HeaderText = "Chọn";
            colCheck.IndeterminateValue = "false";
            colCheck.MinimumWidth = 8;
            colCheck.Name = "colCheck";
            colCheck.ReadOnly = true;
            colCheck.TrueValue = "true";
            colCheck.Width = 50;
            // 
            // colIndex
            // 
            colIndex.HeaderText = "STT";
            colIndex.MinimumWidth = 8;
            colIndex.Name = "colIndex";
            colIndex.ReadOnly = true;
            colIndex.Width = 50;
            // 
            // colID
            // 
            colID.HeaderText = "UID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Width = 80;
            // 
            // colPass
            // 
            colPass.HeaderText = "Mật khẩu";
            colPass.MinimumWidth = 8;
            colPass.Name = "colPass";
            colPass.ReadOnly = true;
            colPass.Width = 80;
            // 
            // colTwoFA
            // 
            colTwoFA.HeaderText = "Mã 2 FA";
            colTwoFA.MinimumWidth = 8;
            colTwoFA.Name = "colTwoFA";
            colTwoFA.ReadOnly = true;
            colTwoFA.Width = 80;
            // 
            // colCookie
            // 
            colCookie.HeaderText = "Cookie";
            colCookie.MinimumWidth = 8;
            colCookie.Name = "colCookie";
            colCookie.ReadOnly = true;
            colCookie.Width = 150;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 80;
            // 
            // colPassMail
            // 
            colPassMail.HeaderText = "Pass email";
            colPassMail.MinimumWidth = 8;
            colPassMail.Name = "colPassMail";
            colPassMail.ReadOnly = true;
            colPassMail.Width = 80;
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colBirthday
            // 
            colBirthday.HeaderText = "Birthday";
            colBirthday.Name = "colBirthday";
            colBirthday.ReadOnly = true;
            // 
            // colGender
            // 
            colGender.HeaderText = "Gender";
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            // 
            // colAccountInfo
            // 
            colAccountInfo.HeaderText = "Thông tin tài khoản";
            colAccountInfo.MinimumWidth = 8;
            colAccountInfo.Name = "colAccountInfo";
            colAccountInfo.ReadOnly = true;
            colAccountInfo.Width = 150;
            // 
            // colProxy
            // 
            colProxy.HeaderText = "Proxy";
            colProxy.MinimumWidth = 8;
            colProxy.Name = "colProxy";
            colProxy.ReadOnly = true;
            colProxy.Width = 80;
            // 
            // colUserAgent
            // 
            colUserAgent.HeaderText = "User Agent";
            colUserAgent.MinimumWidth = 8;
            colUserAgent.Name = "colUserAgent";
            colUserAgent.ReadOnly = true;
            colUserAgent.Width = 150;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Tình trạng";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 80;
            // 
            // colNote
            // 
            colNote.HeaderText = "Ghi chú";
            colNote.MinimumWidth = 8;
            colNote.Name = "colNote";
            colNote.ReadOnly = true;
            colNote.Width = 150;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 628);
            Controls.Add(gpUserAgent);
            Controls.Add(gbProxy);
            Controls.Add(gbAccount);
            Controls.Add(gbLogin);
            Controls.Add(dgViewInput);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgViewInput).EndInit();
            contextMenuStrip.ResumeLayout(false);
            contextMenuStrip.PerformLayout();
            gbLogin.ResumeLayout(false);
            gbLogin.PerformLayout();
            gbAccount.ResumeLayout(false);
            gbAccount.PerformLayout();
            gbProxy.ResumeLayout(false);
            gpUserAgent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem cmsCheckpointFacebook;
        private System.Windows.Forms.ToolStripTextBox cmsCheckPoint956;
        private System.Windows.Forms.ToolStripMenuItem dataInput;
        private System.Windows.Forms.ToolStripMenuItem addUserAgent;
        private System.Windows.Forms.ToolStripMenuItem addProxy;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.RadioButton rbLoginCookie;
        private System.Windows.Forms.RadioButton rbLoginUP;
        private System.Windows.Forms.ToolStripMenuItem cmsCheckStatusAccount;
        private ToolStripTextBox cmsCheckPoint282;
        private ToolStripTextBox cmsAccountQuality;
        private ToolStripTextBox cmsLogin;
        private ToolStripMenuItem oTPToolStripMenuItem;
        private GroupBox gbLogin;
        private GroupBox gbAccount;
        private Button btnAddAccount;
        private GroupBox gbProxy;
        private GroupBox gpUserAgent;
        private Button btnUserAgentAdd;
        private Button btnUserAgentRemove;
        private Button btnProxyAdd;
        private Button btnProxyRemove;
        private DataGridViewCheckBoxColumn colCheck;
        private DataGridViewTextBoxColumn colIndex;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colPass;
        private DataGridViewTextBoxColumn colTwoFA;
        private DataGridViewTextBoxColumn colCookie;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPassMail;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colBirthday;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colAccountInfo;
        private DataGridViewTextBoxColumn colProxy;
        private DataGridViewTextBoxColumn colUserAgent;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colNote;
    }
}