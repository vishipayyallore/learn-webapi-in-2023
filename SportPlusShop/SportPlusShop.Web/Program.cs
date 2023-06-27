using Microsoft.EntityFrameworkCore;
using SportPlusShop.Web.Areas.Identity.Data;
using SportPlusShop.Web.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SportPlusShopWebContextConnection") ?? throw new InvalidOperationException("Connection string 'SportPlusShopWebContextConnection' not found.");

builder.Services.AddDbContext<SportPlusShopWebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SportPlusShopWebUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SportPlusShopWebContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
