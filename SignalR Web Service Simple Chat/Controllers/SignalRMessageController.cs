using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Web_Service_Simple_Chat.Hubs;
using SignalR_Web_Service_Simple_Chat.Hubsl;
using SignalR_Web_Service_Simple_Chat.Models;

namespace SignalR_Web_Service_Simple_Chat.Controllers;

[ApiController]
[Route("[controller]/v1")]
public class SignalRMessageController : ControllerBase
{
    public SignalRMessageController(IHubContext<MainMessageHub, IClientMethods> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost("users/{userId}/message/{message}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public IActionResult SendMessage(int userId, string message)
    {
        UserViewModel? user = MainMessageHub.Users.Where(selectedUser => selectedUser.UserId == userId).FirstOrDefault();

        if (user == null)
            return BadRequest($"User with ID {userId} was not found");

        _hubContext.Clients.Client(user.ConnectionId).ReceiveMessage(message);

        return Ok();
    }

    [HttpPost("users/message/{message}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult BroadcastMessage(string message)
    {
        _hubContext.Clients.All.ReceiveMessage(message);

        return Ok();
    }

    [HttpGet("users/")]
    [ProducesResponseType<List<UserViewModel>>(StatusCodes.Status200OK)]
    public IActionResult GetUsers()
    {
        return Ok(MainMessageHub.Users);
    }

    [HttpDelete("users/{userId}/kick/{reason}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult KickUser(int userId, string reason = "No reason specified")
    {
        UserViewModel? user = MainMessageHub.Users.Where(selectedUser => selectedUser.UserId == userId).FirstOrDefault();

        if (user == null)
            return BadRequest($"User with ID {userId} was not found");

        _hubContext.Clients.Client(user.ConnectionId).Kick(reason);

        return Ok();
    }

    private IHubContext<MainMessageHub, IClientMethods> _hubContext;
}