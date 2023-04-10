using Microsoft.EntityFrameworkCore;
using Music.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MusicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicDbConnectionString")));

_ = builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // TODO: To be removed once we have .sqlproj
    using var scope = app.Services.CreateAsyncScope();
    using var context = scope.ServiceProvider.GetService<MusicDbContext>();

    if (!await context!.Database.CanConnectAsync())
    {
        _ = await context!.Database.EnsureCreatedAsync();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
