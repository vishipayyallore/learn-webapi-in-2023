using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult> GetAllProductsAsync()
    {
        return Ok(await _sportsShopDbContext.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductByIdAsync(Guid id)
    {
        var product = await _sportsShopDbContext.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

}


// [Route("/products/{id}")]
// [Route("/products/{id?}")] // Optional
