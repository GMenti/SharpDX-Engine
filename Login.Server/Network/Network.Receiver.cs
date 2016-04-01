using Lidgren.Network;
using Network.Library.Packets;

namespace Login.Server
{
    public static partial class Network
    {
        public static void ReceiveLogin(NetIncomingMessage packet)
        {
            LoginPacket loginPacket = new LoginPacket();
            packet.ReadAllFields(loginPacket);

            Program.frmServer.addLog(loginPacket.login + " - " + loginPacket.password);

            SendMenuError(GetIndex(packet.SenderConnection), "Erro ao logar...");
        }

        public static int GetIndex(NetConnection connection)
        {
            return players.IndexOf(connection);
        }
    }
}
