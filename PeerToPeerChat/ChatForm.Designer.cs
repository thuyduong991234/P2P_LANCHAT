﻿namespace PeerToPeerChat
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
            this.button1 = new System.Windows.Forms.Button();
            this.tlpMenuIcon = new System.Windows.Forms.TableLayoutPanel();
            this.ptbConfused = new System.Windows.Forms.PictureBox();
            this.ptbBroken = new System.Windows.Forms.PictureBox();
            this.ptbAngel = new System.Windows.Forms.PictureBox();
            this.ptbBeer = new System.Windows.Forms.PictureBox();
            this.ptbAngry = new System.Windows.Forms.PictureBox();
            this.ptbCry = new System.Windows.Forms.PictureBox();
            this.txtcontent = new Khendys.Controls.ExRichTextBox();
            this.wbContent = new System.Windows.Forms.WebBrowser();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.ptbColor = new System.Windows.Forms.PictureBox();
            this.ptbSend = new System.Windows.Forms.PictureBox();
            this.ptbSendFile = new System.Windows.Forms.PictureBox();
            this.ptbFont = new System.Windows.Forms.PictureBox();
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
            this.tlpMenuIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbConfused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBroken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAngel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBeer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAngry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSendFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFont)).BeginInit();
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
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.tlpMenuIcon);
            this.panel2.Controls.Add(this.txtcontent);
            this.panel2.Controls.Add(this.wbContent);
            this.panel2.Controls.Add(this.ptbImage);
            this.panel2.Controls.Add(this.ptbColor);
            this.panel2.Controls.Add(this.ptbSend);
            this.panel2.Controls.Add(this.ptbSendFile);
            this.panel2.Controls.Add(this.ptbFont);
            this.panel2.Location = new System.Drawing.Point(197, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 476);
            this.panel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 27);
            this.button1.TabIndex = 22;
            this.button1.Text = "Emoji";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tlpMenuIcon
            // 
            this.tlpMenuIcon.AllowDrop = true;
            this.tlpMenuIcon.AutoSize = true;
            this.tlpMenuIcon.BackColor = System.Drawing.Color.Silver;
            this.tlpMenuIcon.ColumnCount = 3;
            this.tlpMenuIcon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMenuIcon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMenuIcon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMenuIcon.Controls.Add(this.ptbConfused, 0, 1);
            this.tlpMenuIcon.Controls.Add(this.ptbBroken, 0, 1);
            this.tlpMenuIcon.Controls.Add(this.ptbAngel, 0, 0);
            this.tlpMenuIcon.Controls.Add(this.ptbBeer, 1, 0);
            this.tlpMenuIcon.Controls.Add(this.ptbAngry, 2, 0);
            this.tlpMenuIcon.Controls.Add(this.ptbCry, 2, 1);
            this.tlpMenuIcon.Location = new System.Drawing.Point(212, 349);
            this.tlpMenuIcon.Name = "tlpMenuIcon";
            this.tlpMenuIcon.RowCount = 2;
            this.tlpMenuIcon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMenuIcon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMenuIcon.Size = new System.Drawing.Size(108, 78);
            this.tlpMenuIcon.TabIndex = 21;
            this.tlpMenuIcon.Visible = false;
            // 
            // ptbConfused
            // 
            this.ptbConfused.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbConfused.Image = ((System.Drawing.Image)(resources.GetObject("ptbConfused.Image")));
            this.ptbConfused.Location = new System.Drawing.Point(39, 42);
            this.ptbConfused.Name = "ptbConfused";
            this.ptbConfused.Size = new System.Drawing.Size(30, 33);
            this.ptbConfused.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbConfused.TabIndex = 27;
            this.ptbConfused.TabStop = false;
            this.ptbConfused.Click += new System.EventHandler(this.ptbConfused_Click);
            // 
            // ptbBroken
            // 
            this.ptbBroken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbBroken.Image = ((System.Drawing.Image)(resources.GetObject("ptbBroken.Image")));
            this.ptbBroken.Location = new System.Drawing.Point(3, 42);
            this.ptbBroken.Name = "ptbBroken";
            this.ptbBroken.Size = new System.Drawing.Size(30, 33);
            this.ptbBroken.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbBroken.TabIndex = 26;
            this.ptbBroken.TabStop = false;
            this.ptbBroken.Click += new System.EventHandler(this.ptbBroken_Click);
            // 
            // ptbAngel
            // 
            this.ptbAngel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbAngel.Image = ((System.Drawing.Image)(resources.GetObject("ptbAngel.Image")));
            this.ptbAngel.Location = new System.Drawing.Point(3, 3);
            this.ptbAngel.Name = "ptbAngel";
            this.ptbAngel.Size = new System.Drawing.Size(30, 33);
            this.ptbAngel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbAngel.TabIndex = 22;
            this.ptbAngel.TabStop = false;
            this.ptbAngel.Click += new System.EventHandler(this.ptbAngel_Click);
            // 
            // ptbBeer
            // 
            this.ptbBeer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbBeer.Image = ((System.Drawing.Image)(resources.GetObject("ptbBeer.Image")));
            this.ptbBeer.Location = new System.Drawing.Point(39, 3);
            this.ptbBeer.Name = "ptbBeer";
            this.ptbBeer.Size = new System.Drawing.Size(30, 33);
            this.ptbBeer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbBeer.TabIndex = 23;
            this.ptbBeer.TabStop = false;
            this.ptbBeer.Click += new System.EventHandler(this.ptbBeer_Click);
            // 
            // ptbAngry
            // 
            this.ptbAngry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbAngry.Image = ((System.Drawing.Image)(resources.GetObject("ptbAngry.Image")));
            this.ptbAngry.Location = new System.Drawing.Point(75, 3);
            this.ptbAngry.Name = "ptbAngry";
            this.ptbAngry.Size = new System.Drawing.Size(30, 33);
            this.ptbAngry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbAngry.TabIndex = 24;
            this.ptbAngry.TabStop = false;
            this.ptbAngry.Click += new System.EventHandler(this.ptbAngry_Click);
            // 
            // ptbCry
            // 
            this.ptbCry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbCry.Image = ((System.Drawing.Image)(resources.GetObject("ptbCry.Image")));
            this.ptbCry.Location = new System.Drawing.Point(75, 42);
            this.ptbCry.Name = "ptbCry";
            this.ptbCry.Size = new System.Drawing.Size(30, 33);
            this.ptbCry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbCry.TabIndex = 25;
            this.ptbCry.TabStop = false;
            this.ptbCry.Click += new System.EventHandler(this.ptbCry_Click);
            // 
            // txtcontent
            // 
            this.txtcontent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcontent.HiglightColor = Khendys.Controls.RtfColor.White;
            this.txtcontent.Location = new System.Drawing.Point(4, 433);
            this.txtcontent.Name = "txtcontent";
            this.txtcontent.Size = new System.Drawing.Size(460, 29);
            this.txtcontent.TabIndex = 20;
            this.txtcontent.Text = "";
            this.txtcontent.TextColor = Khendys.Controls.RtfColor.Black;
            this.txtcontent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontent_KeyDown_1);
            // 
            // wbContent
            // 
            this.wbContent.Location = new System.Drawing.Point(0, 0);
            this.wbContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbContent.Name = "wbContent";
            this.wbContent.Size = new System.Drawing.Size(540, 394);
            this.wbContent.TabIndex = 19;
            // 
            // ptbImage
            // 
            this.ptbImage.Image = ((System.Drawing.Image)(resources.GetObject("ptbImage.Image")));
            this.ptbImage.Location = new System.Drawing.Point(115, 398);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(35, 34);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage.TabIndex = 18;
            this.ptbImage.TabStop = false;
            // 
            // ptbColor
            // 
            this.ptbColor.Image = ((System.Drawing.Image)(resources.GetObject("ptbColor.Image")));
            this.ptbColor.Location = new System.Drawing.Point(4, 400);
            this.ptbColor.Name = "ptbColor";
            this.ptbColor.Size = new System.Drawing.Size(32, 27);
            this.ptbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbColor.TabIndex = 17;
            this.ptbColor.TabStop = false;
            this.ptbColor.Click += new System.EventHandler(this.ptbColor_Click);
            // 
            // ptbSend
            // 
            this.ptbSend.Image = ((System.Drawing.Image)(resources.GetObject("ptbSend.Image")));
            this.ptbSend.Location = new System.Drawing.Point(470, 416);
            this.ptbSend.Name = "ptbSend";
            this.ptbSend.Size = new System.Drawing.Size(59, 53);
            this.ptbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSend.TabIndex = 16;
            this.ptbSend.TabStop = false;
            this.ptbSend.Click += new System.EventHandler(this.pictureSend_Click);
            // 
            // ptbSendFile
            // 
            this.ptbSendFile.Image = ((System.Drawing.Image)(resources.GetObject("ptbSendFile.Image")));
            this.ptbSendFile.Location = new System.Drawing.Point(76, 400);
            this.ptbSendFile.Name = "ptbSendFile";
            this.ptbSendFile.Size = new System.Drawing.Size(35, 27);
            this.ptbSendFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSendFile.TabIndex = 13;
            this.ptbSendFile.TabStop = false;
            this.ptbSendFile.Click += new System.EventHandler(this.ptbSendFile_Click);
            // 
            // ptbFont
            // 
            this.ptbFont.Image = ((System.Drawing.Image)(resources.GetObject("ptbFont.Image")));
            this.ptbFont.Location = new System.Drawing.Point(42, 400);
            this.ptbFont.Name = "ptbFont";
            this.ptbFont.Size = new System.Drawing.Size(32, 27);
            this.ptbFont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbFont.TabIndex = 12;
            this.ptbFont.TabStop = false;
            this.ptbFont.Click += new System.EventHandler(this.ptbFont_Click);
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
            this.panel2.PerformLayout();
            this.tlpMenuIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbConfused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBroken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAngel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBeer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAngry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSendFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFont)).EndInit();
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
        private System.Windows.Forms.PictureBox ptbFont;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox ptbAva;
        private System.Windows.Forms.PictureBox ptbSendFile;
        private System.Windows.Forms.PictureBox ptbSend;
        private System.Windows.Forms.PictureBox ptbColor;
        private System.Windows.Forms.PictureBox ptbImage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstFriends;
        private System.Windows.Forms.WebBrowser wbContent;
        private Khendys.Controls.ExRichTextBox txtcontent;
        private System.Windows.Forms.PictureBox ptbAngel;
        private System.Windows.Forms.TableLayoutPanel tlpMenuIcon;
        private System.Windows.Forms.PictureBox ptbConfused;
        private System.Windows.Forms.PictureBox ptbBroken;
        private System.Windows.Forms.PictureBox ptbBeer;
        private System.Windows.Forms.PictureBox ptbAngry;
        private System.Windows.Forms.PictureBox ptbCry;
        private System.Windows.Forms.Button button1;
    }
}

