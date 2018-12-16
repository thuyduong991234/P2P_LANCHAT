namespace PeerToPeerChat
{
    partial class ChatForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstFriends = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbAva = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtsend = new System.Windows.Forms.RichTextBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.wbContent = new System.Windows.Forms.WebBrowser();
            this.ptbExit = new System.Windows.Forms.PictureBox();
            this.ptbMinimize = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAva)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateChatToolStripMenuItem,
            this.chatRoomToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            // 
            // privateChatToolStripMenuItem
            // 
            this.privateChatToolStripMenuItem.Name = "privateChatToolStripMenuItem";
            this.privateChatToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.privateChatToolStripMenuItem.Text = "Private Chat";
            // 
            // chatRoomToolStripMenuItem
            // 
            this.chatRoomToolStripMenuItem.Name = "chatRoomToolStripMenuItem";
            this.chatRoomToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.chatRoomToolStripMenuItem.Text = "Chat room";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.ptbAva);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 514);
            this.panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstFriends);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.groupBox1.Location = new System.Drawing.Point(7, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 375);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friends";
            // 
            // lstFriends
            // 
            this.lstFriends.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFriends.ForeColor = System.Drawing.Color.Black;
            this.lstFriends.FormattingEnabled = true;
            this.lstFriends.ItemHeight = 16;
            this.lstFriends.Location = new System.Drawing.Point(3, 22);
            this.lstFriends.Name = "lstFriends";
            this.lstFriends.Size = new System.Drawing.Size(178, 350);
            this.lstFriends.TabIndex = 0;
            this.lstFriends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFriends_MouseDoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(72, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(-2, -2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(229, 42);
            this.panel4.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Messenger";
            // 
            // ptbAva
            // 
            this.ptbAva.Image = ((System.Drawing.Image)(resources.GetObject("ptbAva.Image")));
            this.ptbAva.Location = new System.Drawing.Point(3, 59);
            this.ptbAva.Name = "ptbAva";
            this.ptbAva.Size = new System.Drawing.Size(46, 40);
            this.ptbAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAva.TabIndex = 14;
            this.ptbAva.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtsend);
            this.panel2.Controls.Add(this.btnFont);
            this.panel2.Controls.Add(this.btnColor);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.wbContent);
            this.panel2.Location = new System.Drawing.Point(197, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 476);
            this.panel2.TabIndex = 9;
            // 
            // txtsend
            // 
            this.txtsend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsend.Location = new System.Drawing.Point(14, 425);
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(450, 36);
            this.txtsend.TabIndex = 33;
            this.txtsend.Text = "";
            this.txtsend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontent_KeyDown);
            // 
            // btnFont
            // 
            this.btnFont.BackColor = System.Drawing.Color.White;
            this.btnFont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFont.ForeColor = System.Drawing.Color.Transparent;
            this.btnFont.Image = ((System.Drawing.Image)(resources.GetObject("btnFont.Image")));
            this.btnFont.Location = new System.Drawing.Point(14, 382);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(35, 36);
            this.btnFont.TabIndex = 32;
            this.btnFont.UseVisualStyleBackColor = false;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.White;
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.Transparent;
            this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
            this.btnColor.Location = new System.Drawing.Point(49, 383);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(35, 36);
            this.btnColor.TabIndex = 31;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.Transparent;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(470, 424);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(59, 37);
            this.btnSend.TabIndex = 28;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // wbContent
            // 
            this.wbContent.Location = new System.Drawing.Point(0, 0);
            this.wbContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbContent.Name = "wbContent";
            this.wbContent.Size = new System.Drawing.Size(540, 371);
            this.wbContent.TabIndex = 19;
            // 
            // ptbExit
            // 
            this.ptbExit.Image = ((System.Drawing.Image)(resources.GetObject("ptbExit.Image")));
            this.ptbExit.Location = new System.Drawing.Point(707, 4);
            this.ptbExit.Name = "ptbExit";
            this.ptbExit.Size = new System.Drawing.Size(32, 32);
            this.ptbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbExit.TabIndex = 8;
            this.ptbExit.TabStop = false;
            this.ptbExit.Click += new System.EventHandler(this.ptbExit_Click);
            // 
            // ptbMinimize
            // 
            this.ptbMinimize.Image = ((System.Drawing.Image)(resources.GetObject("ptbMinimize.Image")));
            this.ptbMinimize.Location = new System.Drawing.Point(669, 3);
            this.ptbMinimize.Name = "ptbMinimize";
            this.ptbMinimize.Size = new System.Drawing.Size(32, 32);
            this.ptbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMinimize.TabIndex = 10;
            this.ptbMinimize.TabStop = false;
            this.ptbMinimize.Click += new System.EventHandler(this.ptbMinimize_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(740, 514);
            this.Controls.Add(this.ptbMinimize);
            this.Controls.Add(this.ptbExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PTQ CHAT";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAva)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem privateChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatRoomToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ptbExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ptbMinimize;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox ptbAva;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstFriends;
        private System.Windows.Forms.WebBrowser wbContent;
        private System.Windows.Forms.RichTextBox txtsend;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnSend;
    }
}

