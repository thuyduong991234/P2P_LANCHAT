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
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(txtRPort.Text)));
            listenSocket.Listen(4);
            while (true)
            {
                Socket socket = listenSocket.Accept();
                socket.NoDelay = true;
                try
                {
                    byte[] buf = new byte[1024];
                    socket.Receive(buf);
                    Packet recievePack = DeSerialize(buf);
                    Message mes = new Message(recievePack, Type.RECEIVER);
                    ChatLog.Add(mes);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        string mess = recievePack.MyMessage;
                        string start = @"<!DOCTYPE html><html><head><title>Client</title><style type='text/css'>
	                         body{font-family:  'Segoe UI', tahoma, sans-serif;}
	                        .message{padding: 6px;margin: 4px;text-align: left;cursor:default;word-wrap:break-word;}
	                        .mine{margin-left: 100px;background: DarkOrange;}
	                        .remote{margin-right: 100px;background: #999;}
                            </style>
                            <script language='javascript'>
                                window.onload=toBottom;
                                function toBottom(){ window.scrollTo(0, document.body.scrollHeight);}
                            </script></head><body>";
                        string end = @"</body></html>";
                        string body = "";
                        foreach (Message x in ChatLog)
                        {
                            if(x.who == Type.SENDER)
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
                    }));
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                socket.Close();
            }
        }
        private void PrivateChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        private void PrivateChat_Load(object sender, EventArgs e)
        {
            txtRPort.Text = "15000";
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                
                Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sck.NoDelay = true;

                byte[] buf = new byte[1024];
                buf = SendPacket();
                sck.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.22"), int.Parse(txtSPort.Text)));
                sck.Send(buf);
                sck.Close();
                ///
                string start = @"<!DOCTYPE html><html><head><title>Client</title><style type='text/css'>
	                         body{font-family:  'Segoe UI', tahoma, sans-serif;}
	                        .message{padding: 6px;margin: 4px;text-align: left;cursor:default;word-wrap:break-word;}
	                        .mine{margin-left: 100px;background: DarkOrange;}
	                        .remote{margin-right: 100px;background: #999;}
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
            catch (Exception ex) { };
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
