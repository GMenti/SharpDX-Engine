using Lidgren.Network;
using Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Server
{
    public partial class Form1 : Form
    {

        private NetServer server;
        private Boolean serverOnline;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.serverOnline = false;
        }

        private void btnOff_click(object sender, EventArgs e)
        {
            this.server.Shutdown("Servidor será encerrado!");
            this.addLog("Servidor encerrado...");
            this.serverOnline = false;
        }

        private void btnOn_Click(object sender, EventArgs e)
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

        private int lineCount = 1;
        private void addLog(string text)
        {
            txtLog.AppendText("[" + this.lineCount + "] " + text + Environment.NewLine);
            this.lineCount++;
        }

    }
}
