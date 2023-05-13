using System.ComponentModel.DataAnnotations;

namespace Music.Data.Dtos;

public class AddSongDto
{
    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Language { get; set; }
}
