namespace GamesStores.Data.Dtos;

public record GameDto(
    int Id,

    string? Name,

    string? Genre,

    decimal? Price,

    DateTimeOffset? ReleaseDate,

    string? ImageUri
);
