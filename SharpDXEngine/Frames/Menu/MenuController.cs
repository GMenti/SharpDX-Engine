using Lidgren.Network;
using Network;
using Network.Library.Packets;

namespace SharpDXEngine.Frames.Menu
{
    class MenuController
    {
        public void Login(string user, string password)
        {
            LoginPacket packet = new LoginPacket() {
                login = user,
                password = password
            };

            Network.SendLogin(packet);
        }

    }
}
