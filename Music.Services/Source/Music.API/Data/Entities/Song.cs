using System.ComponentModel.DataAnnotations;

namespace Music.API.Data.Entities;

public class Song
{
    [Key]
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Language { get; set; }
}
