using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if any products exist
        if (context.Products.Any())
        {
            return; // Database has been seeded
        }

        var products = new Product[]
        {
            new Product { Name = "Product 1", Price = 19.99M, Description = "Description of Product 1", Stock = 100 },
            new Product { Name = "Product 2", Price = 29.99M, Description = "Description of Product 2", Stock = 50 },
            new Product { Name = "Product 3", Price = 39.99M, Description = "Description of Product 3", Stock = 0 }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}