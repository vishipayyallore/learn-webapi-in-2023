using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportPlusShop.API.Extensions;
using SportPlusShop.API.Models;
using SportPlusShop.API.Persistence;
using SportPlusShop.API.Queries;

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
    public async Task<ActionResult> GetAllProductsAsync([FromQuery] ProductQueryParameters queryParameters)
    {
        IQueryable<Product> products = _sportsShopDbContext.Products;

        if (queryParameters.MinPrice is not null)
        {
            products = products.Where(p => p.Price >= queryParameters.MinPrice.Value);
        }

        if (queryParameters.MaxPrice is not null)
        {
            products = products.Where(p => p.Price <= queryParameters.MaxPrice.Value);
        }

        if (!string.IsNullOrEmpty(queryParameters.Sku))
        {
            products = products.Where(p => p.Sku == queryParameters.Sku);
        }

        if (!string.IsNullOrEmpty(queryParameters.Name))
        {
            products = products.Where(p => p.Name!.ToLower().Contains(queryParameters.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(queryParameters.SortBy))
        {
            if (typeof(Product).GetProperty(queryParameters.SortBy) is not null)
            {
                products = products.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
            }
        }

        products = products.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

        return Ok(await products.ToListAsync());
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

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProductAsync([FromRoute] Guid id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _sportsShopDbContext.Entry(product).State = EntityState.Modified;

        try
        {
            await _sportsShopDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_sportsShopDbContext.Products.Any(p => p.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductAsync([FromRoute] Guid id)
    {
        var product = await _sportsShopDbContext.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _ = _sportsShopDbContext.Products.Remove(product);
        _ = await _sportsShopDbContext.SaveChangesAsync();

        return product;
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult> DeleteMultipleProductsAsync([FromQuery] Guid[] ids)
    {
        var products = new List<Product>();
        foreach (var id in ids)
        {
            var product = await _sportsShopDbContext.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            products.Add(product);
        }

        _sportsShopDbContext.Products.RemoveRange(products);
        await _sportsShopDbContext.SaveChangesAsync();

        return Ok(products);
    }

}


// [Route("/products/{id}")]
// [Route("/products/{id?}")] // Optional
