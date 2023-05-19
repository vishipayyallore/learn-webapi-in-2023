using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GamesStores.Persistence.Extensions;

public static class PersistenceExtensions
{

    public static async Task InitializeGamesStoreDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        using var context = scope.ServiceProvider.GetService<GamesStoreDbContext>();

        await context?.Database?.MigrateAsync()!;
    }

}
