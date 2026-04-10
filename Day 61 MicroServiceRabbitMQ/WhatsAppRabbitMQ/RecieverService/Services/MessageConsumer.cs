using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RecieverService.RabbitMQ;
using RecieverService.Services;
using RecieverService.Models;
using System.Text;
using System.Text.Json;

namespace RecieverService.Services;

public class MessageConsumer : IMessageConsumer
{
    private readonly IModel _channel;

    public MessageConsumer(RabbitMQConnection connection)
    {
        var conn = connection.GetConnection();
        _channel = conn.CreateModel();

        _channel.QueueDeclare("chat_queue", false, false, false);
    }

    public void Start()
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);

            var message = JsonSerializer.Deserialize<ChatMessage>(json);

            if (message != null)
            {
                Console.WriteLine($"📩 {message.Sender} → {message.Receiver}: {message.Message}");
            }
        };

        _channel.BasicConsume("chat_queue", true, consumer);
    }
}