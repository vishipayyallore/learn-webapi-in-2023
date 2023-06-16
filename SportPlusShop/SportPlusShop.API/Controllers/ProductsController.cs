using Microsoft.AspNetCore.Mvc;

namespace SportPlusShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    [HttpGet]
    public string GetAllProducts()
    {
        return "OK";
    }

    // [Route("/products/{id}")]
    // [Route("/products/{id?}")] // Optional

}
