﻿using GamesStores.API.Core.Interfaces;
using GamesStores.API.Data.Dtos;
using GamesStores.API.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GamesStores.API.Endpoints;

public static class GamesEndpoints
{

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gamesRouteGroup = routes.MapGroup(GameEndpointRoutes.Prefix).WithParameterValidation();

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.Root,
            ([FromServices] IGamesRepository gamesRepository) => gamesRepository.GetAllGames().Select(game => game.AsDto()));

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.ActionById, Results<Ok<GameDto>, NotFound> ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            return gamesRepository.GetGameById(id) is Game game ? TypedResults.Ok(game.AsDto()) : TypedResults.NotFound();
        })
        .WithName(GameEndpointNames.GetGameByIdName);

        _ = gamesRouteGroup.MapPost(GameEndpointRoutes.Root, ([FromServices] IGamesRepository gamesRepository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri,
            };

            gamesRepository.CreateGame(game);

            return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game.AsDto());
        });

        _ = gamesRouteGroup.MapPut(GameEndpointRoutes.ActionById, ([FromServices] IGamesRepository gamesRepository, int id, Game updatedGame) =>
        {
            var existingGame = gamesRepository.GetGameById(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            gamesRepository.UpdateGame(existingGame);

            return Results.NoContent();
        });

        _ = gamesRouteGroup.MapDelete(GameEndpointRoutes.ActionById, ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            var game = gamesRepository.GetGameById(id);

            if (game is not null)
            {
                gamesRepository.DeleteGame(id);

                return Results.NoContent();
            }

            return Results.NotFound();
        });

        return gamesRouteGroup;
    }

}
