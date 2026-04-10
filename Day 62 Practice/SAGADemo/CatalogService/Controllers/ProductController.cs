using Microsoft.AspNetCore.Mvc;
using CatalogService.Models;
using System.Net.Http.Json;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "A high-performance laptop." },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99m, Description = "A latest-gen smartphone." },
            new Product { Id = 3, Name = "Headphones", Price = 79.99m, Description = "Noise-cancelling headphones." },
            new Product { Id = 4, Name = "Tablet", Price = 299.99m, Description = "A lightweight tablet." },
            new Product { Id = 5, Name = "Smartwatch", Price = 199.99m, Description = "A smartwatch with health tracking." },
            new Product { Id = 6, Name = "Bluetooth Speaker", Price = 49.99m, Description = "Portable Bluetooth speaker." },
            new Product { Id = 7, Name = "Gaming Console", Price = 399.99m, Description = "Next-gen gaming console." },
            new Product { Id = 8, Name = "Wireless Mouse", Price = 29.99m, Description = "Ergonomic wireless mouse." },
            new Product { Id = 9, Name = "Keyboard", Price = 59.99m, Description = "Mechanical keyboard." },
            new Product { Id = 10, Name = "Monitor", Price = 199.99m, Description = "24-inch HD monitor." }
        };
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] List<int> productIds)
        {
            var selectedProducts = Products.Where(p => productIds.Contains(p.Id)).ToList();
            if (!selectedProducts.Any())
                return BadRequest("No valid products selected.");

            var client = _httpClientFactory.CreateClient();
            // Replace with your actual CartService URL
            var cartServiceUrl = "https://localhost:5002/cart/add";

            var response = await client.PostAsJsonAsync(cartServiceUrl, selectedProducts);
            if (response.IsSuccessStatusCode)
                return Ok("Products added to cart.");
            else
                return StatusCode((int)response.StatusCode, "Failed to add products to cart.");
        }
    }
}
