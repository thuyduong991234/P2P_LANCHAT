

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
        SendType Status = SendType.MESSAGE;
        string userName;
        const int port = 54545;
        string broadcastAddress = "255.255.255.255";
        UdpClient receivingClient;
        UdpClient sendingClient;
        UdpClient requirePrivChat;
        Thread receivingThread;
        List<string> lstOnline;
        string myPort;
        List<string> lstPrivChat;
        List<PrivateChat> lstFormPrivChat;
        List<Object> ChatLog;
        Dictionary<string, string> EmojiList;
        public bool isClose;
        string saveFileName = "";
        TypePacket curType = TypePacket.NONE;
        string curSender = "";
        string curIP = "";
        public ChatForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            lstPrivChat = new List<string>();
            lstFormPrivChat = new List<PrivateChat>();
            ChatLog = new List<object>();
            EmojiList = new Dictionary<string, string>();
            string path = "";
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "cuoi.png");
            EmojiList.Add(":)", "<img src=\"" + path + "\" style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "buon.png");
            EmojiList.Add(":(", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "so.png");
            EmojiList.Add(":-s", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "yeu.png");
            EmojiList.Add("x-)", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "like.png");
            EmojiList.Add("(y)", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "ngacnhien.png");
            EmojiList.Add(":o", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "khoc.png");
            EmojiList.Add(";-(", "<img src=\"" + path + "\"style='width:20px;height:20px'");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "hun.png");        
            EmojiList.Add("(p)", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "gian.png");
            EmojiList.Add(":-t", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            lstOnline = new List<string>();
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.UserName == "")
                {
                    this.Close();
                    return;
                }
                else
                {
                    userName = loginForm.UserName;
                    lblusername.Text = userName;
                    InitializeSender();
                    InitializeReceiver();
                    this.Show();
                    txtsend.Focus();
                    //pictureBox12.Image = Image.FromFile("yeu.png");
                    //webBrowser1.DocumentText = "<html><body style=\"background-color:rgb(217,215,206)\"><img src='..\\..\\Emoji\\buon.png'></body></html>";
                    wbContent.DocumentText = "<html><body style=\"background-color:rgb(217,215,206)\"><span></span></body></html>";
                }
            }
           
            this.Invoke((MethodInvoker)(() =>
            {
                SendName(TypePacket.SEND_INFO_USER_1);
            }));
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
            while (true)
            {
                #region Nhan File
                if (curType == TypePacket.SEND_FILE)
                {
                    if (curIP == GetLocalIP())
                        continue;
                    byte[] data = receivingClient.Receive(ref endPoint);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        SaveFileDialog saveFileDlog1 = new SaveFileDialog();
                        saveFileDlog1.FileName = saveFileName;

                        if (saveFileDlog1.ShowDialog() == DialogResult.OK)
                        {
                            saveFileName = saveFileDlog1.FileName;
                        }
                    }));
                    bool bTranferOk = true;
                    FileStream fs = null;
                    try
                    {
                        fs = File.Create(saveFileName);
                        fs.Write(data, 0, data.Length);

                    }
                    catch (Exception e)
                    {
                        bTranferOk = false;
                        MessageBox.Show(e.Message, "Nhận file bị lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch (Exception) { }
                    }
                    if (!bTranferOk)
                    {
                        try { File.Delete(saveFileName); }
                        catch (Exception) { }
                    }
                    else
                    {
                        string[] extension;
                        extension = saveFileName.Split('.');
                        this.Invoke((MethodInvoker)(() =>
                        {
                            Packet rpck = new Packet();
                            rpck.MyName = curSender;
                            rpck.MyMessage = "<a href='" + saveFileName.Replace(":", "(~*)") + "'>" + (('.' + extension[1] == ".jpg" || '.' + extension[1] == ".png" || extension[1] == ".PNG") ? "<img src='" + saveFileName + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(saveFileName) + "</b></a>";
                            Message fmess = new Message(rpck, Type.RECEIVER);
                            ChatLog.Add(fmess);
                            RefreshWeb();
                        }));
                    }
                    curType = TypePacket.NONE;
                    curIP = "";
                    curSender = "";
                }
                #endregion
                #region Nhan Image
                else if(curType == TypePacket.SEND_IMAGE)
                {
                    if (curIP != GetLocalIP())
                        continue;
                    byte[] data = receivingClient.Receive(ref endPoint);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        SaveFileDialog saveFileDlog1 = new SaveFileDialog();
                        saveFileDlog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                        saveFileDlog1.FileName = saveFileName;
                        saveFileName = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\" + saveFileDlog1.FileName;
                    }));
                    bool bTranferOk = true;
                    FileStream fs = null;
                    try
                    {
                        fs = File.Create(saveFileName);
                        fs.Write(data, 0, data.Length);
                    }
                    catch (Exception e)
                    {
                        bTranferOk = false;
                        MessageBox.Show(e.Message, "Nhận Image bị lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch (Exception) { }
                    }
                    if (!bTranferOk)
                    {
                        try { File.Delete(saveFileName); }
                        catch (Exception) { }
                    }
                    else
                    {
                        string[] extension;
                        extension = saveFileName.Split('.');
                        Packet rpck = new Packet();
                        rpck.MyName = curSender;
                        rpck.MyMessage = "<a href='" + saveFileName.Replace(":", "(~*)") + "'>" + (('.' + extension[1] == ".jpg" || '.' + extension[1] == ".png" || extension[1] == ".PNG") ? "<img src='" + saveFileName + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(saveFileName) + "</b></a>";
                        Message fmess = new Message(rpck, Type.RECEIVER);
                        ChatLog.Add(fmess);
                        RefreshWeb();

                    }
                    curType = TypePacket.NONE;
                    curIP = "";
                    curSender = "";
                }
                #endregion
                #region Nhan Message binh thuong
                else
                {
                    byte[] data = receivingClient.Receive(ref endPoint);
                    Packet receivePacket = DeSerialize(data);
                    if (receivePacket.MyType == TypePacket.SEND_INFO_USER_1 && receivePacket.MyName != userName)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            messageDelegate = MessageName;
                            Invoke(messageDelegate, receivePacket);
                        }));

                    }
                    else if (receivePacket.MyType == TypePacket.SEND_INFO_USER_2 && receivePacket.MyName != userName)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            bool ck = true;
                            for (int i = 0; i < lstOnline.Count; i++)
                            {
                                string[] ck_lstOnline = lstOnline[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (ck_lstOnline[1] == receivePacket.MyIP)
                                    ck = false;

                            }
                            if (ck)
                            {
                                lstFriends.Items.Add(receivePacket.MyName);
                                lstOnline.Add(receivePacket.MyName + " " + receivePacket.MyIP);
                            }
                        }));
                    }
                    else if (receivePacket.MyType == TypePacket.MESSAGE)
                    {
                        if (receivePacket.MyMessage == "file#")
                        {
                            curType = TypePacket.SEND_FILE;
                            curSender = receivePacket.MyName;
                            curIP = receivePacket.MyIP;
                        }
                        else if(receivePacket.MyMessage == "image#")
                        {
                            curType = TypePacket.SEND_IMAGE;
                            curSender = receivePacket.MyName;
                            curIP = receivePacket.MyIP;
                        }
                        else if(receivePacket.MyMessage != "file#" && receivePacket.MyMessage != "image#" )
                        {
                            messageDelegate = MessageReceived;
                            Invoke(messageDelegate, receivePacket);
                        }
                    }
                    else if (receivePacket.MyType == TypePacket.REQUIRE_CHAT)
                    {
                        messageDelegate = AcceptRequireChat;
                        Invoke(messageDelegate, receivePacket);
                    }
                    else if (receivePacket.MyType == TypePacket.OUT_CHAT)
                    {
                        messageDelegate = ClosingMethod;
                        Invoke(messageDelegate, receivePacket);
                    }
                }
                #endregion
            }
        }
        
        private void ClosingMethod(Packet packet)
        {
            for(int i=0; i< lstOnline.Count;i++)
            {
                string[] IP = lstOnline[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (packet.MyIP == IP[1])
                {
                    lstFriends.Items.RemoveAt(i);
                    lstOnline.RemoveAt(i);
                    Message clsmess = new Message(packet, Type.CLOSER);
                    ChatLog.Add(clsmess);
                    RefreshWeb();
                }
            }
        }
        private void AcceptRequireChat(Packet packet)
        {
            bool isExist = false;
            foreach(PrivateChat name in lstFormPrivChat)
            {
                if(name.Text == packet.MyName)
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                Random rd = new Random();
                PrivateChat priv = new PrivateChat(packet, 2, packet.MyPort, GetLocalIP(), rd.Next(10000, 60000) + "");
                priv.friendName = packet.MyName;
                priv.friendIP = packet.MyIP;
                lstFormPrivChat.Add(priv);
                priv.Show();
            }
            else
                return;
        }
        private void MessageName(Packet packet)
        {
            bool ck = true;
            for(int i=0; i < lstOnline.Count;i++)
            {
                string[] ck_lstOnline = lstOnline[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (ck_lstOnline[1] == packet.MyIP)
                    ck = false;
            }
            if(ck)
            {
                lstFriends.Items.Add(packet.MyName);
                lstOnline.Add(packet.MyName + " " + packet.MyIP);
            }
            Packet rspck = new Packet();
            rspck.MyIP = GetLocalIP();
            rspck.MyType = TypePacket.SEND_INFO_USER_2;
            rspck.MyName = userName;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, rspck);
            byte[] data = new byte[1024];
            data = str.ToArray();
            InitializeRequirer(packet.MyIP,data);
            //SendName(TypePacket.SEND_INFO_USER_2);
        }
        private void MessageReceived(Packet packet)
        {
            ////
            string AddEmoji = packet.MyMessage;
            AddEmoji = AddEmoji.Replace(":)",EmojiList[":)"]);
            AddEmoji = AddEmoji.Replace(":(",EmojiList[":("]);
            AddEmoji = AddEmoji.Replace(":-s", EmojiList[":-s"]);
            AddEmoji = AddEmoji.Replace("x-)", EmojiList["x-)"]);
            AddEmoji = AddEmoji.Replace("(y)", EmojiList["(y)"]);
            AddEmoji = AddEmoji.Replace(":o", EmojiList[":o"]);
            AddEmoji = AddEmoji.Replace(";-(", EmojiList[";-("]);
            AddEmoji = AddEmoji.Replace("(p)", EmojiList["(p)"]);
            AddEmoji = AddEmoji.Replace(":-t", EmojiList[":-t"]);
            packet.MyMessage = AddEmoji;
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
                if (Status == SendType.MESSAGE)
                {
                    byte[] data = SendPacket();
                    sendingClient.Send(data, data.Length);
                    txtsend.Text = "";
                }
                else if (Status == SendType.FILE)
                {
                    FileStream fs = null;
                    bool bSendOk = true;
                    string extension = "";
                    try
                    {
                        FileInfo fi = new FileInfo(txtsend.Text);  
                        byte[] buf = new byte[64*1024];                    
                        fs = File.OpenRead(txtsend.Text);
                        long filesize = fi.Length;
                        byte[] buf1 = SendTypeFile();
                        sendingClient.Send(buf1, buf1.Length);

                        //Send size cua file
                        int nr = fs.Read(buf, 0, (int)filesize);
                        sendingClient.Send(buf, nr);
                    }
                    catch (Exception exx)
                    {
                        bSendOk = false;
                        MessageBox.Show(exx.Message, "File Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch (Exception) { }
                    }
                    if (bSendOk)
                    {
                        MessageBox.Show("Gửi Thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Packet fpck = new Packet();
                        fpck.MyName = userName;
                        fpck.MyMessage = "<a href='" + txtsend.Text.Replace(":", "(~*)") + "'>" + ((extension == ".jpg" || extension == ".png" || extension == ".PNG") ? "<img src='" + txtsend.Text + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(txtsend.Text) + "</b></a>";
                        Message fmess = new Message(fpck, Type.SENDER);
                        ChatLog.Add(fmess);
                        RefreshWeb();
                    }
                    Status = SendType.MESSAGE;
                }
                else if(Status == SendType.IMAGE)
                {
                    FileStream fs = null;
                    bool bSendOk = true;
                    string extension = "";
                    try
                    {
                        FileInfo fi = new FileInfo(txtsend.Text);
                        byte[] buf = new byte[64 * 1024];
                        fs = File.OpenRead(txtsend.Text);
                        long filesize = fi.Length;
                        byte[] buf1 = SendTypeImage();
                        sendingClient.Send(buf1, buf1.Length);

                        //Send size cua file
                        int nr = fs.Read(buf, 0, (int)filesize);
                        sendingClient.Send(buf, nr);
                    }
                    catch (Exception exx)
                    {
                        bSendOk = false;
                        MessageBox.Show(exx.Message, "Gửi ảnh lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch (Exception) { }
                    }
                    if (bSendOk)
                    {
                        MessageBox.Show("Gửi Thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Packet fpck = new Packet();
                        fpck.MyName = userName;
                        fpck.MyMessage = "<a href='" + txtsend.Text.Replace(":", "(~*)") + "'>" + ((extension == ".jpg" || extension == ".png" || extension == ".PNG") ? "<img src='" + txtsend.Text + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(txtsend.Text) + "</b></a>";
                        Message fmess = new Message(fpck, Type.SENDER);
                        ChatLog.Add(fmess);
                        RefreshWeb();
                    }
                    Status = SendType.MESSAGE;
                }
                txtsend.Focus();
                txtsend.Text = "";

            }
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

        byte[] SendTypeFile()
        {
            Packet mypacket = new Packet();
            mypacket.MyType = TypePacket.MESSAGE;
            mypacket.MyMessage = "file#";
            mypacket.MyName = userName;
            mypacket.MyIP = GetLocalIP();
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
        }

        byte[] SendTypeImage()
        {
            Packet mypacket = new Packet();
            mypacket.MyType = TypePacket.MESSAGE;
            mypacket.MyMessage = "image#";
            mypacket.MyName = userName;
            mypacket.MyIP = GetLocalIP();
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
            //this.myPort = mypacket.MyPort;
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

        void InitializePrivateChat(string Name,string IP, string Port, Packet hipck)
        {
            try
            {
                PrivateChat PrivCchat = new PrivateChat(hipck,1);
                PrivCchat.friendName = Name;
                PrivCchat.meIP = GetLocalIP();
                PrivCchat.friendIP = IP;
                PrivCchat.mePort = this.myPort;
                PrivCchat.friendPort = Port;
                //
                lstFormPrivChat.Add(PrivCchat);
                PrivCchat.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       
        private void lstFriends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int num = 0;
                string[] Details;
                if(lstFriends.SelectedItem != null)
                {
                    num = lstFriends.IndexFromPoint(e.Location);
                    Details = lstOnline[num].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // Gửi "Hi" đến cho ChatForm bên kia
                    Random rd = new Random();
                    Packet hipck = new Packet();
                    hipck.MyMessage = "Xin chào!";
                    hipck.MyType = TypePacket.REQUIRE_CHAT;
                    hipck.MyName = userName;
                    this.myPort = hipck.MyPort = rd.Next(10000, 60000) + "";
                    hipck.MyIP = GetLocalIP();
                    MemoryStream str = new MemoryStream();
                    BinaryFormatter bformat = new BinaryFormatter();
                    bformat.Serialize(str, hipck);
                    byte[] data = new byte[1024];
                    data = str.ToArray();
                    InitializePrivateChat(Details[0], Details[1],"0",hipck);
                    InitializeRequirer(Details[1], data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy tên nào bạn chọn, vui lòng chọn đúng tên!");
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            Packet clpck = new Packet();
            clpck.MyType = TypePacket.OUT_CHAT;
            clpck.MyName = userName;
            clpck.MyIP = GetLocalIP();
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, clpck);
            byte[] data = new byte[1024];
            data = str.ToArray();
            sendingClient.Send(data, data.Length);
            Application.Exit();
        }
        // move form
        #region Move Form
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
        #endregion
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
                    string font = "font-family:" + x.pack.MyFont.FontFamily.Name + ";" + "font-size:" + x.pack.MyFont.Size + "px;";
                    if (x.pack.MyFont.Italic)
                        font += "font-style: italic;";
                    if(x.pack.MyFont.Bold)
                    {
                        font += "font-weight: bold;";
                    }
                    if(x.pack.MyFont.Underline)
                    {
                        font += "text-decoration: underline;";
                        
                    }
                    string style = "style=\"color:rgb(" + x.pack.MyColor.R +","+ x.pack.MyColor.G + "," + x.pack.MyColor.B + ");"+ font + "\"";
                    body += "<div class='message mine' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>"  + "<span><strong>" + x.pack.MyName + "</strong></span>" + "<br>"  + "<span " +style +">" + x.pack.MyMessage + "</span></div>\n";
                }
                else if(x.who == Type.RECEIVER)
                {
                    string font = "font-family:" + x.pack.MyFont.FontFamily.Name + ";" + "font-size:" + x.pack.MyFont.Size + "px;";
                    if (x.pack.MyFont.Italic)
                        font += "font-style: italic;";
                    if (x.pack.MyFont.Bold)
                    {
                        font += "font-weight: bold;";
                    }
                    if (x.pack.MyFont.Underline)
                    {
                        font += "text-decoration: underline;";

                    }

                    string style = "style=\"color:rgb(" + x.pack.MyColor.R + "," + x.pack.MyColor.G + "," + x.pack.MyColor.B + ");" + font + "\"";
                    body += "<div class='message remote' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>" + "<span><strong>" + x.pack.MyName + "</strong></span>" + "<br>" + "<span " + style + ">" + x.pack.MyMessage + "</span></div>\n";
                }
                else
                {
                    body += "<p style=\"text-align: center\">" + x.pack.MyName + " đã offline!" + "</p>";

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


        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpFileDlog = new OpenFileDialog();
            if (OpFileDlog.ShowDialog() == DialogResult.OK)
            {
                txtsend.Text = OpFileDlog.FileName;
                Status = SendType.FILE;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpImageDlog = new OpenFileDialog();
            OpImageDlog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (OpImageDlog.ShowDialog() == DialogResult.OK)
            {
                txtsend.Text = OpImageDlog.FileName;
                Status = SendType.IMAGE;
            }
        }
        #region EMOJI
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" :) ");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" :( ");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" :-t ");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" (p) ");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" ;-( ");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" :o ");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" :-s ");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" x-) ");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            txtsend.AppendText(" (y) ");
        }
        #endregion

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            if (!grpEmoji.Visible)
                grpEmoji.Visible = true;
            else
                grpEmoji.Visible = false;
        }
    }
}
