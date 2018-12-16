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
        Packet secondsend;
        bool Require = false;
        Packet mypck;
        public bool firstsend =true;
        Socket sck;
        EndPoint epMe, epFriend;
        public string friendName, meIP, mePort, friendIP, friendPort;
        List<Message> ChatLog;
        SendType Status;
        String saveFileName = "";
        bool isSendFile = false;
        private event EventHandler<RequireEvent> requireChat;
        public event EventHandler<RequireEvent> RequireChat
        {
            add { requireChat += value; }
            remove { requireChat += value; }
        }
        private event EventHandler<CloseEvent> closeChat;
        public event EventHandler<CloseEvent> CloseChat
        {
            add { closeChat += value; }
            remove { closeChat += value; }
        }
        public PrivateChat()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            mypck = new Packet();
            secondsend = new Packet();
            ChatLog = new List<Message>();
        }
        public PrivateChat(Packet pck)
        {
            firstsend = false;
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Require = true;
            mypck = pck;
            secondsend = new Packet();
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
                thread.Start();
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
        private void ThreadListen()
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(mePort)));
            listenSocket.Listen(4);
            while (true)
            {
                Socket socket = listenSocket.Accept();
                socket.NoDelay = true;
             
                try
                {
                    #region Nhan File
                    if (isSendFile)
                    {
                        if (MessageBox.Show("Peer is sending a file to you. Do you want to receive it ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {   ///
                            ///
                            socket.Close();
                            return;
                        }
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
                                    throw new Exception("Receive 0 byte");
                                }

                                pos += (ulong)nr;
                                fs.Write(buf, 0, nr);

                            }

                        }
                        catch (Exception e)
                        {
                            bTranferOk = false;
                            MessageBox.Show(e.Message, "File Receiving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            rpck.MyMessage = "<a href='" + saveFileName.Replace(":", "(~*)") + "'>" + (('.'+extension[1] == ".jpg" || '.' + extension[1] == ".png" || extension[1] == ".PNG") ? "<img src='" + saveFileName + "' style='max-width:300px'/><br/>" : "") + "<b>" + Path.GetFileName(saveFileName) + "</b></a>";
                            Message fmess = new Message(rpck, Type.RECEIVER);
                            ChatLog.Add(fmess);
                        }
                        isSendFile = false;
                    }
                    #endregion
                    #region Nhan Message
                    else // Nhan message binh thuong
                    {
                        byte[] buf = new byte[1024];
                        socket.Receive(buf);
                        Packet recievePack = DeSerialize(buf);
                        if(recievePack.MyType == TypePacket.SEND_FILE)
                        {
                            isSendFile = true;
                            saveFileName = recievePack.MyMessage;
                        }
                        else
                        {
                            Message mes = new Message(recievePack, Type.RECEIVER);
                            ChatLog.Add(mes);
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
        private void PrivateChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        private void PrivateChat_Load(object sender, EventArgs e)
        {
            txtRPort.Text = mePort;
            txtSPort.Text = friendPort;
            Status = SendType.MESSAGE;
            wbContent.DocumentText = "<html><body style=\"background-color:rgb(217,215,206)\"> </body></html>";
            Start();
        }


        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        byte[] SendPacket()
        {
            Packet mypacket = new Packet();
            mypacket.MyMessage = txtsend.Text;
            mypacket.MyFont = txtsend.Font;
            mypacket.MyColor = txtsend.ForeColor;
            mypacket.MyType = TypePacket.MESSAGE;
            Message mes = new Message(mypacket, Type.SENDER);
            ChatLog.Add(mes);
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
        }
        byte[] SendPacket3(Packet pck)
        {
            Packet mypacket = new Packet();
            mypacket.MyMessage = pck.MyMessage;
            mypacket.MyFont = pck.MyFont;
            mypacket.MyColor = pck.MyColor;
            mypacket.MyType = TypePacket.LAST_SEND;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }
        byte[] SendPacket4(string FileName)
        {
            Packet mypacket = new Packet();
            mypacket.MyType = TypePacket.SEND_FILE;
            mypacket.MyMessage = FileName;
            MemoryStream str = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(str, mypacket);
            byte[] data = new byte[1024];
            data = str.ToArray();
            return data;
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
            if(OpFileDlog.ShowDialog() == DialogResult.OK)
            {
                txtsend.Text = OpFileDlog.FileName;
                Status = SendType.FILE;
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
                    byte[] buf = new byte[1024];
                    buf = SendPacket();
                    sck.Connect(new IPEndPoint(IPAddress.Parse(friendIP), int.Parse(friendPort)));
                    sck.Send(buf);
                    sck.Close();
                }
                #endregion

                #region Gui File
                else if (Status == SendType.FILE)
                {

                    FileStream fs = null;

                    Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.NoDelay = true;

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
                        buf2 = SendPacket4(fi.Name);
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
                        MessageBox.Show(exx.Message, "File Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    body += "<div class='message mine' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>" + x.pack.MyMessage + "</div>\n";

                }
                else
                {
                    body += "<div class='message remote' title='" + "Test1" + ":" + "Test2" + " " + "Test3" + "'>" + x.pack.MyMessage + "</div>\n";

                }
            }
            wbContent.Document.Write(start + body + end);
            wbContent.Refresh();
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
                string url = e.Url.PathAndQuery;
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
    }

    public class RequireEvent:EventArgs
    {
        public string FirstMess { get; set; }
        public Color FirstColor { get; set; }
        public Font FirstFont { get; set; }
        public string FirstIP { get; set; }
        public RequireEvent(string mess, Color cl, Font ft, string ip)
        {
            this.FirstMess = mess;
            this.FirstColor = cl;
            this.FirstFont = ft;
            this.FirstIP = ip;
        }
    }
    public class CloseEvent:EventArgs
    {
        public bool isClose { get; set; }
        public string FirstIP { get; set; }
        public string friendName { get; set; }
        public CloseEvent(string ip, string name)
        {
            this.isClose = true;
            this.FirstIP = ip;
            this.friendName = name;
        }
    }
}
