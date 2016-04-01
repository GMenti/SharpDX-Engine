
namespace Network
{
    public enum ConnectionStatus
    {
        None = 0,
        Waiting = 1,
        Connected = 2,
        Disconnected = 3
    }

    public enum PacketType
    {
        Login,
        MenuError
    }
}
