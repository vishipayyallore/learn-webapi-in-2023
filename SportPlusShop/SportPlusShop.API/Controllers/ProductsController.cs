using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportPlusShop.API.Models;
using SportPlusShop.API.Persistence;

namespace SportPlusShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly SportsShopDbContext _sportsShopDbContext;

    public ProductsController(SportsShopDbContext sportsShopDbContext)
    {
        _sportsShopDbContext = sportsShopDbContext ?? throw new ArgumentNullException(nameof(sportsShopDbContext));
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<Product>> GetAllProductsAsync()
    {
        return await _sportsShopDbContext.Products.ToListAsync();
    }

}


// [Route("/products/{id}")]
// [Route("/products/{id?}")] // Optional
