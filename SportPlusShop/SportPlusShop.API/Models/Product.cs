using System.Text.Json.Serialization;

namespace SportPlusShop.API.Models;

public class Product
{
    public Guid Id { get; set; }

    public string? Sku { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public Guid CategoryId { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
