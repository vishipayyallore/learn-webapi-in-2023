using GamesStores.API.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

List<Game> games = new()
{
    new Game { Id = 1, Name = "Street Fight II", Genre ="Fighting", Price = 18.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" },
    new Game { Id = 2, Name = "Final Fantasy XIV", Genre ="Roleplaying", Price = 19.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" },
    new Game { Id = 3, Name = "FIFA 2023", Genre ="Sports", Price = 20.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var gamesRouteGroup = app.MapGroup(GameEndpointRoutes.Prefix).WithParameterValidation();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

gamesRouteGroup.MapGet(GameEndpointRoutes.Root, () => games);

gamesRouteGroup.MapGet(GameEndpointRoutes.ActionById, Results<Ok<Game>, NotFound> (int id) =>
{
    return games.Find(game => game.Id == id) is Game game ? TypedResults.Ok(game) : TypedResults.NotFound();
})
.WithName(GameEndpointNames.GetGameByIdName);

gamesRouteGroup.MapPost(GameEndpointRoutes.Root, (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;

    games.Add(game);

    return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game);
});

gamesRouteGroup.MapPut(GameEndpointRoutes.ActionById, (int id, Game updatedGame) =>
{
    var existingGame = games.Find(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();
});

gamesRouteGroup.MapDelete(GameEndpointRoutes.ActionById, (int id) =>
{
    var game = games.Find(game => game.Id == id);

    if (game is not null)
    {
        games.Remove(game);

        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
