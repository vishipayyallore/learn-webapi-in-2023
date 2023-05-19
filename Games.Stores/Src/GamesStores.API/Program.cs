using GamesStores.API.Endpoints;
using GamesStores.API.Extensions;
using GamesStores.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDependedServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Please use /Swagger to get details on GamesStores.API.");

await app.Services.InitializeGamesStoreDatabaseAsync();

app.MapGamesEndpoints();

app.Run();


// builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();
//builder.Services.AddSqlServer<GamesStoreDbContext>(
//    builder.Configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString));

//builder.Services.AddDbContext<GamesStoreDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString));
//});
