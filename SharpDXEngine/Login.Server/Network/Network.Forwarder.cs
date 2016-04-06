using Lidgren.Network;
using Network;

namespace Login.Server
{
    public static partial class Network
    {

        public static void ForwardPacket(NetIncomingMessage packet)
        {
            PacketType packetType = (PacketType) packet.ReadByte();

            switch (packetType) {
                case PacketType.Login:
                    ReceiveLogin(packet);
                    break;
                case PacketType.Register:
                    ReceiveRegister(packet);
                    break;
            }

        }

    }
}
