/*
 * Lỗi ở requiredchat không hứng dc new_requirechat
*/

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
using Package;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using P2P;
namespace PeerToPeerChat
{
    public partial class ChatForm : Form
    {
        delegate void AddMessage(Packet packet);
        string userName;
        const int port = 54545;
        string broadcastAddress = "255.255.255.255";
        UdpClient receivingClient;
        UdpClient sendingClient;
        UdpClient requirePrivChat;
        Thread receivingThread;
        List<string> lstOnline;
        string myPort;
        Packet RequirePacket;
        List<string> lstPrivChat;
        List<PrivateChat> lstFormPrivChat;
        List<Object> ChatLog;
        public bool isClose;
        public ChatForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            lstPrivChat = new List<string>();
            lstFormPrivChat = new List<PrivateChat>();
            ChatLog = new List<object>();

        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            lstOnline = new List<string>();
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.UserName == "")
                    this.Close();
                else
                {
                    userName = loginForm.UserName;
                    this.Show();
                }
            }
            InitializeSender();
            InitializeReceiver();
            SendName(TypePacket.SEND_INFO_USER_1);
            txtsend.Focus();
            wbContent.DocumentText = "<html><body style=\"background-color:rgb(217,215,206)\"> </body></html>";
        }
        private void InitializeRequirer(string ip, byte[] buffer)
        {
            requirePrivChat = new UdpClient(ip, 54545);
            requirePrivChat.EnableBroadcast = true;
            requirePrivChat.Send(buffer,buffer.Length);
        }
        private void InitializeReceiver()
        {
            receivingClient = new UdpClient(port);
            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void Receiver()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            AddMessage messageDelegate = MessageReceived;
            while(true)
            {
                byte[] data = receivingClient.Receive(ref endPoint);
                Packet receivePacket = DeSerialize(data);
                if (receivePacket.MyType==TypePacket.SEND_INFO_USER_1 && receivePacket.MyName != userName)
                {
                    messageDelegate = MessageName;
                    Invoke(messageDelegate, receivePacket);
                }
                else if(receivePacket.MyType == TypePacket.SEND_INFO_USER_2 && receivePacket.MyName != userName)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lstFriends.Items.Add(receivePacket.MyName);
                        lstOnline.Add(receivePacket.MyName + " " + receivePacket.MyIP + " " + receivePacket.MyPort);
                    }));
                }
                else if(receivePacket.MyType == TypePacket.MESSAGE)
                {
                    messageDelegate = MessageReceived;
                    Invoke(messageDelegate, receivePacket);
                }
                else if (receivePacket.MyType == TypePacket.REQUIRE_CHAT)
                {
                    messageDelegate = AcceptRequireChat;
                    Invoke(messageDelegate, receivePacket);
                }
                else if(receivePacket.MyType == TypePacket.CLOSING)
                {
                    messageDelegate = ClosingMethod;
                    Invoke(messageDelegate, receivePacket);
                }
            }
        }
        private void ClosingMethod(Packet packet)
        {
            for(int i=0; i< lstFormPrivChat.Count;i++)
            {
                string name = lstFormPrivChat[i].Text;
                if(packet.MyName == name)
                {
                    lstFormPrivChat[i].firstsend = true;
                }
            }
        }
        private void AcceptRequireChat(Packet packet)
        {
            PrivateChat priv = new PrivateChat();
            bool isExist = false;
            foreach(PrivateChat name in lstFormPrivChat)
            {
                if(name.Text == packet.MyName)
                {
                    isExist = true;
                    priv = name;
                    break;
                }
            }
            if (!isExist)
            {
                for (int i = 0; i < lstFriends.Items.Count; i++)
                {
                    if (lstFriends.Items[i].ToString() == packet.MyName)
                    {
                        lstFriends.Items[i] = lstFriends.Items[i] + " " + "(Bạn có tin nhắn mới...)";
                    }
                }
                RequirePacket = new Packet();
                RequirePacket.MyMessage = packet.MyMessage;
                RequirePacket.MyColor = packet.MyColor;
                RequirePacket.MyFont = packet.MyFont;
            }
            else
                return;
        }
        private void MessageName(Packet packet)
        {
            lstFriends.Items.Add(packet.MyName);
            lstOnline.Add(packet.MyName + " " + packet.MyIP + " " + packet.MyPort);
            SendName(TypePacket.SEND_INFO_USER_2);
        }
        private void MessageReceived(Packet packet)
        {
            //rtxtdisplay.SelectionFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
            //rtxtdisplay.AppendText(packet.MyName + ": ");
            //rtxtdisplay.SelectionFont = packet.MyFont;
            //rtxtdisplay.SelectionColor = packet.MyColor;
            //rtxtdisplay.AppendText(packet.MyMessage + "\n");
            //rtxtdisplay.ScrollToCaret();
            if (packet.MyName == userName)

            {
                Message rmess = new Message(packet, Type.SENDER);
                ChatLog.Add(rmess);
            }
            else
            {
                Message rmess = new Message(packet, Type.RECEIVER);
                ChatLog.Add(rmess);
            }
            RefreshWeb();
        }

        private void InitializeSender()
        {
            // Broadcast này là địa chỉ của thằng mình send tới
            sendingClient = new UdpClient(broadcastAddress, 54545);
            sendingClient.EnableBroadcast = true;
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsend.Text))
            {
                byte[] data = SendPacket();
                sendingClient.Send(data, data.Length);
                txtsend.Text = "";
            }
            txtsend.Focus();
        }

        byte[] SendPacket()
        {
            Packet mypacket = new Packet();
            mypacket.MyName = userName;
            mypacket.MyMessage = txtsend.Text;
            mypacket.MyFont = txtsend.Font;
            mypacket.MyColor = txtsend.ForeColor;
            mypacket.MyType = TypePacket.MESSAGE;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
        }

        private Packet DeSerialize(byte[] data)
        {
            Package.Packet myPacket = new Packet();
            MemoryStream str = new MemoryStream(data);
            BinaryFormatter bformat = new BinaryFormatter();
            myPacket = (Packet)bformat.Deserialize(str);
            return myPacket;
        }

        string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        public void SendName(TypePacket type)
        {
            Packet mypacket = new Packet();
            this.myPort = mypacket.MyPort;
            mypacket.MyIP = GetLocalIP();
            mypacket.MyName = userName;
            mypacket.MyType = type;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            sendingClient.Send(data, data.Length);
        }
       

        private void txtcontent_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnsend_Click(sender, new EventArgs());
            }
        }

        void InitializePrivateChat(string Name,string IP, string Port)
        {
            try
            {
                PrivateChat PrivCchat = new PrivateChat();
                PrivCchat.RequireChat += new_requireChat;
                PrivCchat.CloseChat += new_closeChat;
                PrivCchat.friendName = Name;
                PrivCchat.meIP = GetLocalIP();
                PrivCchat.friendIP = IP;
                PrivCchat.mePort = this.myPort;
                PrivCchat.friendPort = Port;
                //
                lstPrivChat.Add(Name);
                lstFormPrivChat.Add(PrivCchat);
                PrivCchat.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void new_closeChat(object sender, CloseEvent e)
        {
            // GỬI THÔNG BÁO ĐÓNG CHO BÊN BẠN

            Packet closingpck = new Packet();
            closingpck.MyType = TypePacket.CLOSING;
            closingpck.MyName = userName;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, closingpck);
            byte[] data = new byte[1024];
            data = str.ToArray();
            InitializeRequirer(e.FirstIP, data);
            lstPrivChat.Remove(e.friendName);
            for(int i=0; i < lstFormPrivChat.Count;i++)
            {
                if (lstFormPrivChat[i].Text == e.friendName)
                    lstFormPrivChat.Remove(lstFormPrivChat[i]);
            }
        }

        void InitializeRequirePrivateChat(string Name, string IP, string Port, Packet pck, int num)
        {
            try
            {
                PrivateChat PrivCchat = new PrivateChat(pck);
                PrivCchat.RequireChat += new_requireChat;
                PrivCchat.CloseChat += new_closeChat;
                PrivCchat.friendName = Name;
                PrivCchat.meIP = GetLocalIP();
                PrivCchat.friendIP = IP;
                PrivCchat.mePort = this.myPort;
                PrivCchat.friendPort = Port;
                PrivCchat.Show();
                lstFormPrivChat.Add(PrivCchat);
                // xoa dong status
                lstFriends.Items[num] = Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void new_requireChat(object sender, RequireEvent e)
        { 
            Packet mypacket = new Packet();
            mypacket.MyName = userName;
            mypacket.MyType = TypePacket.REQUIRE_CHAT;
            mypacket.MyMessage = e.FirstMess;
            mypacket.MyFont = e.FirstFont;
            mypacket.MyColor = e.FirstColor;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            InitializeRequirer(e.FirstIP, data);
        }

        private void lstFriends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int num = 0;
                string[] Name_IP;
                string IP;
                string[] require = null;
                if (lstFriends.SelectedItem != null)
                {
                    num = lstFriends.IndexFromPoint(e.Location);
                    string ckrequire = lstFriends.SelectedItem as string;
                    require = ckrequire.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }
                Name_IP = lstOnline[num].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                IP = Name_IP[1];
                string Port = Name_IP[2];

                if (require.Length > 1)
                {
                    InitializeRequirePrivateChat(Name_IP[0], IP, Port, RequirePacket, num);
                }
                else
                {
                    InitializePrivateChat(Name_IP[0], IP, Port);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy tên nào bạn chọn, vui lòng chọn đúng tên!");
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // move form
        protected override void OnLoad(EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                this.MouseDown += new MouseEventHandler(LoginForm_MouseDown);
                this.MouseMove += new MouseEventHandler(LoginForm_MouseMove);
                this.MouseUp += new MouseEventHandler(LoginForm_MouseUp);
            }

            base.OnLoad(e);
        }
        public Point downPoint = Point.Empty;
        void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = new Point(e.X, e.Y);
        }

        void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
            {
                return;
            }
            Point location = new Point(
                this.Left + e.X - downPoint.X,
                this.Top + e.Y - downPoint.Y);
            this.Location = location;
        }

        void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = Point.Empty;
        }

        void RefreshWeb()
        {
            string start = @"<!DOCTYPE html><html><head><title>Client</title><style type='text/css'>
	                         body{font-family:  'Segoe UI', tahoma, sans-serif;background-color:rgb(217,215,206);}
	                        .message{padding: 3px;margin: 3px;text-align: left;cursor:default;word-wrap:break-word;}
	                        .mine{margin-left: 100px;background: rgb(218,233,255);text-align:right;}
	                        .remote{margin-right: 100px;background: rgb(255,255,255);}
                            </style>
                            <script language='javascript'>
                                window.onload=toBottom;
                                function toBottom(){ window.scrollTo(0, document.body.scrollHeight);}
                            </script></head><body>";
            string end = @"</body></html>";
            string body = "";
            foreach (Message x in ChatLog)
            {
                if (x.who == Type.SENDER)
                {
                    body += "<div class='message mine' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>"  + "<span><strong>" + x.pack.MyName + "</strong></span>" + "<br>"   + x.pack.MyMessage + "</div>\n";
                }
                else
                {
                    body += "<div class='message remote' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>" + "<h6>" + x.pack.MyName + "</h6>"  + x.pack.MyMessage + "</div>\n";

                }
            }
            wbContent.Document.Write(start + body + end);
            wbContent.Refresh();
            txtsend.Text = "";
            txtsend.Focus();
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtsend.Font = fontDialog1.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtsend.ForeColor = colorDialog1.Color;
            }
        }
    }
}
