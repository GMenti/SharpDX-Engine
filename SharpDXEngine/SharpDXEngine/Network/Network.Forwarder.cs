using Lidgren.Network;
using Network;
using SharpDXEngine.Utilities.Helpers;

namespace SharpDXEngine
{
    public static partial class Network
    {
        public static void ForwardPacket(NetIncomingMessage packet)
        {
            PacketType packetType = (PacketType)packet.ReadByte();

            switch (packetType) {
                case PacketType.Login:
                    ReceiveLogin(packet);
                    break;

                case PacketType.MenuError:
                    Debug.msgBox(packet.ReadString());
                    break;
            }
        }
    }
}
