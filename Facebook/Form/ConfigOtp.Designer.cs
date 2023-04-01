namespace Facebook
{
    partial class ConfigOtp
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
            label1 = new Label();
            txtApiKey = new TextBox();
            cbLink = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cbHomeNetwork = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 30);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "ApiKey";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(188, 22);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(251, 23);
            txtApiKey.TabIndex = 1;
            // 
            // cbLink
            // 
            cbLink.FormattingEnabled = true;
            cbLink.Location = new Point(188, 65);
            cbLink.Name = "cbLink";
            cbLink.Size = new Size(251, 23);
            cbLink.TabIndex = 2;
            cbLink.SelectedIndexChanged += cbLink_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 73);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 3;
            label2.Text = "Chọn trang get OTP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 112);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 4;
            label3.Text = "Chọn nhà mạng";
            // 
            // cbHomeNetwork
            // 
            cbHomeNetwork.FormattingEnabled = true;
            cbHomeNetwork.Location = new Point(188, 109);
            cbHomeNetwork.Name = "cbHomeNetwork";
            cbHomeNetwork.Size = new Size(251, 23);
            cbHomeNetwork.TabIndex = 5;
            cbHomeNetwork.SelectedIndexChanged += cbHomeNetwork_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(364, 153);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ConfigOtp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 205);
            Controls.Add(btnSave);
            Controls.Add(cbHomeNetwork);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbLink);
            Controls.Add(txtApiKey);
            Controls.Add(label1);
            Name = "ConfigOtp";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtApiKey;
        private ComboBox cbLink;
        private Label label2;
        private Label label3;
        private ComboBox cbHomeNetwork;
        private Button btnSave;
    }
}