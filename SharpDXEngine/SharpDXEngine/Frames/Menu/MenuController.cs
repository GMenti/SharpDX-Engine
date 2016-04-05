using Network.Library.Packets;

namespace SharpDXEngine.Frames.Menu
{
    static class MenuController
    {
        public static void Login(string user, string password)
        {
            AccountData data = new AccountData() {
                login = user,
                password = password
            };

            Network.SendLogin(data);
        }

    }
}
