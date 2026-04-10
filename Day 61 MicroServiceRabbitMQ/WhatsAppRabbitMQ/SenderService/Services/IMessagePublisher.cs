using SenderService.Models;
namespace SenderService.Services
{
    public interface IMessagePublisher
    {
        void PublishMessage(ChatMessage message);
    }
}
