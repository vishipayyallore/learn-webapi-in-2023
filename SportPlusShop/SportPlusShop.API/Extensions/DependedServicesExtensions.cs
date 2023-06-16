using Microsoft.EntityFrameworkCore;
using SportPlusShop.API.Persistence;

namespace SportPlusShop.API.Extensions;

public static class DependedServicesExtensions
{

    public static IServiceCollection ConfigureDependedServices(this IServiceCollection services)
    {
        _ = services.AddDbContext<SportsShopDbContext>(options =>
        {
            _ = options.UseInMemoryDatabase("SportsShop");
        });

        _ = services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        return services;
    }

}