using CartAPI.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace CartAPI.Messaging;

public class RabbitMqPublisher
{
    public void Publish(CheckoutEvent checkout, string correlationId)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("checkout-queue", false, false, false);

        var message = JsonSerializer.Serialize(checkout);
        var body = Encoding.UTF8.GetBytes(message);

        var props = channel.CreateBasicProperties();
        props.CorrelationId = correlationId; // ⭐ IMPORTANT

        channel.BasicPublish(
            exchange: "",
            routingKey: "checkout-queue",
            basicProperties: props,
            body: body);
    }
}