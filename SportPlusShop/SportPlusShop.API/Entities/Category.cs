using System.ComponentModel.DataAnnotations;

namespace SportPlusShop.API.Entities;

public class Category
{
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public virtual List<Product>? Products { get; set; }
}
