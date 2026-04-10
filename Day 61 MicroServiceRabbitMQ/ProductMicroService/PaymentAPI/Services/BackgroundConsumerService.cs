using Microsoft.Extensions.Hosting;
using PaymentAPI.Messaging;

namespace PaymentAPI.Services;

public class BackgroundConsumerService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new RabbitMqConsumer();
        consumer.Start();

        return Task.CompletedTask;
    }
}