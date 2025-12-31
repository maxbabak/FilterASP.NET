namespace filterASP.NET.Controllers;

using Microsoft.AspNetCore.Mvc;
using filterASP.NET.Models;
using filterASP.NET.Filters;

[ApiController]
[Route("products")]
[ServiceFilter(typeof(AuthFilter))]
[ServiceFilter(typeof(LogFilter))]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 1000 },
        new Product { Id = 2, Name = "Phone", Price = 700 },
        new Product { Id = 3, Name = "TV", Price = 1700 }
    ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id)
                      ?? throw new Exception("Product not found");

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        product.Id = Products.Max(p => p.Id) + 1;
        Products.Add(product);

        return Ok(product);
    }
}