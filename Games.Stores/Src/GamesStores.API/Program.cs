using GamesStores.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

app.MapGamesEndpoints();

app.Run();
