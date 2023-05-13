using System.ComponentModel.DataAnnotations;

namespace Music.Data.Entities;

public class Song
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Language { get; set; }
}
