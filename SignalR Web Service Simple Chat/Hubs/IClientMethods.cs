namespace SignalR_Web_Service_Simple_Chat.Hubs;

public interface IClientMethods
{
    Task ReceiveMessage(string message);
    Task Kick();
}