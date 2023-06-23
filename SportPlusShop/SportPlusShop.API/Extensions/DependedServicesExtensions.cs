using Microsoft.EntityFrameworkCore;
using SportPlusShop.API.Persistence;

namespace SportPlusShop.API.Extensions;

public static class DependedServicesExtensions
{

    public static IServiceCollection ConfigureDependedServices(this IServiceCollection services)
    {
        _ = services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });

        _ = services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        _ = services.AddDbContext<SportsShopDbContext>(options =>
        {
            _ = options.UseInMemoryDatabase("SportsShop");
        });

        return services;
    }

}