using Network.Library.Packets;

namespace SharpDXEngine.Frames.Menu
{
    class MenuController
    {
        public void Login(string user, string password)
        {
            AccountData data = new AccountData() {
                login = user,
                password = password
            };

            Network.SendLogin(data);
        }

    }
}
