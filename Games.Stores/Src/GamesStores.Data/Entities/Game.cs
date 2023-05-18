using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesStores.Data.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required]
    [StringLength(20)]
    public string? Genre { get; set; }

    [Range(1, 100)]
    [Column(TypeName = "decimal(18,5)")]
    public decimal? Price { get; set; }

    public DateTimeOffset? ReleaseDate { get; set; }

    [Url]
    [StringLength(150)]
    public string? ImageUri { get; set; }
}
