using CartAPI.Messaging;
using CartAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly RabbitMqPublisher _publisher = new();

    [HttpPost("checkout")]
    public IActionResult Checkout()
    {
        var checkout = new CheckoutEvent
        {
            UserId = "user123",
            ProductIds = new List<string> { "1", "2" },
            TotalAmount = 70000
        };

        var correlationId = Guid.NewGuid().ToString(); // ⭐ generate

        _publisher.Publish(checkout, correlationId);

        return Ok(new
        {
            Message = "Checkout sent",
            CorrelationId = correlationId
        });
    }
}