using System;
using Lidgren.Network;
using SharpDXEngine.Utilities.Helpers;

namespace SharpDXEngine.Libraries
{
    static class NetworkConnection
    {

        public static NetClient client;

        public static void Start()
        {
            var config = new NetPeerConfiguration("teste");
            client = new NetClient(config);
            client.Start();
            client.Connect(host: "127.0.0.1", port: 12345);
        }

        public static void ReceiveConnections()
        {
            NetIncomingMessage incMessage;

            while ((incMessage = client.ReadMessage()) != null) {

                switch (incMessage.MessageType) {
                    case NetIncomingMessageType.Data:
                        string data = incMessage.ReadString();
                        Debug.msgBox(incMessage.MessageType + ": " + data);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        Debug.msgBox(incMessage.MessageType + ": " + incMessage.SenderConnection.Status.ToString());
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        Console.WriteLine(incMessage.MessageType + ": " + incMessage.ReadString());
                        break;

                    default:
                        Console.WriteLine("Tipo inválido: " + incMessage.MessageType);
                        break;
                }

            }
        }

    }

}
