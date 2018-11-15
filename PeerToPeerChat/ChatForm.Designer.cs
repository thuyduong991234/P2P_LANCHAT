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
            this.rtxtdisplay = new System.Windows.Forms.RichTextBox();
            this.txtcontent = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.lstFriends = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lkbFont = new System.Windows.Forms.LinkLabel();
            this.lkbColor = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtdisplay
            // 
            this.rtxtdisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtdisplay.Location = new System.Drawing.Point(16, 15);
            this.rtxtdisplay.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtdisplay.Name = "rtxtdisplay";
            this.rtxtdisplay.ReadOnly = true;
            this.rtxtdisplay.Size = new System.Drawing.Size(679, 354);
            this.rtxtdisplay.TabIndex = 2;
            this.rtxtdisplay.TabStop = false;
            this.rtxtdisplay.Text = "";
            // 
            // txtcontent
            // 
            this.txtcontent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtcontent.Location = new System.Drawing.Point(16, 398);
            this.txtcontent.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontent.Name = "txtcontent";
            this.txtcontent.Size = new System.Drawing.Size(573, 23);
            this.txtcontent.TabIndex = 1;
            this.txtcontent.TabStop = false;
            this.txtcontent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontent_KeyDown);
            // 
            // btnsend
            // 
            this.btnsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsend.Location = new System.Drawing.Point(599, 396);
            this.btnsend.Margin = new System.Windows.Forms.Padding(4);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(97, 28);
            this.btnsend.TabIndex = 3;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
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
            this.lstFriends.Size = new System.Drawing.Size(184, 324);
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
            this.groupBox1.Location = new System.Drawing.Point(704, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(201, 354);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Who\'s Online";
            // 
            // lkbFont
            // 
            this.lkbFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkbFont.AutoSize = true;
            this.lkbFont.Location = new System.Drawing.Point(16, 374);
            this.lkbFont.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkbFont.Name = "lkbFont";
            this.lkbFont.Size = new System.Drawing.Size(36, 17);
            this.lkbFont.TabIndex = 6;
            this.lkbFont.TabStop = true;
            this.lkbFont.Text = "Font";
            this.lkbFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbFont_LinkClicked);
            // 
            // lkbColor
            // 
            this.lkbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkbColor.AutoSize = true;
            this.lkbColor.Location = new System.Drawing.Point(77, 374);
            this.lkbColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkbColor.Name = "lkbColor";
            this.lkbColor.Size = new System.Drawing.Size(41, 17);
            this.lkbColor.TabIndex = 7;
            this.lkbColor.TabStop = true;
            this.lkbColor.Text = "Color";
            this.lkbColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbColor_LinkClicked);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 438);
            this.Controls.Add(this.lkbColor);
            this.Controls.Add(this.lkbFont);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtcontent);
            this.Controls.Add(this.rtxtdisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatForm";
            this.Text = "PTQ CHAT";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtdisplay;
        private System.Windows.Forms.TextBox txtcontent;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.ListBox lstFriends;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem privateChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatRoomToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.LinkLabel lkbFont;
        private System.Windows.Forms.LinkLabel lkbColor;
    }
}

