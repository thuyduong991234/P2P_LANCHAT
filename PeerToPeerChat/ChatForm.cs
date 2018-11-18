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
        public bool isClose;
        public ChatForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            lstPrivChat = new List<string>();
            lstFormPrivChat = new List<PrivateChat>();

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
            txtcontent.Focus();
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
            rtxtdisplay.SelectionFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
            rtxtdisplay.AppendText(packet.MyName + ": ");
            rtxtdisplay.SelectionFont = packet.MyFont;
            rtxtdisplay.SelectionColor = packet.MyColor;
            rtxtdisplay.AppendText(packet.MyMessage + "\n");
            rtxtdisplay.ScrollToCaret();
        }

        private void InitializeSender()
        {
            // Broadcast này là địa chỉ của thằng mình send tới
            sendingClient = new UdpClient(broadcastAddress, 54545);
            sendingClient.EnableBroadcast = true;
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtcontent.Text))
            {
                byte[] data = SendPacket();
                sendingClient.Send(data, data.Length);
                txtcontent.Text = "";
            }
            txtcontent.Focus();
        }

        byte[] SendPacket()
        {
            Packet mypacket = new Packet();
            mypacket.MyName = userName;
            mypacket.MyMessage = txtcontent.Text;
            mypacket.MyFont = txtcontent.Font;
            mypacket.MyColor = txtcontent.ForeColor;
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

        private void lkbFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(fontDialog1.ShowDialog()==DialogResult.OK)
            {
                txtcontent.Font = fontDialog1.Font;
            }
        }

        private void lkbColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtcontent.ForeColor = colorDialog1.Color;
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

    }
}
