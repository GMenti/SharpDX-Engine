using Lidgren.Network;
using Microsoft.Xna.Framework;
using Network.Library.Packets;
using SharpDXEngine.Frames.Menu;

namespace SharpDXEngine
{
    public static partial class Network
    {
        public static void ReceiveLogin(NetIncomingMessage packet)
        {
            AccountData account = new AccountData();
            packet.ReadAllFields(account);

            Login.lblStatus.color = Color.Green;
        }
    }
}
