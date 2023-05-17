using System.ComponentModel.DataAnnotations;

namespace GamesStores.Data.Dtos;

public record CreateGameDto(

    [Required][StringLength(50)] string? Name,

    [Required][StringLength(20)] string? Genre,

    [Range(1, 100)] decimal? Price,

    DateTimeOffset? ReleaseDate,

    [Url][StringLength(150)] string? ImageUri
);
