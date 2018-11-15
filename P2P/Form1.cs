using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace P2P
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epMe, epFriend;
        public Form1()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            txtmeip.Text = GetLocalIP();
            //txtfriendip.Text = GetLocalIP();
        }
        string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
        
        void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epFriend);
                if(size > 0)
                {
                    byte[] ReceiveData = new byte[1464];
                    ReceiveData = (byte[])aResult.AsyncState;
                    string ReceivedMess = Encoding.Unicode.GetString(ReceiveData);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lstChat.Items.Add("Friend: " + ReceivedMess);
                    }));
                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epFriend, new AsyncCallback(MessageCallBack), buffer);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                epMe = new IPEndPoint(IPAddress.Parse(txtmeip.Text), Convert.ToInt32(txtmeport.Text));
                sck.Bind(epMe);
                epFriend = new IPEndPoint(IPAddress.Parse(txtfriendip.Text), Convert.ToInt32(txtfriendport.Text));
                sck.Connect(epFriend);
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epFriend, new AsyncCallback(MessageCallBack), buffer);
                btnstart.Text = "Connected";
                btnstart.Enabled = false;
                btnsend.Enabled = true;
                txtsend.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtsend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsend_Click(sender, new EventArgs());
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(txtsend.Text);
                sck.Send(msg);
                lstChat.Items.Add("You: " + txtsend.Text);
                txtsend.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
