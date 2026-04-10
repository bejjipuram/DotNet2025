using RabbitMQ.Client;
using SenderService.Models;
using SenderService.RabbitMQ;
using SenderService.Services;
using System.Text;
using System.Text.Json;

namespace SenderService.Services;

public class MessagePublisher : IMessagePublisher
{
    private readonly IModel _channel;

    public MessagePublisher(RabbitMQConnection connection)
    {
        var conn = connection.GetConnection();
        _channel = conn.CreateModel();

        _channel.QueueDeclare("chat_queue", false, false, false);
    }

    public void PublishMessage(ChatMessage message)
    {
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        _channel.BasicPublish("", "chat_queue", null, body);
    }
}