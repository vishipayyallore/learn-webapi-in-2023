namespace SportPlusShop.API.Models;

public class Category
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public virtual List<Product>? Products { get; set; }
}
