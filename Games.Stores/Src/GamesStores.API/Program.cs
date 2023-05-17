using GamesStores.API.Core.Interfaces;
using GamesStores.API.Endpoints;
using GamesStores.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();

var connectionString = builder.Configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString);

var app = builder.Build();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

app.MapGamesEndpoints();

app.Run();
