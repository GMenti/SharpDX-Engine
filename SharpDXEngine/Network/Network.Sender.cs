using Lidgren.Network;
using Network;
using Network.Library.Packets;

namespace SharpDXEngine
{
    public static partial class Network
    {
        public static void SendLogin(LoginPacket loginPacket)
        {
            NetOutgoingMessage message = client.CreateMessage();
            message.Write((byte)PacketType.Login);
            message.WriteAllFields(loginPacket);
            client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
