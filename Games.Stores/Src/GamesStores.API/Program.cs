using GamesStores.API.Endpoints;
using GamesStores.ApplicationCore.Interfaces;
using GamesStores.Persistence;
using GamesStores.Persistence.Extensions;
using GamesStores.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();

//builder.Services.AddSqlServer<GamesStoreDbContext>(
//    builder.Configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString));

builder.Services.AddDbContext<GamesStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString));
});

var app = builder.Build();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

app.Services.InitializeGamesStoreDatabaseAsync();

app.MapGamesEndpoints();

app.Run();
