using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Package
{
    [Serializable()]
    public class Packet : ISerializable
    {
        private string myIP;
        private string myName;
        private string myMessage;
        private Font myFont;
        private Color myColor;
        private TypePacket myType;
        private string myPort;
        public string MyIP
        {
            get
            {
                return myIP;
            }

            set
            {
                myIP = value;
            }
        }

        public string MyMessage
        {
            get
            {
                return myMessage;
            }

            set
            {
                myMessage = value;
            }
        }

        public Font MyFont
        {
            get
            {
                return myFont;
            }

            set
            {
                myFont = value;
            }
        }

        public Color MyColor
        {
            get
            {
                return myColor;
            }

            set
            {
                myColor = value;
            }
        }

        public string MyName
        {
            get
            {
                return myName;
            }

            set
            {
                myName = value;
            }
        }

        public TypePacket MyType
        {
            get
            {
                return myType;
            }

            set
            {
                myType = value;
            }
        }
        Random rd = new Random();
        public string MyPort
        {
            get
            {
                return myPort;
            }

            set
            {
                myPort = value;
            }
        }

       
        public Packet()
        {
            this.myIP = null;
            this.myMessage = null;
            this.myName = null;
            this.myFont = new Font("Arial", 13);
            this.myColor = Color.Black;
            this.myType = TypePacket.NONE;
            this.myPort = rd.Next(10000, 60000) + "";
        }

        public Packet(string IP, string Name, string Mess, Font font, Color color, TypePacket type, string Port)
        {
            this.myIP = IP;
            this.myName = Name;
            this.myMessage = Mess;
            this.myFont = font;
            this.myColor = color;
            this.myType = type;
            this.myPort = Port;
        }

        public Packet(Packet packet)
        {
            this.myIP = packet.myIP;
            this.myName = packet.myName;
            this.myMessage = packet.myMessage;
            this.myFont = packet.myFont;
            this.myColor = packet.myColor;
            this.myType = packet.myType;
            this.myPort = packet.myPort;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IP", this.myIP);
            info.AddValue("Name", this.myName);
            info.AddValue("Message", this.myMessage);
            info.AddValue("Font", this.myFont);
            info.AddValue("Color", this.myColor);
            info.AddValue("Type", this.myType);
            info.AddValue("Port", this.myPort);

        }

        public Packet(SerializationInfo info, StreamingContext context)
        {
            this.myIP = (string)info.GetValue("IP", typeof(string));
            this.myName = (string)info.GetValue("Name", typeof(string));
            this.myMessage = (string)info.GetValue("Message", typeof(string));
            this.myFont = (Font)info.GetValue("Font", typeof(Font));
            this.myColor = (Color)info.GetValue("Color", typeof(Color));
            this.myType = (TypePacket)info.GetValue("Type", typeof(TypePacket));
            this.myPort = (string)info.GetValue("Port", typeof(string));
        }
    }
    public enum TypePacket
    {
        NONE,
        REPLY,
        SEND_INFO_USER_1,
        SEND_INFO_USER_2,
        MESSAGE,
        REQUIRE_CHAT,
        CLOSING,
        SEND_FILE,
        OUT_CHAT,
        SEND_PORT
    }
}

