namespace FlightSearchEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Register DatabaseHelper so it can be injected into controllers
            builder.Services.AddScoped<FlightSearchEngine.Data.DatabaseHelper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            // Set default route to Flight controller to avoid redirect errors when home is not present
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Flight}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
