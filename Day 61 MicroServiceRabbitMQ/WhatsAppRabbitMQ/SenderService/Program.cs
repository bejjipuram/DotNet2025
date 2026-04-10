using SenderService.RabbitMQ;
using SenderService.Services;

namespace SenderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSingleton<RabbitMQConnection>();
            builder.Services.AddSingleton<IMessagePublisher, MessagePublisher>();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection(); ❌ removed

            app.UseAuthorization();

            app.MapControllers();

            // ✅ important for docker
            app.Urls.Add("http://0.0.0.0:80");

            app.Run();
        }
    }
}