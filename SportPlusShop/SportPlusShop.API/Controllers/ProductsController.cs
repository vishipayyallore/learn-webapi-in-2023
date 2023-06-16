using Microsoft.AspNetCore.Mvc;
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
    public IEnumerable<Product> GetAllProducts()
    {
        return _sportsShopDbContext.Products.ToArray();
    }

}


// [Route("/products/{id}")]
// [Route("/products/{id?}")] // Optional
