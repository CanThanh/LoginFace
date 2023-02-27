namespace XMDT
{
    partial class ConfigUserAgent_Proxy
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
            this.lblList = new System.Windows.Forms.Label();
            this.rtxInput = new System.Windows.Forms.RichTextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.nUDAccount = new System.Windows.Forms.NumericUpDown();
            this.lblRadio = new System.Windows.Forms.Label();
            this.rbSequence = new System.Windows.Forms.RadioButton();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.lblInfo = new System.Windows.Forms.Label();
            this.ckExistAccount = new System.Windows.Forms.CheckBox();
            this.btnConfirn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(13, 13);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(121, 13);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Danh sách User Agent: ";
            // 
            // rtxInput
            // 
            this.rtxInput.Location = new System.Drawing.Point(16, 39);
            this.rtxInput.Name = "rtxInput";
            this.rtxInput.Size = new System.Drawing.Size(524, 191);
            this.rtxInput.TabIndex = 1;
            this.rtxInput.Text = "";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(16, 246);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(125, 13);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "Số tài khoản/User Agent";
            // 
            // nUDAccount
            // 
            this.nUDAccount.Location = new System.Drawing.Point(168, 239);
            this.nUDAccount.Name = "nUDAccount";
            this.nUDAccount.Size = new System.Drawing.Size(46, 20);
            this.nUDAccount.TabIndex = 3;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(16, 281);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(135, 13);
            this.lblRadio.TabIndex = 4;
            this.lblRadio.Text = "Tuỳ chọn nhập User Agent";
            // 
            // rbSequence
            // 
            this.rbSequence.AutoSize = true;
            this.rbSequence.Location = new System.Drawing.Point(168, 276);
            this.rbSequence.Name = "rbSequence";
            this.rbSequence.Size = new System.Drawing.Size(63, 17);
            this.rbSequence.TabIndex = 5;
            this.rbSequence.TabStop = true;
            this.rbSequence.Text = "Lần lượt";
            this.rbSequence.UseVisualStyleBackColor = true;
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Location = new System.Drawing.Point(272, 276);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(80, 17);
            this.rbRandom.TabIndex = 6;
            this.rbRandom.TabStop = true;
            this.rbRandom.Text = "Ngẫu nhiên";
            this.rbRandom.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(418, 239);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(122, 13);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "(Mỗi User Agent 1 dòng)";
            // 
            // ckExistAccount
            // 
            this.ckExistAccount.AutoSize = true;
            this.ckExistAccount.Location = new System.Drawing.Point(19, 317);
            this.ckExistAccount.Name = "ckExistAccount";
            this.ckExistAccount.Size = new System.Drawing.Size(240, 17);
            this.ckExistAccount.TabIndex = 8;
            this.ckExistAccount.Text = "Không nhập với các tài khoản có User Agent";
            this.ckExistAccount.UseVisualStyleBackColor = true;
            // 
            // btnConfirn
            // 
            this.btnConfirn.Location = new System.Drawing.Point(221, 353);
            this.btnConfirn.Name = "btnConfirn";
            this.btnConfirn.Size = new System.Drawing.Size(75, 23);
            this.btnConfirn.TabIndex = 9;
            this.btnConfirn.Text = "Xác nhận";
            this.btnConfirn.UseVisualStyleBackColor = true;
            // 
            // ConfigUserAgent_Proxy
            // 
            this.ClientSize = new System.Drawing.Size(545, 384);
            this.Controls.Add(this.btnConfirn);
            this.Controls.Add(this.ckExistAccount);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.rbRandom);
            this.Controls.Add(this.rbSequence);
            this.Controls.Add(this.lblRadio);
            this.Controls.Add(this.nUDAccount);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.rtxInput);
            this.Controls.Add(this.lblList);
            this.Name = "ConfigUserAgent_Proxy";
            this.Load += new System.EventHandler(this.ConfigUserAgent_Proxy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.RichTextBox rtxInput;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.NumericUpDown nUDAccount;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.RadioButton rbSequence;
        private System.Windows.Forms.RadioButton rbRandom;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox ckExistAccount;
        private System.Windows.Forms.Button btnConfirn;
    }
}

