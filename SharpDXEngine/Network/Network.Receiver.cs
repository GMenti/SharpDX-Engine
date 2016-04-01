using Lidgren.Network;
using Microsoft.Xna.Framework;
using Network;
using SharpDXEngine.Frames.Menu.Login;
using SharpDXEngine.Utilities.Helpers;

namespace SharpDXEngine
{
    public static partial class Network
    {

        public static void ReceivePacket(NetIncomingMessage packet)
        {
            PacketType packetType = (PacketType) packet.ReadByte();

            switch (packetType) {
                case PacketType.Login:
                    LoginPanel.lblStatus.color = Color.Green;
                    break;

                case PacketType.MenuError:
                    Debug.msgBox(packet.ReadString());
                    break;
            }

        }

    }
}
