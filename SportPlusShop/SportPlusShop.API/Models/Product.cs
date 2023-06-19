using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportPlusShop.API.Models;

public class Product
{
    public Guid Id { get; set; }

    [Required]
    public string? Sku { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
