using Microsoft.AspNetCore.SignalR;
using SignalR_Web_Service_Simple_Chat.Hubs;
using SignalR_Web_Service_Simple_Chat.Models;

namespace SignalR_Web_Service_Simple_Chat.Hubsl;

public class MainMessageHub : Hub<IClientMethods>
{
    public override Task OnConnectedAsync()
    {
        _users.Add(new()
        {
            UserId = _currentUserId,
            ConnectionId = Context.ConnectionId,
        });

        _currentUserId++;

        return base .OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _users.Remove(_users.Where(selectedUser => selectedUser.ConnectionId == Context.ConnectionId).First());

        return base.OnDisconnectedAsync(exception);
    }

    private List<UserViewModel> _users = [];
    private int _currentUserId;
}