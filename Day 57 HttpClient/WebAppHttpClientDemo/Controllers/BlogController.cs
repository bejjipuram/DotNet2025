using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebAppHttpClientDemo.Models;

public class BlogController : Controller
{
    private static readonly HttpClient _client = new HttpClient();
    private readonly string _baseUrl = "https://jsonplaceholder.typicode.com/posts";

    public async Task<IActionResult> Index()
    {
        List<Post> posts = new List<Post>();

        HttpResponseMessage response = await _client.GetAsync(_baseUrl);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();

            posts = JsonSerializer.Deserialize<List<Post>>(data, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
        }

        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Post newPost)
    {
        // Convert object to JSON
        string jsonPayload = JsonSerializer.Serialize(newPost);

        // Prepare request body
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // Send POST request
        HttpResponseMessage response = await _client.PostAsync(_baseUrl, content);

        // 🔹 Add these lines here
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        TempData["ApiResponse"] = result;

        if (response.IsSuccessStatusCode)
        {
            TempData["Success"] = "Post created successfully!";
            return RedirectToAction("Index");
        }
        
        return View();
    }
}