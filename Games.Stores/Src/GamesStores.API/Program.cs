using GamesStores.API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using static GamesStores.API.Core.Common.Constants;

List<Game> games = new()
{
    new Game { Id = 1, Name = "Street Fight II", Genre ="Fighting", Price = 18.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" },
    new Game { Id = 2, Name = "Final Fantasy XIV", Genre ="Roleplaying", Price = 19.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" },
    new Game { Id = 3, Name = "FIFA 2023", Genre ="Sports", Price = 20.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", Results<Ok<Game>, NotFound> (int id) =>
{
    return games.Find(game => game.Id == id) is Game game ? TypedResults.Ok(game) : TypedResults.NotFound();
})
.WithName(GameEndpointNames.GetGameByIdName);

app.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;

    games.Add(game);

    return Results.CreatedAtRoute(GameEndpointNames.GetGameByIdName, new { id = game.Id }, game);
});

app.Run();
