using GamesStores.API.Core.Interfaces;
using GamesStores.API.Data.Entities;
using GamesStores.API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GamesStores.API.Endpoints;

public static class GamesEndpoints
{

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gamesRouteGroup = routes.MapGroup(GameEndpointRoutes.Prefix).WithParameterValidation();

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.Root, ([FromServices] IGamesRepository gamesRepository) => gamesRepository.GetAllGames());

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.ActionById, Results<Ok<Game>, NotFound> ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            return gamesRepository.GetGameById(id) is Game game ? TypedResults.Ok(game) : TypedResults.NotFound();
        })
        .WithName(GameEndpointNames.GetGameByIdName);

        _ = gamesRouteGroup.MapPost(GameEndpointRoutes.Root, (Game game) =>
        {
            inMemoryGamesRepository.CreateGame(game);

            return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game);
        });

        _ = gamesRouteGroup.MapPut(GameEndpointRoutes.ActionById, (int id, Game updatedGame) =>
        {
            var existingGame = inMemoryGamesRepository.GetGameById(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            inMemoryGamesRepository.UpdateGame(existingGame);

            return Results.NoContent();
        });

        _ = gamesRouteGroup.MapDelete(GameEndpointRoutes.ActionById, (int id) =>
        {
            var game = inMemoryGamesRepository.GetGameById(id);

            if (game is not null)
            {
                inMemoryGamesRepository.DeleteGame(id);

                return Results.NoContent();
            }

            return Results.NotFound();
        });

        return gamesRouteGroup;
    }

}
