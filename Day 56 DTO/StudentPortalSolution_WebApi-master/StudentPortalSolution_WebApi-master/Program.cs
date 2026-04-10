using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("StudentPortalApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]!);
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback =
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});

builder.Services.AddHttpClient<ApiClientService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]!);
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback =
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});

var app = builder.Build();

// A simple Fluent chain for a GET request
app.MapGet("/books/{id}", (int id) =>
{
    return Results.Ok(new { Id = id, Title = "The Great Gatsby" });
})
.WithName("GetBookById")
.WithSummary("Retrieves a single book by its unique ID");

app.Run();



//___________________________


// A Fluent chain for a POST request
app.MapPost("/books", (CourseVm newCourse) =>
{
    // Logic to save the book to a database would go here
    return Results.Created($"/books/{newCourse.CourseId}", newCourse);
})
.WithName("CreateBook")
.Accepts<CourseVm>("application/json")
.Produces<CourseVm>(201);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();