using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SportPlusShop.API.Persistence;

namespace SportPlusShop.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            app.UseSwaggerUI(options =>
            {
                //foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                //{
                //    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                //        description.GroupName.ToUpperInvariant());
                //}

                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });

            /*
             * Conclusion: If you are using migrations there is context.Database.Migrate(). 
             * If you don't want migrations and just want a quick database (usually for testing) 
             * then use context.Database.EnsureCreated()/EnsureDeleted().
             */
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