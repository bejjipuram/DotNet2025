using PaymentAPI.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PaymentAPI.Messaging;

public class RabbitMqConsumer
{
    public void Start()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare("checkout-queue", false, false, false);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var checkout = JsonSerializer.Deserialize<CheckoutEvent>(message);

            var correlationId = ea.BasicProperties.CorrelationId; // ⭐ read

            Console.WriteLine($"[CorrelationId: {correlationId}] Payment Processing for {checkout.UserId}");
        };

        channel.BasicConsume("checkout-queue", true, consumer);
    }
}