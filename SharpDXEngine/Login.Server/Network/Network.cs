using Lidgren.Network;
using Network;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Login.Server
{
    public static partial class Network
    {
        private static NetServer server;
        private static Boolean serverOnline;
        private static ArrayList players;

        public static void Start()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("teste") {
                Port = 12345
            };

            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

            server = new NetServer(config);
            server.Start();

            players = new ArrayList();

            serverOnline = true;
            Program.frmServer.addLog("Servidor iniciado...");

            while (serverOnline) {
                ReceiveConnections();
                Application.DoEvents();
            }
        }

        public static void Shutdown()
        {
            server.Shutdown("Servidor será encerrado!");
            Program.frmServer.addLog("Servidor encerrado...");
            serverOnline = false;
        }

        private static void ReceiveConnections()
        {
            NetIncomingMessage incMessage = server.ReadMessage();

            if (incMessage == null) {
                return;
            }

            switch (incMessage.MessageType) {
                case NetIncomingMessageType.Data:
                    ForwardPacket(incMessage);
                    break;

                case NetIncomingMessageType.StatusChanged:
                    NetConnectionStatus status = (NetConnectionStatus)incMessage.ReadByte();
                    switch (status) {
                        case NetConnectionStatus.RespondedAwaitingApproval:
                            incMessage.SenderConnection.Approve();
                            break;

                        case NetConnectionStatus.Connected:
                            players.Add(incMessage.SenderConnection);

                            Program.frmServer.lstPlayers.Items.Add(incMessage.SenderConnection.RemoteEndpoint.ToString());
                            Program.frmServer.addLog(incMessage.SenderConnection.RemoteEndpoint.ToString() + ": Nova conexão!");
                            break;

                        case NetConnectionStatus.Disconnected:
                            players.Remove(incMessage.SenderConnection);

                            Program.frmServer.lstPlayers.Items.Remove(incMessage.SenderConnection.RemoteEndpoint.ToString());
                            Program.frmServer.addLog(incMessage.SenderConnection.RemoteEndpoint.ToString() + ": Conexão desfeita!");
                            break;
                    }
                    break;
            }

            server.Recycle(incMessage);
        }

    }
}
