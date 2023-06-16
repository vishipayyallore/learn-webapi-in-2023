using SportPlusShop.API.Persistence;

namespace SportPlusShop.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            using IServiceScope scope = app.Services.CreateScope();
            using var _sportsShopDbContext = scope.ServiceProvider.GetService<SportsShopDbContext>();
            _ = _sportsShopDbContext?.Database.EnsureCreated();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapGet("/", () => "Please use /swagger to see the SportPlusShop.API documentation.");

        return app;
    }
}