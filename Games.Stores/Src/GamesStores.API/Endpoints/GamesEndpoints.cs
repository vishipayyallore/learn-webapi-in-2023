using GamesStores.API.Core.Interfaces;
using GamesStores.API.Data.Entities;
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

        _ = gamesRouteGroup.MapPost(GameEndpointRoutes.Root, ([FromServices] IGamesRepository gamesRepository, Game game) =>
        {
            gamesRepository.CreateGame(game);

            return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game);
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
