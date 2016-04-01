using Lidgren.Network;
using Network;
using SharpDXEngine.Frames.Menu.Login;
using SharpDXEngine.Libraries;
using SharpDXEngine.Utilities.Helpers;
using System;

namespace SharpDXEngine.Frames.Menu
{
    class MenuController
    {
        public void Login(string user, string password)
        {
            NetOutgoingMessage message = NetworkConnection.client.CreateMessage();
            message.Write((byte)PacketType.Login);
            NetworkConnection.client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
        }

    }
}
