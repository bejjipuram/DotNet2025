using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Model;

namespace ProductCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> products = new()
    {
        new Product { Id = "1", Name = "Laptop", Price = 50000 },
        new Product { Id = "2", Name = "Phone", Price = 20000 }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(products);

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        return product == null ? NotFound() : Ok(product);
    }
}