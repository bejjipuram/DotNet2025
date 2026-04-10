using RecieverService.Services;

namespace RecieverService.BackgroundServices;

public class RabbitMQListener : BackgroundService
{
    private readonly IMessageConsumer _consumer;

    public RabbitMQListener(IMessageConsumer consumer)
    {
        _consumer = consumer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Start();
        return Task.CompletedTask;
    }
}