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
            this.cấuHìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configXMDT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xửLýLỗiFacebookToolStripMenuItem,
            this.cấuHìnhToolStripMenuItem});
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
            // cấuHìnhToolStripMenuItem
            // 
            this.cấuHìnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configXMDT});
            this.cấuHìnhToolStripMenuItem.Name = "cấuHìnhToolStripMenuItem";
            this.cấuHìnhToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.cấuHìnhToolStripMenuItem.Text = "Cấu hình";
            // 
            // configXMDT
            // 
            this.configXMDT.Name = "configXMDT";
            this.configXMDT.Size = new System.Drawing.Size(204, 22);
            this.configXMDT.Text = "Phôi xác minh danh tính";
            this.configXMDT.Click += new System.EventHandler(this.configXMDT_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 323);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xửLýLỗiFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cấuHìnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configXMDT;
        private System.Windows.Forms.ToolStripMenuItem facebookerr282;
    }
}

