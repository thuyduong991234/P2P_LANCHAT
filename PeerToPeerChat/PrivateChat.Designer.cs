namespace PeerToPeerChat
{
    partial class PrivateChat
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
            this.btnsend = new System.Windows.Forms.Button();
            this.txtsend = new System.Windows.Forms.TextBox();
            this.rtxtDisplay = new System.Windows.Forms.RichTextBox();
            this.lkbColor = new System.Windows.Forms.LinkLabel();
            this.lkbFont = new System.Windows.Forms.LinkLabel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(388, 357);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(66, 23);
            this.btnsend.TabIndex = 10;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // txtsend
            // 
            this.txtsend.Location = new System.Drawing.Point(12, 359);
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(370, 20);
            this.txtsend.TabIndex = 9;
            this.txtsend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsend_KeyPress);
            // 
            // rtxtDisplay
            // 
            this.rtxtDisplay.Location = new System.Drawing.Point(12, 12);
            this.rtxtDisplay.Name = "rtxtDisplay";
            this.rtxtDisplay.Size = new System.Drawing.Size(443, 315);
            this.rtxtDisplay.TabIndex = 12;
            this.rtxtDisplay.Text = "";
            // 
            // lkbColor
            // 
            this.lkbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkbColor.AutoSize = true;
            this.lkbColor.Location = new System.Drawing.Point(66, 337);
            this.lkbColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkbColor.Name = "lkbColor";
            this.lkbColor.Size = new System.Drawing.Size(31, 13);
            this.lkbColor.TabIndex = 14;
            this.lkbColor.TabStop = true;
            this.lkbColor.Text = "Color";
            this.lkbColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbColor_LinkClicked);
            // 
            // lkbFont
            // 
            this.lkbFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkbFont.AutoSize = true;
            this.lkbFont.Location = new System.Drawing.Point(13, 337);
            this.lkbFont.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkbFont.Name = "lkbFont";
            this.lkbFont.Size = new System.Drawing.Size(28, 13);
            this.lkbFont.TabIndex = 13;
            this.lkbFont.TabStop = true;
            this.lkbFont.Text = "Font";
            this.lkbFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbFont_LinkClicked);
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(467, 391);
            this.Controls.Add(this.lkbColor);
            this.Controls.Add(this.lkbFont);
            this.Controls.Add(this.rtxtDisplay);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtsend);
            this.Name = "PrivateChat";
            this.Text = "PrivateChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrivateChat_FormClosing);
            this.Load += new System.EventHandler(this.PrivateChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox txtsend;
        private System.Windows.Forms.LinkLabel lkbColor;
        private System.Windows.Forms.LinkLabel lkbFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.RichTextBox rtxtDisplay;
    }
}