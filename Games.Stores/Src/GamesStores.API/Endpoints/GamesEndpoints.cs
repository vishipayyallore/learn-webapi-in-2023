using GamesStores.API.Authorization;
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
            async Task<IEnumerable<GameDto>> ([FromServices] IGamesRepository gamesRepository, [FromServices] GamesStoreDbContext gamesStoreDbContext) =>
                (await gamesRepository.GetAllGamesAsync()).Select(game => game.AsDto()));

        _ = gamesRouteGroup.MapGet(GameEndpointRoutes.ActionById, async Task<Results<Ok<GameDto>, NotFound>> ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            return await gamesRepository.GetGameByIdAsync(id) is Game game ? TypedResults.Ok(game.AsDto()) : TypedResults.NotFound();
        })
        .WithName(GameEndpointNames.GetGameByIdName)
        .RequireAuthorization(Policies.ReadAccess);

        _ = gamesRouteGroup.MapPost(GameEndpointRoutes.Root, async Task<IResult> ([FromServices] IGamesRepository gamesRepository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri,
            };

            await gamesRepository.CreateGameAsync(game);

            return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game.AsDto());
        })
         .RequireAuthorization(Policies.WriteAccess);
        // Role Based
        //.RequireAuthorization(policy =>
        //{
        //    _ = policy.RequireRole("Admin");
        //});

        _ = gamesRouteGroup.MapPut(GameEndpointRoutes.ActionById, async Task<IResult> ([FromServices] IGamesRepository gamesRepository, int id, UpdateGameDto updatedGameDto) =>
        {
            var existingGame = await gamesRepository.GetGameByIdAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            await gamesRepository.UpdateGameAsync(existingGame);

            return Results.NoContent();
        })
        .RequireAuthorization(Policies.WriteAccess);

        _ = gamesRouteGroup.MapDelete(GameEndpointRoutes.ActionById, async Task<IResult> ([FromServices] IGamesRepository gamesRepository, int id) =>
        {
            var game = await gamesRepository.GetGameByIdAsync(id);

            if (game is not null)
            {
                await gamesRepository.DeleteGameAsync(id);

                return Results.NoContent();
            }

            return Results.NotFound();
        })
        .RequireAuthorization(Policies.WriteAccess);

        return gamesRouteGroup;
    }

}
