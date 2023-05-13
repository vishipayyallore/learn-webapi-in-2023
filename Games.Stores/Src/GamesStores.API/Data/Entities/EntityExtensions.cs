﻿using GamesStores.API.Data.Dtos;

namespace GamesStores.API.Data.Entities;

public static class EntityExtensions
{

    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }

}
