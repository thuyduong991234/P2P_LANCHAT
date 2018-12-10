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
            this.rtxtdisplay = new System.Windows.Forms.RichTextBox();
            this.txtcontent = new System.Windows.Forms.TextBox();
            this.lstFriends = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ptbSend = new System.Windows.Forms.PictureBox();
            this.ptbExit = new System.Windows.Forms.PictureBox();
            this.ptbMinimize = new System.Windows.Forms.PictureBox();
            this.ptbColor = new System.Windows.Forms.PictureBox();
            this.ptbFont = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFont)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtdisplay
            // 
            this.rtxtdisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtdisplay.BackColor = System.Drawing.Color.White;
            this.rtxtdisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtdisplay.Location = new System.Drawing.Point(0, 0);
            this.rtxtdisplay.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtdisplay.Name = "rtxtdisplay";
            this.rtxtdisplay.ReadOnly = true;
            this.rtxtdisplay.Size = new System.Drawing.Size(647, 398);
            this.rtxtdisplay.TabIndex = 2;
            this.rtxtdisplay.TabStop = false;
            this.rtxtdisplay.Text = "";
            // 
            // txtcontent
            // 
            this.txtcontent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtcontent.Location = new System.Drawing.Point(83, 418);
            this.txtcontent.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontent.Name = "txtcontent";
            this.txtcontent.Size = new System.Drawing.Size(494, 23);
            this.txtcontent.TabIndex = 1;
            this.txtcontent.TabStop = false;
            this.txtcontent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontent_KeyDown);
            // 
            // lstFriends
            // 
            this.lstFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFriends.ContextMenuStrip = this.contextMenuStrip1;
            this.lstFriends.FormattingEnabled = true;
            this.lstFriends.ItemHeight = 16;
            this.lstFriends.Location = new System.Drawing.Point(8, 23);
            this.lstFriends.Margin = new System.Windows.Forms.Padding(4);
            this.lstFriends.Name = "lstFriends";
            this.lstFriends.Size = new System.Drawing.Size(184, 372);
            this.lstFriends.TabIndex = 4;
            this.lstFriends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFriends_MouseDoubleClick);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lstFriends);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(23, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(201, 409);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Who\'s Online";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 493);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "P2P LAN CHAT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ptbFont);
            this.panel2.Controls.Add(this.ptbColor);
            this.panel2.Controls.Add(this.ptbSend);
            this.panel2.Controls.Add(this.rtxtdisplay);
            this.panel2.Controls.Add(this.txtcontent);
            this.panel2.Location = new System.Drawing.Point(267, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 459);
            this.panel2.TabIndex = 9;
            // 
            // ptbSend
            // 
            this.ptbSend.Image = ((System.Drawing.Image)(resources.GetObject("ptbSend.Image")));
            this.ptbSend.Location = new System.Drawing.Point(584, 412);
            this.ptbSend.Name = "ptbSend";
            this.ptbSend.Size = new System.Drawing.Size(60, 29);
            this.ptbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSend.TabIndex = 8;
            this.ptbSend.TabStop = false;
            this.ptbSend.Click += new System.EventHandler(this.pictureSend_Click);
            // 
            // ptbExit
            // 
            this.ptbExit.Image = ((System.Drawing.Image)(resources.GetObject("ptbExit.Image")));
            this.ptbExit.Location = new System.Drawing.Point(882, 0);
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
            this.ptbMinimize.Location = new System.Drawing.Point(854, 0);
            this.ptbMinimize.Name = "ptbMinimize";
            this.ptbMinimize.Size = new System.Drawing.Size(32, 32);
            this.ptbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMinimize.TabIndex = 10;
            this.ptbMinimize.TabStop = false;
            this.ptbMinimize.Click += new System.EventHandler(this.ptbMinimize_Click);
            // 
            // ptbColor
            // 
            this.ptbColor.Image = ((System.Drawing.Image)(resources.GetObject("ptbColor.Image")));
            this.ptbColor.Location = new System.Drawing.Point(6, 409);
            this.ptbColor.Name = "ptbColor";
            this.ptbColor.Size = new System.Drawing.Size(32, 32);
            this.ptbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbColor.TabIndex = 11;
            this.ptbColor.TabStop = false;
            this.ptbColor.Click += new System.EventHandler(this.ptbColor_Click);
            // 
            // ptbFont
            // 
            this.ptbFont.Image = ((System.Drawing.Image)(resources.GetObject("ptbFont.Image")));
            this.ptbFont.Location = new System.Drawing.Point(44, 409);
            this.ptbFont.Name = "ptbFont";
            this.ptbFont.Size = new System.Drawing.Size(32, 32);
            this.ptbFont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbFont.TabIndex = 12;
            this.ptbFont.TabStop = false;
            this.ptbFont.Click += new System.EventHandler(this.ptbFont_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(913, 493);
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
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFont)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtdisplay;
        private System.Windows.Forms.TextBox txtcontent;
        private System.Windows.Forms.ListBox lstFriends;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.PictureBox ptbSend;
        private System.Windows.Forms.PictureBox ptbFont;
        private System.Windows.Forms.PictureBox ptbColor;
    }
}

