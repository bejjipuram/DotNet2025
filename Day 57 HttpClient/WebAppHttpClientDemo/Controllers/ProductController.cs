using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebAppHttpClientDemo.Models;

public class ProductController : Controller
{
    private static readonly HttpClient client = new HttpClient();
    private readonly string apiUrl = "https://dummyjson.com/products";

    // GET PRODUCTS
    public async Task<IActionResult> Index()
    {
        ProductResponse responseData = new ProductResponse();

        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            responseData = JsonSerializer.Deserialize<ProductResponse>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        return View(responseData.Products);
    }

    // GET CREATE PAGE
    public IActionResult Create()
    {
        return View();
    }

    // POST CREATE PRODUCT
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        string json = JsonSerializer.Serialize(product);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(apiUrl + "/add", content);

        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

        TempData["ApiResponse"] = result;

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}