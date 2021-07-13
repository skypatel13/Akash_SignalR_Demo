using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Akash_SignalR_Demo.Model
{
    public class LoopyHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var connectionId = Clients.All.SendAsync("Receive",Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
