using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("orders", false, false, false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var order = Encoding.UTF8.GetString(body);

    Console.WriteLine("Processing Order: " + order);

    // simulate work
    //Thread.Sleep(2000);

    Console.WriteLine("Order Processed");
};

channel.BasicConsume("orders", false, consumer);

Console.WriteLine("Waiting for orders...");
Console.ReadLine();