using Microsoft.AspNetCore.Mvc;
using SenderService.Models;
using SenderService.Services;

namespace SenderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessagePublisher _publisher;

    public MessageController(IMessagePublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public IActionResult Send(ChatMessage message)
    {
        message.Timestamp = DateTime.Now;
        message.CorrelationId = Guid.NewGuid().ToString();

        _publisher.PublishMessage(message);

        return Ok("Message Sent");
    }
}