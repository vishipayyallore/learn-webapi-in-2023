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
    public async Task<ActionResult> GetAllProductsAsync()
    {
        return Ok(await _sportsShopDbContext.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductByIdAsync([FromRoute] Guid id)
    {
        return await _sportsShopDbContext.Products.FindAsync(id) is Product product
                        ? Ok(product) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> AddProductAsync([FromBody] Product product)
    {
        _ = await _sportsShopDbContext.Products.AddAsync(product);
        _ = await _sportsShopDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllProductsAsync), new { id = product.Id }, product);
    }

}


// [Route("/products/{id}")]
// [Route("/products/{id?}")] // Optional
