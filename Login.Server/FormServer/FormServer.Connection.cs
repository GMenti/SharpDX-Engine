using Lidgren.Network;
using Network;
using System;
using System.Windows.Forms;

namespace Login.Server
{
    public partial class FormServer : Form
    {
        private NetServer server;
        private Boolean serverOnline;

        private void Start()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("teste") {
                Port = 12345
            };

            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

            server = new NetServer(config);
            server.Start();

            this.serverOnline = true;
            this.addLog("Servidor iniciado...");

            while (this.serverOnline) {
                ReceiveConnections();
                Application.DoEvents();
            }
        }

        private void Shutdown()
        {
            this.server.Shutdown("Servidor será encerrado!");
            this.addLog("Servidor encerrado...");
            this.serverOnline = false;
        }

        private void ReceiveConnections()
        {
            NetIncomingMessage incMessage;

            while ((incMessage = server.ReadMessage()) != null) {

                switch (incMessage.MessageType) {
                    case NetIncomingMessageType.Data:
                        switch (incMessage.ReadByte()) {
                            case (byte)PacketType.Login:
                                this.addLog("Login");
                                break;
                        }

                        break;

                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)incMessage.ReadByte();
                        switch (status) {
                            case NetConnectionStatus.RespondedAwaitingApproval:
                                incMessage.SenderConnection.Approve();
                                break;

                            case NetConnectionStatus.Connected:
                                this.addLog("Nova conexão realizada!");
                                break;

                            case NetConnectionStatus.Disconnected:
                                this.addLog("Conexão desfeita!");
                                break;
                        }
                        break;
                }

                server.Recycle(incMessage);
            }
        }

    }
}
