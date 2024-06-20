using FirstDb.Interfaces;
using FirstDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstDb.Controllers;

[ApiController]
[Route("[controller]")]
public class MarketController : ControllerBase
{
    private readonly IApplicationDbContext _context;

    public MarketController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("addProduct")]
    public async Task AddProduct(string productName, string description, decimal price)
    {
        _context.Products.Add(new Product { ProductName = productName, Description = description, Price = price, QuantityInStock = 0 });
        await _context.SaveChangesAsync(new CancellationToken());
    }
    
    [HttpPost("updatePriceProduct/{id}")]
    public async Task UpdatePriceProduct(int id, decimal price)
    {
        var ff = _context.Products.SingleOrDefault(x => x.ProductID == id);
        if(ff != null)
        {
            ff.Price = price;
            await _context.SaveChangesAsync(new CancellationToken());
        }
    }
    
    [HttpGet("user/{id}")]
    public async Task GetAllOrders(int id)
    {
        var ff = await _context.Users
            .Where(x => x.UserID == id)
            .SelectMany(x=>x.Orders)
            .ToListAsync();
    }
    
    [HttpGet("product")]
    public async Task ProductInSclad()
    {
        var ff = await _context.Products
            .SumAsync(x=>x.QuantityInStock);
    }
    
    [HttpGet("priceOrder/{id}")]
    public async Task PriceOrder(int id)
    {
        var ff = await _context.Orders
            .Where(x => x.OrderId == id)
            .SelectMany(x => x.OrderDetails)
            .SumAsync(x => x.Product.Price);
    }
    
    [HttpGet("productMostPrice")]
    public async Task ProductMostPrice()
    {
        var ff = await _context.Products
            .OrderByDescending(x=>x.Price)
            .Take(5)
            .ToListAsync();
    }
    
    [HttpGet("productDeficit")]
    public async Task ProductDeficit()
    {
        var ff = await _context.Products
            .Where(x=>x.QuantityInStock < 5)
            .ToListAsync();
    }
}