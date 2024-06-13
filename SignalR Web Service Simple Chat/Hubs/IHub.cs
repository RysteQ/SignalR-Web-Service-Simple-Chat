namespace SignalR_Web_Service_Simple_Chat.Hubs;

public interface IHub
{
    public void SendMessage(int userId, string message);
    public void BroadcastMessage(string message);
    public void GetUsers();
    public void MuteUser(int userId);
    public void UnmuteUser(int userId);
    public void KickUser(int userId);
}