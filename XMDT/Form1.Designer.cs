namespace XMDT
{
    partial class Form1
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 323);
            this.Controls.Add(this.btnProgess);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProgess;
    }
}

