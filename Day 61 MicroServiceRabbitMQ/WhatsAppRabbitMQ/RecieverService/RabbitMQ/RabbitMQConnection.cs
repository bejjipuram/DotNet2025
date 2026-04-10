using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;

namespace RecieverService.RabbitMQ;

public class RabbitMQConnection
{
    private readonly ConnectionFactory _factory;

    public RabbitMQConnection()
    {
        _factory = new ConnectionFactory()
        {
            HostName = "rabbitmq"
        };
    }

    public IConnection GetConnection()
    {
        return _factory.CreateConnection();
    }
}