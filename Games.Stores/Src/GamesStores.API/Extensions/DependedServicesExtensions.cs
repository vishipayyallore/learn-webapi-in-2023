using GamesStores.API.Authorization;
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

        _ = services.AddAuthentication().AddJwtBearer();

        _ = services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.ReadAccess, builder => builder.RequireClaim("scope", "games:read"));
        });

        _ = services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.WriteAccess, builder =>
                                builder.RequireClaim("scope", "games:write")
                                        .RequireRole("Admin"));
        });

        return services;
    }

}
