namespace Music.API.Entities;

public class Song
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Language { get; set; }
}
