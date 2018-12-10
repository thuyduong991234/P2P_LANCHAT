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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateChat));
            this.txtsend = new System.Windows.Forms.TextBox();
            this.rtxtDisplay = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptbSend = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbMinimize = new System.Windows.Forms.PictureBox();
            this.ptbExit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptbFont = new System.Windows.Forms.PictureBox();
            this.ptbColor = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsend
            // 
            this.txtsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsend.Location = new System.Drawing.Point(12, 326);
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(383, 22);
            this.txtsend.TabIndex = 9;
            this.txtsend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsend_KeyPress);
            // 
            // rtxtDisplay
            // 
            this.rtxtDisplay.Location = new System.Drawing.Point(0, 0);
            this.rtxtDisplay.Name = "rtxtDisplay";
            this.rtxtDisplay.Size = new System.Drawing.Size(467, 294);
            this.rtxtDisplay.TabIndex = 12;
            this.rtxtDisplay.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ptbFont);
            this.panel1.Controls.Add(this.ptbColor);
            this.panel1.Controls.Add(this.ptbSend);
            this.panel1.Controls.Add(this.rtxtDisplay);
            this.panel1.Controls.Add(this.txtsend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 360);
            this.panel1.TabIndex = 15;
            // 
            // ptbSend
            // 
            this.ptbSend.Image = ((System.Drawing.Image)(resources.GetObject("ptbSend.Image")));
            this.ptbSend.Location = new System.Drawing.Point(404, 323);
            this.ptbSend.Name = "ptbSend";
            this.ptbSend.Size = new System.Drawing.Size(54, 25);
            this.ptbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSend.TabIndex = 15;
            this.ptbSend.TabStop = false;
            this.ptbSend.Click += new System.EventHandler(this.ptbSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(43, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Private Chat";
            // 
            // ptbMinimize
            // 
            this.ptbMinimize.Image = ((System.Drawing.Image)(resources.GetObject("ptbMinimize.Image")));
            this.ptbMinimize.Location = new System.Drawing.Point(404, -2);
            this.ptbMinimize.Name = "ptbMinimize";
            this.ptbMinimize.Size = new System.Drawing.Size(35, 30);
            this.ptbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMinimize.TabIndex = 18;
            this.ptbMinimize.TabStop = false;
            this.ptbMinimize.Click += new System.EventHandler(this.ptbMinimize_Click);
            // 
            // ptbExit
            // 
            this.ptbExit.Image = ((System.Drawing.Image)(resources.GetObject("ptbExit.Image")));
            this.ptbExit.Location = new System.Drawing.Point(432, -2);
            this.ptbExit.Name = "ptbExit";
            this.ptbExit.Size = new System.Drawing.Size(35, 30);
            this.ptbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbExit.TabIndex = 17;
            this.ptbExit.TabStop = false;
            this.ptbExit.Click += new System.EventHandler(this.ptbExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // ptbFont
            // 
            this.ptbFont.Image = ((System.Drawing.Image)(resources.GetObject("ptbFont.Image")));
            this.ptbFont.Location = new System.Drawing.Point(50, 300);
            this.ptbFont.Name = "ptbFont";
            this.ptbFont.Size = new System.Drawing.Size(32, 24);
            this.ptbFont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbFont.TabIndex = 17;
            this.ptbFont.TabStop = false;
            this.ptbFont.Click += new System.EventHandler(this.ptbFont_Click);
            // 
            // ptbColor
            // 
            this.ptbColor.Image = ((System.Drawing.Image)(resources.GetObject("ptbColor.Image")));
            this.ptbColor.Location = new System.Drawing.Point(12, 300);
            this.ptbColor.Name = "ptbColor";
            this.ptbColor.Size = new System.Drawing.Size(32, 24);
            this.ptbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbColor.TabIndex = 16;
            this.ptbColor.TabStop = false;
            this.ptbColor.Click += new System.EventHandler(this.ptbColor_Click);
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(467, 391);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ptbMinimize);
            this.Controls.Add(this.ptbExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrivateChat";
            this.Text = "PrivateChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrivateChat_FormClosing);
            this.Load += new System.EventHandler(this.PrivateChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtsend;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.RichTextBox rtxtDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptbSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbMinimize;
        private System.Windows.Forms.PictureBox ptbExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ptbFont;
        private System.Windows.Forms.PictureBox ptbColor;
    }
}