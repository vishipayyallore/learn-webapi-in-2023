using GamesStores.ApplicationCore.Interfaces;
using GamesStores.Data.Dtos;
using GamesStores.Data.Entities;
using GamesStores.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GamesStores.API.Endpoints;

public static class GamesEndpoints
{

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gamesRouteGroup = routes.MapGroup(GameEndpointRoutes.Prefix).WithParameterValidation();

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.Root,
            ([FromServices] IGamesRepository gamesRepository, [FromServices] GamesStoreDbContext gamesStoreDbContext) => gamesRepository.GetAllGamesAsync().Select(game => game.AsDto()));

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.ActionById, Results<Ok<GameDto>, NotFound> ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            return gamesRepository.GetGameByIdAsync(id) is Game game ? TypedResults.Ok(game.AsDto()) : TypedResults.NotFound();
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

            gamesRepository.CreateGameAsync(game);

            return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game.AsDto());
        });

        _ = gamesRouteGroup.MapPut(GameEndpointRoutes.ActionById, ([FromServices] IGamesRepository gamesRepository, int id, UpdateGameDto updatedGameDto) =>
        {
            var existingGame = gamesRepository.GetGameByIdAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            gamesRepository.UpdateGameAsync(existingGame);

            return Results.NoContent();
        });

        _ = gamesRouteGroup.MapDelete(GameEndpointRoutes.ActionById, ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            var game = gamesRepository.GetGameByIdAsync(id);

            if (game is not null)
            {
                gamesRepository.DeleteGameAsync(id);

                return Results.NoContent();
            }

            return Results.NotFound();
        });

        return gamesRouteGroup;
    }

}
