namespace GamesStores.API.Entities;

public class Game
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Genre { get; set; }

    public decimal? Price { get; set; }

    public DateTimeOffset? ReleaseDate { get; set; }

    public string? ImageUri { get; set; }
}
