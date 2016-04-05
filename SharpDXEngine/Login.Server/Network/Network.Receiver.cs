using Lidgren.Network;
using Login.Server.Objects.Account;
using Network.Library.Packets;
using System;

namespace Login.Server
{
    public static partial class Network
    {
        public static void ReceiveLogin(NetIncomingMessage packet)
        {
            AccountData data = new AccountData();
            packet.ReadAllFields(data);

            DateTime start = DateTime.Now;

            Boolean finded = false;
            foreach (Account acc in Database.accounts) {
                if (acc.login == data.login && acc.password == data.password) {
                    finded = true;
                    break;
                }
            }

            Program.frmServer.addLog("Login: " + (DateTime.Now.Millisecond - start.Millisecond));

            SendMenuError(GetIndex(packet.SenderConnection), finded.ToString());
        }

        public static int GetIndex(NetConnection connection)
        {
            return players.IndexOf(connection);
        }
    }
}
