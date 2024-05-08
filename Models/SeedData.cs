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

                // Add products
                var products = new List<Product> {
                    new Product { ProductName = "Sodium chloride", PartNumber = "1524" },
                    new Product { ProductName = "Hydrogen peroxide", PartNumber = "1725" },
                    new Product { ProductName = "Ethanol", PartNumber = "10534" },
                    new Product { ProductName = "Sulfuric acid", PartNumber = "1845" },

                };
                context.Products.AddRange(products);
                context.SaveChanges();

                // Add suppliers
                var suppliers = new List<Supplier> {
                    new Supplier { SupplierName = "West Coast Chemical" },
                    new Supplier { SupplierName = "IPC Brothers" },
                    new Supplier { SupplierName = "Baytown Blending" },
                    new Supplier { SupplierName = "Chevron Phillips" },
                };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                // Add product suppliers
                var productSuppliers = new List<ProductSupplier> {
                    new ProductSupplier { SupplierID = suppliers[0].SupplierID, ProductID = products[0].ProductID },
                    new ProductSupplier { SupplierID = suppliers[1].SupplierID, ProductID = products[1].ProductID },
                    new ProductSupplier { SupplierID = suppliers[2].SupplierID, ProductID = products[2].ProductID },
                    new ProductSupplier { SupplierID = suppliers[3].SupplierID, ProductID = products[3].ProductID },
                };
                context.ProductSuppliers.AddRange(productSuppliers);
                context.SaveChanges();
            }
        }
    }
}
