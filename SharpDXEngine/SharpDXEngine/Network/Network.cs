using Lidgren.Network;
using SharpDXEngine.Utilities.Helpers;
using SharpDXEngine.Frames.Menu;

namespace SharpDXEngine
{
    public static partial class Network
    {
        public static NetClient client;

        public static void Start()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("teste");
            client = new NetClient(config);
            client.Start();
        }

        public static void Connect()
        {
            client.Connect(host: "127.0.0.1", port: 12345);
        }

        public static void ReceiveConnections()
        {
            Login.lblStatus.caption = client.ConnectionStatus.ToString();

            switch (client.ConnectionStatus) {
                case NetConnectionStatus.None:
                case NetConnectionStatus.Connected:
                    ReceivePackets();
                    break;

                case NetConnectionStatus.Disconnected:
                    Connect();
                    break;
            }
        }

        private static void ReceivePackets()
        {
            NetIncomingMessage packet = client.ReadMessage();

            if (packet == null) {
                return;
            }

            switch (packet.MessageType) {
                case NetIncomingMessageType.Data:
                    ForwardPacket(packet);
                    break;
                
                case NetIncomingMessageType.StatusChanged:
                    NetConnectionStatus status= (NetConnectionStatus)packet.ReadByte();
                    Debug.msgBox(status.ToString());
                    break;
            }

            client.Recycle(packet);
        }

        public static bool IsConnected()
        {
            return (client.ConnectionStatus == NetConnectionStatus.Connected);
        }

    }

}
