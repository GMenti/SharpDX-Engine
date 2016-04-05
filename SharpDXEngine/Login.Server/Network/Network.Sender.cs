using Lidgren.Network;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Server
{
    public static partial class Network
    {
        public static void SendMenuError(int index, string msg)
        {
            NetOutgoingMessage message = server.CreateMessage();
            message.Write((byte)PacketType.MenuError);
            message.Write(msg);
            server.SendMessage(message, (NetConnection) players[index], NetDeliveryMethod.ReliableOrdered);
        }
    }
}
