using GamesStores.ApplicationCore.Interfaces;
using GamesStores.Persistence;
using GamesStores.Repositories;

namespace GamesStores.API.Extensions;

public static class DependedServicesExtensions
{

    public static IServiceCollection ConfigureDependedServices(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSqlServer<GamesStoreDbContext>(
                        configuration.GetConnectionString(ConfigurationConnectionStrings.GamesStoreConnectionString));

        _ = services.AddScoped<IGamesRepository, GamesRepository>();

        return services;
    }

}
