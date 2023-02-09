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
            this.btnProgess = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProgess
            // 
            this.btnProgess.Location = new System.Drawing.Point(325, 262);
            this.btnProgess.Name = "btnProgess";
            this.btnProgess.Size = new System.Drawing.Size(75, 23);
            this.btnProgess.TabIndex = 0;
            this.btnProgess.Text = "Xử lý";
            this.btnProgess.UseVisualStyleBackColor = true;
            this.btnProgess.Click += new System.EventHandler(this.btnProgess_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(420, 262);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(99, 23);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Cấu hình phôi";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 323);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnProgess);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProgess;
        private System.Windows.Forms.Button btnConfig;
    }
}

