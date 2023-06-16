using Microsoft.EntityFrameworkCore;
using SportPlusShop.API.Models;

namespace SportPlusShop.API.Persistence;

public static class ModelBuilderExtensions
{
    static readonly string[] _categoryIds = new[] { "15180bd4-eb9a-4ea8-8586-3fb0eb3d8b1a",
            "15180bd4-eb9a-4ea8-8586-3fb0eb3d8b1b", "15180bd4-eb9a-4ea8-8586-3fb0eb3d8b1c",
            "15180bd4-eb9a-4ea8-8586-3fb0eb3d8b1d", "15180bd4-eb9a-4ea8-8586-3fb0eb3d8b1e" };

    static Guid GetNewGuid() => Guid.NewGuid();

    public static void Seed(this ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Category>().HasData(
            new Category { Id = Guid.Parse(_categoryIds[0]), Name = "Active Wear - Men" },
            new Category { Id = Guid.Parse(_categoryIds[1]), Name = "Active Wear - Women" },
            new Category { Id = Guid.Parse(_categoryIds[2]), Name = "Mineral Water" },
            new Category { Id = Guid.Parse(_categoryIds[3]), Name = "Publications" },
            new Category { Id = Guid.Parse(_categoryIds[4]), Name = "Supplements" });

        _ = modelBuilder.Entity<Product>().HasData(
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "Polo Shirt", Sku = "AWMPS", Price = 35, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[0]), Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0, IsAvailable = false },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Ultra-Soft Tank Top", Sku = "AWWUTT", Price = 22, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[1]), Name = "V-Next T-Shirt", Sku = "AWWVNT", Price = 17, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[2]), Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.8M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[2]), Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.8M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[2]), Name = "Orange Mineral Water", Sku = "MWO", Price = 2.8M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[2]), Name = "Peach Mineral Water", Sku = "MWP", Price = 2.8M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[2]), Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.8M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[2]), Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.8M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[3]), Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Calcium 400 IU (150 tablets)", Sku = "SC400", Price = 9.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Flaxseed Oil 100 mg (90 capsules)", Sku = "SFO100", Price = 12.49M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Iron 65 mg (150 caplets)", Sku = "SI65", Price = 13.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Magnesium 250 mg (100 tablets)", Sku = "SM250", Price = 12.49M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Multi-Vitamin (90 capsules)", Sku = "SMV", Price = 9.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SVA", Price = 11.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Vitamin B-Complex (100 caplets)", Sku = "SVB", Price = 12.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SVC", Price = 9.99M, IsAvailable = true },
            new Product { Id = GetNewGuid(), CategoryId = Guid.Parse(_categoryIds[4]), Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SVD3", Price = 12.49M, IsAvailable = true });
    }
}
