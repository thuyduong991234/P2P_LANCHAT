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
using System.Diagnostics;

// thử đưa đoạn close vào try catch
namespace PeerToPeerChat
{
    public partial class PrivateChat : Form
    {
        #region PROPERTIES
        public string friendName, meIP, mePort, friendIP, friendPort;
        List<Message> ChatLog;
        Dictionary<string, string> EmojiList;
        SendType Status;
        String saveFileName = "";
        bool isSendFile = false;
        bool isSendImage = false;
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket socket;
        bool dispose = false;
        #endregion

        #region CONSTRUCTOR
        public PrivateChat()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ChatLog = new List<Message>();
        }
        public PrivateChat(Packet pck,int who)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            if(who == 2)
            {
                Message himess = new Message(pck, Type.RECEIVER);
                ChatLog = new List<Message>();
                ChatLog.Add(himess);
            }
            else
            {
                Message himess = new Message(pck, Type.SENDER);
                ChatLog = new List<Message>();
                ChatLog.Add(himess);
            }
        }
        public PrivateChat(Packet pck, int who, string Port,string IP,string meePort)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            if (who == 2)
            {
                Message himess = new Message(pck,Type.RECEIVER);
                ChatLog = new List<Message>();
                ChatLog.Add(himess);
            }
            else
            {
                Message himess = new Message(pck, Type.SENDER);
                ChatLog = new List<Message>();
                ChatLog.Add(himess);
            }
            mePort = meePort;
            meIP = IP;
            friendPort = Port;
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.NoDelay = true;
            byte[] buf = new byte[1024];
            buf = SendPort();
            sck.Connect(new IPEndPoint(IPAddress.Parse(pck.MyIP), int.Parse(friendPort)));
            sck.Send(buf);
            sck.Close();
        }
        #endregion

        #region DI CHUYỂN FORM
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

        #region EVENT CỦA CONTROL 
        private void PrivateChat_Load(object sender, EventArgs e)
        {
            lbName.Text = friendName;
            this.Text = friendName;
            Status = SendType.MESSAGE;
            wbContent.DocumentText = "<html><body style=\"background-color:rgb(217,215,206)\"></body></html>";
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
            EmojiList.Add(";-(", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "hun.png");
            EmojiList.Add("(p)", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Emoji", "gian.png");
            EmojiList.Add(":-t", "<img src=\"" + path + "\"style='width:20px;height:20px'>");
            RefreshWeb();
            txtsend.Focus();
            Start();
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

        private void txtsend_TextChanged(object sender, EventArgs e)
        {
            if (Status == SendType.FILE && txtsend.Text == "")
                Status = SendType.MESSAGE;
        }

        private void wbContent_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            if (e.Url.ToString() != "about:blank")
            {
                string url = e.Url.LocalPath;
                url = url.Replace("(~*)", ":");
                url = url.Replace("%5C", "\\");
                if (File.Exists(url))
                    try
                    {
                        Process.Start("explorer.exe", " /select, " + url);
                    }
                    catch
                    {
                        MessageBox.Show("Không thể mở file");
                    }
                else
                    MessageBox.Show("Tập tin không tồn tại");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                #region Gui Message
                if (Status == SendType.MESSAGE)
                {

                    Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sck.NoDelay = true;
                    if (friendPort == "0")
                    {
                        MessageBox.Show("Đã có lỗi kết nối\nVui lòng thử lại sau khi Form tự đóng!", "OOPS!");
                        sck.Close();
                        listenSocket.Close();
                        this.Close();
                        return;
                    }
                    byte[] buf = new byte[1024];
                    Packet mypacket = new Packet();
                    mypacket.MyMessage = txtsend.Text;
                    mypacket.MyFont = txtsend.Font;
                    mypacket.MyColor = txtsend.ForeColor;
                    mypacket.MyType = TypePacket.MESSAGE;
                    MemoryStream str = new MemoryStream();
                    BinaryFormatter bformat = new BinaryFormatter();
                    bformat.Serialize(str, mypacket);
                    buf = str.ToArray();
                    sck.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
                    sck.Send(buf);
                    sck.Close();
                    string AddEmoji = mypacket.MyMessage;
                    AddEmoji = AddEmoji.Replace(":)", EmojiList[":)"]);
                    AddEmoji = AddEmoji.Replace(":(", EmojiList[":("]);
                    AddEmoji = AddEmoji.Replace(":-s", EmojiList[":-s"]);
                    AddEmoji = AddEmoji.Replace("x-)", EmojiList["x-)"]);
                    AddEmoji = AddEmoji.Replace("(y)", EmojiList["(y)"]);
                    AddEmoji = AddEmoji.Replace(":o", EmojiList[":o"]);
                    AddEmoji = AddEmoji.Replace(";-(", EmojiList[";-("]);
                    AddEmoji = AddEmoji.Replace("(p)", EmojiList["(p)"]);
                    AddEmoji = AddEmoji.Replace(":-t", EmojiList[":-t"]);
                    mypacket.MyMessage = AddEmoji;
                    Message mes = new Message(mypacket, Type.SENDER);
                    ChatLog.Add(mes);
                }
                #endregion

                #region Gui File
                else if (Status == SendType.FILE)
                {

                    FileStream fs = null;

                    Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.NoDelay = true;
                    if (friendPort == "0")
                    {
                        MessageBox.Show("Đã có lỗi kết nối\nVui lòng thử lại sau khi Form tự đóng!", "OOPS!");
                        socket.Close();
                        listenSocket.Close();
                        this.Close();
                        return;
                    }
                    bool bSendOk = true;
                    string extension = "";
                    try
                    {
                        FileInfo fi = new FileInfo(txtsend.Text);
                        ulong fileSize = (ulong)fi.Length;
                        extension = fi.Extension;
                        byte[] buf = new byte[32 * 1024];
                        MemoryStream ms = new MemoryStream(buf);
                        BinaryWriter bw = new BinaryWriter(ms);
                        bw.Write(fileSize);
                        bw.Close();
                        ms.Close();

                        fs = File.OpenRead(txtsend.Text);

                        socket1.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
                        byte[] buf2 = new byte[1024];
                        buf2 = SendPacket4(fi.Name, TypePacket.SEND_FILE);
                        socket1.Send(buf2);
                        socket1.Close();
                        //Send size cua file
                        socket.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
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

                        }

                    }
                    catch (Exception exx)
                    {
                        bSendOk = false;
                        MessageBox.Show(exx.Message, "Gửi file lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch (Exception) { }
                    }

                    socket.Close();

                    if (bSendOk)
                    {
                        MessageBox.Show("Gửi Thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Packet fpck = new Packet();
                        fpck.MyMessage = "<a href='" + txtsend.Text.Replace(":", "(~*)") + "'>" + ((extension == ".jpg" || extension == ".png" || extension == ".PNG") ? "<img src='" + txtsend.Text + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(txtsend.Text) + "</b></a>";
                        Message fmess = new Message(fpck, Type.SENDER);
                        ChatLog.Add(fmess);
                    }
                    Status = SendType.MESSAGE;
                }
                #endregion

                #region Gui Anh
                else if (Status == SendType.IMAGE)
                {
                    FileStream fs = null;

                    Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.NoDelay = true;
                    if (friendPort == "0")
                    {
                        MessageBox.Show("Đã có lỗi kết nối\nVui lòng thử lại sau khi Form tự đóng!", "OOPS!");
                        socket.Close();
                        listenSocket.Close();
                        this.Close();
                        return;
                    }
                    bool bSendOk = true;
                    string extension = "";
                    try
                    {
                        FileInfo fi = new FileInfo(txtsend.Text);
                        ulong fileSize = (ulong)fi.Length;
                        extension = fi.Extension;
                        byte[] buf = new byte[32 * 1024];
                        MemoryStream ms = new MemoryStream(buf);
                        BinaryWriter bw = new BinaryWriter(ms);
                        bw.Write(fileSize);
                        bw.Close();
                        ms.Close();

                        fs = File.OpenRead(txtsend.Text);

                        socket1.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
                        byte[] buf2 = new byte[1024];
                        buf2 = SendPacket4(fi.Name, TypePacket.SEND_IMAGE);
                        socket1.Send(buf2);
                        socket1.Close();
                        //Send size cua file
                        socket.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
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

                        }

                    }
                    catch (Exception exx)
                    {
                        bSendOk = false;
                        MessageBox.Show(exx.Message, "Gửi ảnh bị lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch (Exception) { }
                    }

                    socket.Close();

                    if (bSendOk)
                    {
                        MessageBox.Show("Gửi Thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Packet fpck = new Packet();
                        fpck.MyMessage = "<a href='" + txtsend.Text.Replace(":", "(~*)") + "'>" + ((extension == ".jpg" || extension == ".png" || extension == ".PNG") ? "<img src='" + txtsend.Text + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(txtsend.Text) + "</b></a>";
                        Message fmess = new Message(fpck, Type.SENDER);
                        ChatLog.Add(fmess);
                    }
                    Status = SendType.MESSAGE;
                }
                #endregion

            }
            catch (Exception ex) { };
            RefreshWeb();
            txtsend.Text = "";
            txtsend.Focus();
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }

        public void ptbExit_Click(object sender, EventArgs e)
        {
            // Gui 1 packet CLOSING den cho doi phuong
            if (friendPort == "0")
            {
                MessageBox.Show("Đã có lỗi kết nối\nVui lòng thử lại sau khi Form tự đóng!", "OOPS!");
                listenSocket.Close();
                this.Close();
                return;
            }
            if (!dispose)
            {
                Socket clpsck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clpsck.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
                byte[] buf2 = new byte[1024];
                buf2 = Sendpacketclose(TypePacket.CLOSING);
                clpsck.Send(buf2);
                clpsck.Close();
            }
            else
            {
                listenSocket.Close();
                this.Close();
                return;
            }
            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();
            //socket.Shutdown(SocketShutdown.Both);
            //listenSocket.Shutdown(SocketShutdown.Receive);
        }

        #endregion

        #region CÁC HÀM TỰ TẠO
        byte[] SendPacket()
        {
            Packet mypacket = new Packet();
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
        byte[] SendPacket4(string FileName, TypePacket type)
        {
            Packet mypacket = new Packet();
            mypacket.MyType = type;
            mypacket.MyMessage = FileName;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
        }



        byte[] SendPort()
        {
            Packet mypacket = new Packet();
            mypacket.MyType = TypePacket.SEND_PORT;
            mypacket.MyPort = mePort;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
        }

        byte[] Sendpacketclose(TypePacket tp)
        {
            Packet mypacket = new Packet();
            mypacket.MyType = tp;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
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

        void RefreshWeb()
        {
            string start = @"<!DOCTYPE html><html><head><title>Client</title><style type='text/css'>
	                         body{font-family:  'Segoe UI', tahoma, sans-serif;background-color:rgb(217,215,206);}
	                        .message{padding: 6px;margin: 4px;text-align: left;cursor:default;word-wrap:break-word;}
	                        .mine{margin-left: 100px;background: rgb(218,233,255);}
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
                    if (x.pack.MyFont.Bold)
                    {
                        font += "font-weight: bold;";
                    }
                    if (x.pack.MyFont.Underline)
                    {
                        font += "text-decoration: underline;";

                    }
                    string style = "style=\"color:rgb(" + x.pack.MyColor.R + "," + x.pack.MyColor.G + "," + x.pack.MyColor.B + ");" + font + "\"";
                    body += "<div class='message mine' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>" +  "<span " + style + ">" + x.pack.MyMessage + "</span></div>\n";
                }
                else if (x.who == Type.RECEIVER)
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
                    body += "<div class='message remote' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>" + "<span " + style + ">" + x.pack.MyMessage + "</span></div>\n";
                }
                else
                {
                    body += "<p style=\"text-align: center\">" + lbName.Text + " đã rời khỏi cuộc trò chuyện!" + "<br>Vui lòng tắt Form này để tiếp tục trò chuyện với " +lbName.Text+ " lần sau!</p>";
                }
            }
            wbContent.Document.Write(start + body + end);
            wbContent.Refresh();
        }
        private Packet DeSerialize(byte[] data)
        {
            Package.Packet myPacket = new Packet();
            MemoryStream str = new MemoryStream(data);
            BinaryFormatter bformat = new BinaryFormatter();
            myPacket = (Packet)bformat.Deserialize(str);
            return myPacket;
        }
        public void Start()
        {
            try
            {

                Thread thread = new Thread(ThreadListen);
                thread.Name = "ThreadListen";
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ThreadListen()
        {
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(mePort)));
            listenSocket.Listen(4);
            while (true)
            {
             
                try
                {
                    socket = listenSocket.Accept(); // Chấp nhận kết nối
                    socket.NoDelay = true;

                } catch(Exception) {}

                try
                {
                    #region Nhan File
                    if (isSendFile)
                    {
                        //if (MessageBox.Show(this.Text + " đang gửi một File cho bạn. Bạn có muốn nhận nó không ?", "Nhận File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        //{   ///
                        //    ///
                        //    socket.Close();              
                        //    thinking              
                        //}
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
                            byte[] buf = new byte[32 * 1024];
                            int nr = socket.Receive(buf, sizeof(ulong), SocketFlags.None);

                            MemoryStream ms = new MemoryStream(buf);
                            BinaryReader br = new BinaryReader(ms);
                            ulong fileSize = br.ReadUInt64();
                            br.Close();
                            ms.Close();


                            ulong pos = 0;
                            while (pos < fileSize)
                            {
                                nr = socket.Receive(buf);
                                if (nr <= 0)
                                {
                                    throw new Exception("File bị rỗng!");
                                }

                                pos += (ulong)nr;
                                fs.Write(buf, 0, nr);

                            }

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

                        socket.Close();

                        if (!bTranferOk)
                        {
                            try { File.Delete(saveFileName); }
                            catch (Exception) { }
                        }
                        else
                        {
                            string[] extension;
                            extension = saveFileName.Split('.');
                            MessageBox.Show("Đã nhận !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Packet rpck = new Packet();
                            rpck.MyMessage = "<a href='" + saveFileName.Replace(":", "(~*)") + "'>" + (('.' + extension[1] == ".jpg" || '.' + extension[1] == ".png" || extension[1] == ".PNG") ? "<img src='" + saveFileName + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(saveFileName) + "</b></a>";
                            Message fmess = new Message(rpck, Type.RECEIVER);
                            ChatLog.Add(fmess);
                        }
                        isSendFile = false;
                    }
                    #endregion
                    #region Nhan Image
                    else if (isSendImage)
                    {

                        this.Invoke((MethodInvoker)(() =>
                        {
                            SaveFileDialog saveFileDlog1 = new SaveFileDialog();
                            saveFileDlog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                            saveFileDlog1.FileName = saveFileName;
                            saveFileName = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\"+saveFileDlog1.FileName;
                        }));
                        bool bTranferOk = true;
                        FileStream fs = null;
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


                            ulong pos = 0;
                            while (pos < fileSize)
                            {
                                nr = socket.Receive(buf);
                                if (nr <= 0)
                                {
                                    throw new Exception("Không nhận được ảnh!");
                                }

                                pos += (ulong)nr;
                                fs.Write(buf, 0, nr);

                            }

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

                        socket.Close();

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
                            rpck.MyMessage = "<a href='" + saveFileName.Replace(":", "(~*)") + "'>" + (('.' + extension[1] == ".jpg" || '.' + extension[1] == ".png" || extension[1] == ".PNG") ? "<img src='" + saveFileName + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(saveFileName) + "</b></a>";
                            Message fmess = new Message(rpck, Type.RECEIVER);
                            ChatLog.Add(fmess);
                        }
                        isSendImage = false;
                    }
                    #endregion
                    #region Nhan Message
                    else // Nhan message binh thuong
                    {
                        try
                        {
                            byte[] buf = new byte[1024];

                            socket.Receive(buf);

                            Packet recievePack = DeSerialize(buf);

                            if (recievePack.MyType == TypePacket.SEND_PORT)
                            {
                                friendPort = recievePack.MyPort;
                            }
                            // Gan co bat dau gui file
                            else if (recievePack.MyType == TypePacket.SEND_FILE)
                            {
                                if (MessageBox.Show(this.Text + " đang gửi một File cho bạn. Bạn có muốn nhận nó không ?", "Nhận File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {   ///
                                    isSendFile = true;
                                    saveFileName = recievePack.MyMessage;
                                }
                            }
                            else if (recievePack.MyType == TypePacket.SEND_IMAGE)
                            {
                                isSendImage = true;
                                saveFileName = recievePack.MyMessage;
                            }
                            // Nhan tin hieu de dong Form
                            else if (recievePack.MyType == TypePacket.CLOSING)
                            {
                                // Dong san socket nghe cua minh de nao muon tat thi tat binh thuong.
                                socket.Close();
                                dispose = true;
                                // Gui RELY
                                Socket repsck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); ;
                                repsck.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
                                byte[] buf2 = new byte[1024];
                                buf2 = Sendpacketclose(TypePacket.REPLY);
                                repsck.Send(buf2);
                                repsck.Close();
                                Message clsmess = new Message(recievePack, Type.CLOSER);
                                ChatLog.Add(clsmess);
                                Invoke((MethodInvoker)(() =>
                                {
                                    txtsend.Enabled = false;
                                    txtsend.ReadOnly = true;
                                    btnSend.Enabled = false;
                                    RefreshWeb();
                                }));

                                return;
                            }
                            else if (recievePack.MyType == TypePacket.REPLY)
                            {
                                listenSocket.Close();
                                socket.Close();
                                this.Close();
                                return;
                            }
                            // Nhan mess binh thuong
                            else
                            {
                                string AddEmoji = recievePack.MyMessage;
                                AddEmoji = AddEmoji.Replace(":)", EmojiList[":)"]);
                                AddEmoji = AddEmoji.Replace(":(", EmojiList[":("]);
                                AddEmoji = AddEmoji.Replace(":-s", EmojiList[":-s"]);
                                AddEmoji = AddEmoji.Replace("x-)", EmojiList["x-)"]);
                                AddEmoji = AddEmoji.Replace("(y)", EmojiList["(y)"]);
                                AddEmoji = AddEmoji.Replace(":o", EmojiList[":o"]);
                                AddEmoji = AddEmoji.Replace(";-(", EmojiList[";-("]);
                                AddEmoji = AddEmoji.Replace("(p)", EmojiList["(p)"]);
                                AddEmoji = AddEmoji.Replace(":-t", EmojiList[":-t"]);
                                recievePack.MyMessage = AddEmoji;
                                Message mes = new Message(recievePack, Type.RECEIVER);
                                ChatLog.Add(mes);
                            }
                        }
                        catch(Exception e1)
                        {
                            continue;
                        }
                    }
                    #endregion
                  
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                socket.Close();
                this.Invoke((MethodInvoker)(() =>
                {
                    RefreshWeb();
                }));
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            if (!grpEmoji.Visible)
                grpEmoji.Visible = true;
            else
                grpEmoji.Visible = false;
        }

        private void txtsend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend_Click(this, new EventArgs());
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
        #endregion
    }
}
