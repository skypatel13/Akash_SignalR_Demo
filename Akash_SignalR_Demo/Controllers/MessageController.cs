using Akash_SignalR_Demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Akash_SignalR_Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<LoopyHub> loopyHub;
        public MessageController(IHubContext<LoopyHub> loopyHub)
        {
            this.loopyHub = loopyHub;
        }
        [HttpGet]
        public IActionResult ServerTimeAsync()
        {
            ServerDateTime serverDateTime = new ServerDateTime();
            loopyHub.Clients.All.SendAsync("serverTime", "Server Time is:" + serverDateTime.CurrentDateTime.ToString());
            return Ok();
        }
        [HttpGet]
        [Route("{messege}")]
        public IActionResult SendMessage(string messege)
        {
            loopyHub.Clients.All.SendAsync("SendMessage", messege);
            return Ok();
        }
        [HttpGet]
        [Route("{messege}/{connectionId}")]
        public IActionResult SendMessageToSpecificID(string messege, string connectionId)
        {
            loopyHub.Clients.Client(connectionId).SendAsync("SendMessageToSpecificID", messege);
            return Ok();
        }
    }
}
