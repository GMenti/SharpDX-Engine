using Lidgren.Network;
using System;

namespace Server
{

    class Program
    {

        static NetServer server;

        static void Main(string[] args)
        {
            Start();

            while (true) {
                ReceiveConnections();
            }
        }

        static void Start()
        {
            var config = new NetPeerConfiguration("teste") {
                Port = 12345
            };

            server = new NetServer(config);
            server.Start();

            Console.WriteLine("Server iniciado...");
        }

        static void ReceiveConnections()
        {
            NetIncomingMessage incMessage;

            while ((incMessage = server.ReadMessage()) != null) {

                switch (incMessage.MessageType) {
                    case NetIncomingMessageType.Data:
                        string data = incMessage.ReadString();
                        Console.WriteLine(incMessage.MessageType + ": " + data);

                        NetOutgoingMessage message = server.CreateMessage();
                        message.Write("Recebido");
                        server.SendMessage(message, incMessage.SenderConnection, NetDeliveryMethod.ReliableOrdered);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        Console.WriteLine(incMessage.MessageType + ": " + incMessage.SenderConnection.Status.ToString());
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
