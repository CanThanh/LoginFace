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
            this.lvInput = new System.Windows.Forms.ListView();
            this.lvConfig = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.Truo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvInput
            // 
            this.lvInput.AllowDrop = true;
            this.lvInput.HideSelection = false;
            this.lvInput.Location = new System.Drawing.Point(69, 68);
            this.lvInput.MultiSelect = false;
            this.lvInput.Name = "lvInput";
            this.lvInput.Size = new System.Drawing.Size(238, 265);
            this.lvInput.TabIndex = 0;
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
            this.lvConfig.Location = new System.Drawing.Point(358, 68);
            this.lvConfig.MultiSelect = false;
            this.lvConfig.Name = "lvConfig";
            this.lvConfig.Size = new System.Drawing.Size(238, 265);
            this.lvConfig.TabIndex = 1;
            this.lvConfig.UseCompatibleStateImageBehavior = false;
            this.lvConfig.View = System.Windows.Forms.View.List;
            this.lvConfig.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvConfig_DragDrop);
            this.lvConfig.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvConfig_DragEnter);
            this.lvConfig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvConfig_MouseDown);
            this.lvConfig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvConfig_MouseMove);
            this.lvConfig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvConfig_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Truo
            // 
            this.Truo.AutoSize = true;
            this.Truo.Location = new System.Drawing.Point(354, 27);
            this.Truo.Name = "Truo";
            this.Truo.Size = new System.Drawing.Size(128, 13);
            this.Truo.TabIndex = 4;
            this.Truo.Text = "Trường thông tin đầu vào";
            // 
            // ConfigInput
            // 
            this.ClientSize = new System.Drawing.Size(656, 467);
            this.Controls.Add(this.Truo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvConfig);
            this.Controls.Add(this.lvInput);
            this.Name = "ConfigInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvInput;
        private System.Windows.Forms.ListView lvConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Truo;
    }
}

