namespace P2P
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmeport = new System.Windows.Forms.TextBox();
            this.txtmeip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfriendport = new System.Windows.Forms.TextBox();
            this.txtfriendip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.txtsend = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmeport);
            this.groupBox1.Controls.Add(this.txtmeip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Me";
            // 
            // txtmeport
            // 
            this.txtmeport.Location = new System.Drawing.Point(56, 63);
            this.txtmeport.Name = "txtmeport";
            this.txtmeport.Size = new System.Drawing.Size(127, 20);
            this.txtmeport.TabIndex = 6;
            // 
            // txtmeip
            // 
            this.txtmeip.Location = new System.Drawing.Point(56, 26);
            this.txtmeip.Name = "txtmeip";
            this.txtmeip.Size = new System.Drawing.Size(127, 20);
            this.txtmeip.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtfriendport);
            this.groupBox2.Controls.Add(this.txtfriendip);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(242, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Friend";
            // 
            // txtfriendport
            // 
            this.txtfriendport.Location = new System.Drawing.Point(57, 63);
            this.txtfriendport.Name = "txtfriendport";
            this.txtfriendport.Size = new System.Drawing.Size(127, 20);
            this.txtfriendport.TabIndex = 7;
            // 
            // txtfriendip
            // 
            this.txtfriendip.Location = new System.Drawing.Point(57, 26);
            this.txtfriendip.Name = "txtfriendip";
            this.txtfriendip.Size = new System.Drawing.Size(127, 20);
            this.txtfriendip.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP";
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.Location = new System.Drawing.Point(21, 142);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(509, 134);
            this.lstChat.TabIndex = 2;
            // 
            // txtsend
            // 
            this.txtsend.Location = new System.Drawing.Point(21, 298);
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(421, 20);
            this.txtsend.TabIndex = 3;
            this.txtsend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsend_KeyDown);
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(455, 296);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 23);
            this.btnsend.TabIndex = 4;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(455, 61);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(75, 23);
            this.btnstart.TabIndex = 5;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 340);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtsend);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmeport;
        private System.Windows.Forms.TextBox txtmeip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtfriendport;
        private System.Windows.Forms.TextBox txtfriendip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtsend;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Button btnstart;
    }
}

