namespace XMDT
{
    partial class ConfigInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigInput));
            this.lvInput = new System.Windows.Forms.ListView();
            this.lvConfig = new System.Windows.Forms.ListView();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSplitCharacter = new System.Windows.Forms.TextBox();
            this.cbFile = new System.Windows.Forms.ComboBox();
            this.rtbAccount = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckOtherFormat = new System.Windows.Forms.CheckBox();
            this.cbInput = new System.Windows.Forms.ComboBox();
            this.btnAddDirection = new System.Windows.Forms.Button();
            this.btnAddOtherInput = new System.Windows.Forms.Button();
            this.btnRemoveItemInput = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvInput
            // 
            this.lvInput.AllowDrop = true;
            this.lvInput.HideSelection = false;
            this.lvInput.Location = new System.Drawing.Point(12, 374);
            this.lvInput.MultiSelect = false;
            this.lvInput.Name = "lvInput";
            this.lvInput.Size = new System.Drawing.Size(291, 102);
            this.lvInput.TabIndex = 8;
            this.lvInput.UseCompatibleStateImageBehavior = false;
            this.lvInput.View = System.Windows.Forms.View.List;
            this.lvInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvInput_DragDrop);
            this.lvInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvInput_DragEnter);
            this.lvInput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvInput_MouseDown);
            this.lvInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvInput_MouseMove);
            this.lvInput.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvInput_MouseUp);
            // 
            // lvConfig
            // 
            this.lvConfig.AllowDrop = true;
            this.lvConfig.HideSelection = false;
            this.lvConfig.Location = new System.Drawing.Point(309, 374);
            this.lvConfig.MultiSelect = false;
            this.lvConfig.Name = "lvConfig";
            this.lvConfig.Size = new System.Drawing.Size(274, 102);
            this.lvConfig.TabIndex = 9;
            this.lvConfig.UseCompatibleStateImageBehavior = false;
            this.lvConfig.View = System.Windows.Forms.View.List;
            this.lvConfig.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvConfig_DragDrop);
            this.lvConfig.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvConfig_DragEnter);
            this.lvConfig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvConfig_MouseDown);
            this.lvConfig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvConfig_MouseMove);
            this.lvConfig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvConfig_MouseUp);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(697, 374);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(99, 41);
            this.btnAddAccount.TabIndex = 12;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ký tự phân cách dữ liệu";
            // 
            // txtSplitCharacter
            // 
            this.txtSplitCharacter.Location = new System.Drawing.Point(309, 491);
            this.txtSplitCharacter.Name = "txtSplitCharacter";
            this.txtSplitCharacter.Size = new System.Drawing.Size(53, 26);
            this.txtSplitCharacter.TabIndex = 10;
            this.txtSplitCharacter.Text = "|";
            this.txtSplitCharacter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbFile
            // 
            this.cbFile.FormattingEnabled = true;
            this.cbFile.Location = new System.Drawing.Point(161, 14);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(176, 28);
            this.cbFile.TabIndex = 1;
            // 
            // rtbAccount
            // 
            this.rtbAccount.Location = new System.Drawing.Point(12, 119);
            this.rtbAccount.Name = "rtbAccount";
            this.rtbAccount.Size = new System.Drawing.Size(784, 193);
            this.rtbAccount.TabIndex = 6;
            this.rtbAccount.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thư mục";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Định dạng đầu vào";
            // 
            // ckOtherFormat
            // 
            this.ckOtherFormat.AutoSize = true;
            this.ckOtherFormat.Location = new System.Drawing.Point(12, 333);
            this.ckOtherFormat.Name = "ckOtherFormat";
            this.ckOtherFormat.Size = new System.Drawing.Size(146, 24);
            this.ckOtherFormat.TabIndex = 7;
            this.ckOtherFormat.Text = "Định dạng khác";
            this.ckOtherFormat.UseVisualStyleBackColor = true;
            this.ckOtherFormat.CheckedChanged += new System.EventHandler(this.ckOtherFormat_CheckedChanged);
            // 
            // cbInput
            // 
            this.cbInput.FormattingEnabled = true;
            this.cbInput.Location = new System.Drawing.Point(161, 65);
            this.cbInput.Name = "cbInput";
            this.cbInput.Size = new System.Drawing.Size(598, 28);
            this.cbInput.TabIndex = 4;
            // 
            // btnAddDirection
            // 
            this.btnAddDirection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDirection.BackgroundImage")));
            this.btnAddDirection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddDirection.Location = new System.Drawing.Point(765, 14);
            this.btnAddDirection.Name = "btnAddDirection";
            this.btnAddDirection.Size = new System.Drawing.Size(31, 26);
            this.btnAddDirection.TabIndex = 3;
            this.btnAddDirection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddDirection.UseVisualStyleBackColor = true;
            this.btnAddDirection.Click += new System.EventHandler(this.btnAddDirection_Click);
            // 
            // btnAddOtherInput
            // 
            this.btnAddOtherInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOtherInput.BackgroundImage")));
            this.btnAddOtherInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddOtherInput.Location = new System.Drawing.Point(552, 330);
            this.btnAddOtherInput.Name = "btnAddOtherInput";
            this.btnAddOtherInput.Size = new System.Drawing.Size(31, 28);
            this.btnAddOtherInput.TabIndex = 11;
            this.btnAddOtherInput.UseVisualStyleBackColor = true;
            this.btnAddOtherInput.Click += new System.EventHandler(this.btnAddOtherInput_Click);
            // 
            // btnRemoveItemInput
            // 
            this.btnRemoveItemInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveItemInput.BackgroundImage")));
            this.btnRemoveItemInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveItemInput.Location = new System.Drawing.Point(767, 65);
            this.btnRemoveItemInput.Name = "btnRemoveItemInput";
            this.btnRemoveItemInput.Size = new System.Drawing.Size(31, 28);
            this.btnRemoveItemInput.TabIndex = 5;
            this.btnRemoveItemInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveItemInput.UseVisualStyleBackColor = true;
            this.btnRemoveItemInput.Click += new System.EventHandler(this.btnRemoveItemInput_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(697, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 41);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Thêm thư mục";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(567, 16);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(192, 26);
            this.txtDirectory.TabIndex = 2;
            // 
            // ConfigInput
            // 
            this.ClientSize = new System.Drawing.Size(810, 539);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveItemInput);
            this.Controls.Add(this.btnAddOtherInput);
            this.Controls.Add(this.btnAddDirection);
            this.Controls.Add(this.cbInput);
            this.Controls.Add(this.ckOtherFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbAccount);
            this.Controls.Add(this.cbFile);
            this.Controls.Add(this.txtSplitCharacter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.lvConfig);
            this.Controls.Add(this.lvInput);
            this.Name = "ConfigInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvInput;
        private System.Windows.Forms.ListView lvConfig;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSplitCharacter;
        private System.Windows.Forms.ComboBox cbFile;
        private System.Windows.Forms.RichTextBox rtbAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckOtherFormat;
        private System.Windows.Forms.ComboBox cbInput;
        private System.Windows.Forms.Button btnAddDirection;
        private System.Windows.Forms.Button btnAddOtherInput;
        private System.Windows.Forms.Button btnRemoveItemInput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDirectory;
    }
}

