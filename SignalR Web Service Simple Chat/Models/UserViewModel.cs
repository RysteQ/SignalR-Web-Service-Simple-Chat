namespace SignalR_Web_Service_Simple_Chat.Models;

public record UserViewModel
{
    public required int UserId { get; set; }
    public required string ConnectionId { get; set; }
}