using SportPlusShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDependedServices();

var app = builder.Build();

app.ConfigureHttpRequestPipeline();

app.Run();
