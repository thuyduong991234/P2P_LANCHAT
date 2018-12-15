using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Package;

namespace PeerToPeerChat
{
    public class Message
    {
        public Packet pack { get; set; }
        public Type who { get; set; }
        public Message(Packet pck, Type whoIs)
        {
            pack = pck;
            who = whoIs;
        }
    }
    public enum Type
    {
        SENDER,
        RECEIVER
    }
}
