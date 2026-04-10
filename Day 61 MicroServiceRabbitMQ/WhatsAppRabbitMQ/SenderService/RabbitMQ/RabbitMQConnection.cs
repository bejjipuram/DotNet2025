using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;

namespace SenderService.RabbitMQ;

public class RabbitMQConnection
{
    private readonly ConnectionFactory _factory;

    public RabbitMQConnection()
    {
        _factory = new ConnectionFactory()
        {
            HostName = "rabbitmq" // important for docker
        };
    }

    public IConnection GetConnection()
    {
        return _factory.CreateConnection();
    }
}