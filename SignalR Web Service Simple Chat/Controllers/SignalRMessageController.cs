using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Web_Service_Simple_Chat.Hubs;
using SignalR_Web_Service_Simple_Chat.Hubsl;

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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult SendMessage(int userId, string message)
    {
        return Ok();
    }

    [HttpPost("users/message/{message}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult BroadcastMessage(string message)
    {
        return Ok();
    }

    [HttpGet("users/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUsers()
    {
        return Ok();
    }

    [HttpPatch("users/{userId}/mute")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult MuteUser(int userId)
    {
        return Ok();
    }

    [HttpPatch("users/{userId}/unmute")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UnmuteUser(int userId)
    {
        return Ok();
    }

    [HttpDelete("users/{userId}/kick/{reason}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult KickUser(int userId, string reason = "No reason specified")
    {
        return Ok();
    }

    private IHubContext<MainMessageHub, IClientMethods> _hubContext;
}