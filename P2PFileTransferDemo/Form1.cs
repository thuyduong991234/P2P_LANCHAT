using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace P2PDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = dlg.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            button2.Enabled = false;
            
            Thread thread = new Thread(ThreadListen);
            thread.Name = "ThreadListen";
            thread.Start();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = dlg.FileName;
            }
        }

        private void ThreadListen()
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(textBox2.Text)));
            listenSocket.Listen(4);

            while (true)
            {
                Socket socket = listenSocket.Accept();
                Thread thread = new Thread(ThreadRecvData);
                thread.Name = "ThreadRecvData";
                thread.Start(socket);
            }
        }

        private void ThreadRecvData(object obj)
        {
            textBox5.Enabled = false;
            
            Socket socket = (Socket)obj;
            socket.NoDelay = true;
            
            if (MessageBox.Show("Peer is sending a file to you. Do you want to receive it ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                socket.Close();
                textBox5.Enabled = true;
                return;
            }

            string saveFileName = textBox5.Text;

            bool bTranferOk = true;
            FileStream fs = null;
            Form2 frm = new Form2(socket);

            frm.label1.Text = "Receiving file \"" + saveFileName + "\"";
            frm.Visible = true;
            Application.DoEvents();

            try
            {
                fs = File.Create(saveFileName);
                byte[] buf = new byte[32 * 1024];
                int nr = socket.Receive(buf, sizeof(ulong), SocketFlags.None);

                MemoryStream ms = new MemoryStream(buf);
                BinaryReader br = new BinaryReader(ms);
                ulong fileSize = br.ReadUInt64();
                br.Close();
                ms.Close();

                frm.progressBar1.Minimum = 0;
                frm.progressBar1.Maximum = 1000;
                Application.DoEvents();

                ulong pos = 0;
                while (pos < fileSize)
                {
                    nr = socket.Receive(buf);
                    if (nr <= 0)
                    {
                        throw new Exception("Receive 0 byte");
                    }

                    pos += (ulong)nr;
                    fs.Write(buf, 0, nr);

                    frm.progressBar1.Value = (int)(((double)frm.progressBar1.Maximum * (double)pos) / (double)fileSize + 0.5);
                    Application.DoEvents();
                }

            }
            catch (Exception e)
            {
                bTranferOk = false;
                MessageBox.Show(e.Message, "File Receiving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frm.SafeClose();

            if (fs != null)
            {
                try { fs.Close(); }
                catch (Exception) { }
            }

            socket.Close();

            if (!bTranferOk)
            {
                try { File.Delete(saveFileName); }
                catch (Exception) { }
            }
            else
            {
                MessageBox.Show("Receive complete !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBox5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ThreadSendData);
            thread.Name = "ThreadSendData";
            thread.Start();
        }

        private void ThreadSendData()
        {
            button1.Enabled = false;
            textBox4.Enabled = false;

            FileStream fs = null;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.NoDelay = true;

            bool bSendOk = true;
            Form2 frm = new Form2(socket);

            frm.label1.Text = "Sending file \"" + textBox4.Text + "\"";
            frm.Visible = true;
            Application.DoEvents();
            
            try
            {
                FileInfo fi = new FileInfo(textBox4.Text);
                ulong fileSize = (ulong)fi.Length;

                frm.progressBar1.Minimum = 0;
                frm.progressBar1.Maximum = 1000;
                Application.DoEvents();

                byte[] buf = new byte[32 * 1024];
                MemoryStream ms = new MemoryStream(buf);
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(fileSize);
                bw.Close();
                ms.Close();

                fs = File.OpenRead(textBox4.Text);

                socket.Connect(new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox3.Text)));
                int ns = socket.Send(buf, sizeof(ulong), SocketFlags.None);
                ulong pos = 0;

                while (pos < fileSize)
                {
                    int nr = fs.Read(buf, 0, buf.Length);
                    if (nr <= 0)
                    {
                        break;
                    }

                    pos += (ulong)nr;
                    ns = socket.Send(buf, nr, SocketFlags.None);

                    frm.progressBar1.Value = (int)(((double)frm.progressBar1.Maximum * (double)pos) / (double)fileSize + 0.5);
                    Application.DoEvents();
                }

            }
            catch (Exception e)
            {
                bSendOk = false;
                MessageBox.Show(e.Message, "File Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frm.SafeClose();

            if (fs != null)
            {
                try { fs.Close(); }
                catch (Exception) { }
            }

            socket.Close();

            if (bSendOk)
            {
                MessageBox.Show("Send complete !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            button1.Enabled = true;
            textBox4.Enabled = true;

        }


    }
}
