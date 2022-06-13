using System.Threading.Tasks;

namespace WhiteLabelWebshopS3.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
