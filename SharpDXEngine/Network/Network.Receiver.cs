using Lidgren.Network;
using Microsoft.Xna.Framework;
using Network.Library.Packets;
using SharpDXEngine.Frames.Menu.Login;
using SharpDXEngine.Objects;

namespace SharpDXEngine
{
    public static partial class Network
    {
        public static void ReceiveLogin(NetIncomingMessage packet)
        {
            AccountData account = new AccountData();
            packet.ReadAllFields(account);

            LoginPanel.lblStatus.color = Color.Green;
        }
    }
}
