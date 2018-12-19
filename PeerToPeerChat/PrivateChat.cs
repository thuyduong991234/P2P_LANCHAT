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
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            mypck = new Packet();
            secondsend = new Packet();
        }
        public PrivateChat(Packet pck)
        {
            firstsend = false;
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
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
        void MessageCallBack(IAsyncResult aResult)
        {
            Packet newpacket = new Packet();
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epFriend);
                if (size > 0)
                {
                    byte[] ReceiveData = new byte[1464];
                    ReceiveData = (byte[])aResult.AsyncState;
                    Packet ReceivedPacket = DeSerialize(ReceiveData);
                    newpacket = ReceivedPacket;
                    if (ReceivedPacket.MyType == TypePacket.LAST_SEND && ReceivedPacket.MyMessage == secondsend.MyMessage) { }
                    else
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            //rtxtDisplay.AppendText("Friend: ");
                            //rtxtDisplay.SelectionFont = ReceivedPacket.MyFont;
                            //.SelectionColor = ReceivedPacket.MyColor;
                            //rtxtDisplay.AppendText(ReceivedPacket.MyMessage + "\n");
                            //rtxtDisplay.ScrollToCaret();
                        }));
                    }

                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epFriend, new AsyncCallback(MessageCallBack), buffer);
            }

            catch (Exception e)
            {
                byte[] msg = SendPacket3(newpacket);
                sck.Send(msg);
                sck.Shutdown(SocketShutdown.Both);
                sck.Close();
            }
         }
        public void Start()
        {
                try
                {
                    epMe = new IPEndPoint(IPAddress.Parse(meIP), Convert.ToInt32(mePort));
                    sck.Bind(epMe);
                    epFriend = new IPEndPoint(IPAddress.Parse(friendIP), Convert.ToInt32(friendPort));
                    sck.Connect(epFriend);
                    byte[] buffer = new byte[1500];
                    sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epFriend, new AsyncCallback(MessageCallBack), buffer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }


        private void PrivateChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeChat(this, new CloseEvent(friendIP, this.Text));
        }

        private void txtsend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnsend_Click(sender, new EventArgs());
            }
        }

        private void PrivateChat_Load(object sender, EventArgs e)
        {
            this.Text = friendName;
            Start();
            //rtxtDisplay.AppendText("Các bạn đang ở chế độ Private Chat!\n");
            if (Require)
            {
                //rtxtDisplay.AppendText("Friend: ");
                //rtxtDisplay.SelectionColor = mypck.MyColor;
                //rtxtDisplay.SelectionFont = mypck.MyFont;
                //rtxtDisplay.AppendText(mypck.MyMessage + "\n");
            }
        }

        private void ptbSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstsend == true)
                {
                    firstsend = false;
                    if (requireChat != null)
                    {
                        //
                        secondsend.MyMessage = txtsend.Text;
                        secondsend.MyFont = txtsend.Font;
                        secondsend.MyColor = txtsend.ForeColor;
                        requireChat(this, new RequireEvent(txtsend.Text, txtsend.ForeColor, txtsend.Font, friendIP));
                    }
                }
                byte[] msg = SendPacket();
                sck.Send(msg);
                //
                //rtxtDisplay.AppendText("You: ");
                //rtxtDisplay.SelectionColor = txtsend.ForeColor;
                //rtxtDisplay.SelectionFont = txtsend.Font;
               // rtxtDisplay.AppendText(txtsend.Text + "\n");
                //rtxtDisplay.ScrollToCaret();
                txtsend.Clear();
                txtsend.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtsend.ForeColor = colorDialog1.Color;
            }
        }

        private void ptbFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtsend.Font = fontDialog1.Font;
            }
        }

        private void lkbFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtsend.Font = fontDialog1.Font;
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstsend == true)
                {
                    firstsend = false;
                    if (requireChat != null)
                    {
                        //
                        secondsend.MyMessage = txtsend.Text;
                        secondsend.MyFont = txtsend.Font;
                        secondsend.MyColor = txtsend.ForeColor;
                        requireChat(this, new RequireEvent(txtsend.Text, txtsend.ForeColor, txtsend.Font, friendIP));
                    }
                }
                    byte[] msg = SendPacket();
                    sck.Send(msg);
                //
               // rtxtDisplay.AppendText("You: ");
               // rtxtDisplay.SelectionColor = txtsend.ForeColor;
                //rtxtDisplay.SelectionFont = txtsend.Font;
                //rtxtDisplay.AppendText(txtsend.Text + "\n");
                ///rtxtDisplay.ScrollToCaret();
                txtsend.Clear();
                txtsend.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lkbColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtsend.ForeColor = colorDialog1.Color;
            }
        }

        byte[] SendPacket()
        {
            Packet mypacket = new Packet();
            mypacket.MyMessage = txtsend.Text;
            mypacket.MyFont = txtsend.Font;
            mypacket.MyColor = txtsend.ForeColor;
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
