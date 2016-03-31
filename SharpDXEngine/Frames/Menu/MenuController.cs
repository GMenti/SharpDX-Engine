using Lidgren.Network;
using SharpDXEngine.Libraries;

namespace SharpDXEngine.Frames.Menu
{
    class MenuController
    {
        public void Login(string user, string password)
        {
            NetOutgoingMessage message = NetworkConnection.client.CreateMessage();
            message.Write(user + " - " + password);
            NetworkConnection.client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
