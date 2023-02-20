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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.nUDThread = new System.Windows.Forms.NumericUpDown();
            this.configInputData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDThread)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xửLýLỗiFacebookToolStripMenuItem,
            this.config});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xửLýLỗiFacebookToolStripMenuItem
            // 
            this.xửLýLỗiFacebookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facebookerr282});
            this.xửLýLỗiFacebookToolStripMenuItem.Name = "xửLýLỗiFacebookToolStripMenuItem";
            this.xửLýLỗiFacebookToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.xửLýLỗiFacebookToolStripMenuItem.Text = "Xử lý lỗi facebook";
            // 
            // facebookerr282
            // 
            this.facebookerr282.Name = "facebookerr282";
            this.facebookerr282.Size = new System.Drawing.Size(180, 22);
            this.facebookerr282.Text = "Error 282";
            this.facebookerr282.Click += new System.EventHandler(this.facebookerr282_Click);
            // 
            // config
            // 
            this.config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configXMDT,
            this.configInputData});
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(67, 20);
            this.config.Text = "Cấu hình";
            // 
            // configXMDT
            // 
            this.configXMDT.Name = "configXMDT";
            this.configXMDT.Size = new System.Drawing.Size(204, 22);
            this.configXMDT.Text = "Phôi xác minh danh tính";
            this.configXMDT.Click += new System.EventHandler(this.configXMDT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số luồng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User Agent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Proxy";
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(111, 64);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(479, 20);
            this.txtUserAgent.TabIndex = 6;
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(111, 96);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(479, 20);
            this.txtProxy.TabIndex = 7;
            // 
            // nUDThread
            // 
            this.nUDThread.Location = new System.Drawing.Point(111, 32);
            this.nUDThread.Name = "nUDThread";
            this.nUDThread.Size = new System.Drawing.Size(47, 20);
            this.nUDThread.TabIndex = 8;
            // 
            // configInputData
            // 
            this.configInputData.Name = "configInputData";
            this.configInputData.Size = new System.Drawing.Size(204, 22);
            this.configInputData.Text = "Dữ liệu đầu vào";
            this.configInputData.Click += new System.EventHandler(this.configInputData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 323);
            this.Controls.Add(this.nUDThread);
            this.Controls.Add(this.txtProxy);
            this.Controls.Add(this.txtUserAgent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDThread)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xửLýLỗiFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem config;
        private System.Windows.Forms.ToolStripMenuItem configXMDT;
        private System.Windows.Forms.ToolStripMenuItem facebookerr282;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.NumericUpDown nUDThread;
        private System.Windows.Forms.ToolStripMenuItem configInputData;
    }
}

