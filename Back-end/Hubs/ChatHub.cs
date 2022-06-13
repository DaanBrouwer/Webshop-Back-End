using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.Hubs;

namespace WhiteLabelWebshopS3.API
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
