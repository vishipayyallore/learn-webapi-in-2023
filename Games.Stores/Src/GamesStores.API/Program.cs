using GamesStores.API.Endpoints;
using GamesStores.ApplicationCore.Interfaces;
using GamesStores.Persistence;
using GamesStores.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();

builder.Services.AddSqlServer<GamesStoreDbContext>(
    builder.Configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString));

var app = builder.Build();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

app.MapGamesEndpoints();

app.Run();
