using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSuppliers.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesContext>>()))
            {
                if (context.Products.Any() || context.Suppliers.Any() || context.ProductSuppliers.Any())
                {
                    return;   // Data already seeded
                }

                // Add sample products
                var products = new List<Product> {
                    new Product { ProductName = "NaCoL2", PartNumber = "1524" },
                };
                context.Products.AddRange(products);
                context.SaveChanges();

                // Add sample suppliers
                var suppliers = new List<Supplier> {
                    new Supplier { SupplierName = "West Coast Chemical" },
                };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                // Add product suppliers
                var productSuppliers = new List<ProductSupplier> {
                    new ProductSupplier { SupplierID = suppliers[0].SupplierID, ProductID = products[0].ProductID },
                };
                context.ProductSuppliers.AddRange(productSuppliers);
                context.SaveChanges();
            }
        }
    }
}
