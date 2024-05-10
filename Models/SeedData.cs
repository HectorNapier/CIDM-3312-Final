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
                    new Product { ProductName = "Acetic acid", PartNumber = "2646" },
                    new Product { ProductName = "Calcium carbonate", PartNumber = "3177" },
                    new Product { ProductName = "Ammonium nitrate", PartNumber = "4288" },
                    new Product { ProductName = "Methanol", PartNumber = "5399" },
                    new Product { ProductName = "Potassium hydroxide", PartNumber = "6410" },
                    new Product { ProductName = "Sodium hydroxide", PartNumber = "7521" },
                    new Product { ProductName = "Nitric acid", PartNumber = "8632" },
                    new Product { ProductName = "Phosphoric acid", PartNumber = "9743" },
                    new Product { ProductName = "Citric acid", PartNumber = "10854" },
                    new Product { ProductName = "Ammonia", PartNumber = "11965" },
                    new Product { ProductName = "Sodium carbonate", PartNumber = "12076" },
                    new Product { ProductName = "Magnesium sulfate", PartNumber = "13187" },
                    new Product { ProductName = "Acetone", PartNumber = "14298" },
                    new Product { ProductName = "Sodium hypochlorite", PartNumber = "15409" },
                    new Product { ProductName = "Ethylene glycol", PartNumber = "16520" },
                    new Product { ProductName = "Hydrochloric acid", PartNumber = "17631" },
                    new Product { ProductName = "Potassium chloride", PartNumber = "18742" },
                    new Product { ProductName = "Sodium sulfate", PartNumber = "19853" },
                    new Product { ProductName = "Calcium chloride", PartNumber = "20964" },
                    new Product { ProductName = "Sodium hydroxide", PartNumber = "21075" },
                    new Product { ProductName = "Formic acid", PartNumber = "22186" },
                    

                };
                context.Products.AddRange(products);
                context.SaveChanges();

                // Add suppliers
                var suppliers = new List<Supplier> {
                    new Supplier { SupplierName = "West Coast Chemical" },
                    new Supplier { SupplierName = "IPC Brothers" },
                    new Supplier { SupplierName = "Baytown Blending" },
                    new Supplier { SupplierName = "Chevron Phillips" },
                    new Supplier { SupplierName = "Chemical Supply Co." },
                    new Supplier { SupplierName = "Global Chemicals" },
                    new Supplier { SupplierName = "EcoChem" },
                    new Supplier { SupplierName = "Industrial Chemicals" },
                    new Supplier { SupplierName = "Chemical Solutions" },
                    new Supplier { SupplierName = "Chem Innovations" },
                    new Supplier { SupplierName = "Specialty Chemicals" },
                    new Supplier { SupplierName = "Green Chemicals" },
                    new Supplier { SupplierName = "Chemical Distribution" },
                    new Supplier { SupplierName = "PureChem" },
                    new Supplier { SupplierName = "SafeChem" },
                    new Supplier { SupplierName = "Chem Dynamics" },
                    new Supplier { SupplierName = "ProChem" },
                    new Supplier { SupplierName = "EnviroChem" },
                    new Supplier { SupplierName = "AgroChem" },
                    new Supplier { SupplierName = "Chem Express" },
                    new Supplier { SupplierName = "United Chemicals" },
                    new Supplier { SupplierName = "ChemTech" },
                    new Supplier { SupplierName = "BioChem" },
                    new Supplier { SupplierName = "Chemical Co." },
                    new Supplier { SupplierName = "CCP LLC." }

                };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                // Add product suppliers
                var productSuppliers = new List<ProductSupplier> {
                    new ProductSupplier { SupplierID = suppliers[0].SupplierID, ProductID = products[0].ProductID },
                    new ProductSupplier { SupplierID = suppliers[1].SupplierID, ProductID = products[1].ProductID },
                    new ProductSupplier { SupplierID = suppliers[2].SupplierID, ProductID = products[2].ProductID },
                    new ProductSupplier { SupplierID = suppliers[3].SupplierID, ProductID = products[3].ProductID },
                    new ProductSupplier { SupplierID = suppliers[4].SupplierID, ProductID = products[4].ProductID },
                    new ProductSupplier { SupplierID = suppliers[5].SupplierID, ProductID = products[5].ProductID },
                    new ProductSupplier { SupplierID = suppliers[6].SupplierID, ProductID = products[6].ProductID },
                    new ProductSupplier { SupplierID = suppliers[7].SupplierID, ProductID = products[7].ProductID },
                    new ProductSupplier { SupplierID = suppliers[8].SupplierID, ProductID = products[8].ProductID },
                    new ProductSupplier { SupplierID = suppliers[9].SupplierID, ProductID = products[9].ProductID },
                    new ProductSupplier { SupplierID = suppliers[10].SupplierID, ProductID = products[10].ProductID },
                    new ProductSupplier { SupplierID = suppliers[11].SupplierID, ProductID = products[11].ProductID },
                    new ProductSupplier { SupplierID = suppliers[12].SupplierID, ProductID = products[12].ProductID },
                    new ProductSupplier { SupplierID = suppliers[13].SupplierID, ProductID = products[13].ProductID },
                    new ProductSupplier { SupplierID = suppliers[14].SupplierID, ProductID = products[14].ProductID },
                    new ProductSupplier { SupplierID = suppliers[15].SupplierID, ProductID = products[15].ProductID },
                    new ProductSupplier { SupplierID = suppliers[16].SupplierID, ProductID = products[16].ProductID },
                    new ProductSupplier { SupplierID = suppliers[17].SupplierID, ProductID = products[17].ProductID },
                    new ProductSupplier { SupplierID = suppliers[18].SupplierID, ProductID = products[18].ProductID },
                    new ProductSupplier { SupplierID = suppliers[19].SupplierID, ProductID = products[19].ProductID },
                    new ProductSupplier { SupplierID = suppliers[20].SupplierID, ProductID = products[20].ProductID },
                    new ProductSupplier { SupplierID = suppliers[21].SupplierID, ProductID = products[21].ProductID },
                    new ProductSupplier { SupplierID = suppliers[22].SupplierID, ProductID = products[22].ProductID },
                    new ProductSupplier { SupplierID = suppliers[23].SupplierID, ProductID = products[23].ProductID },
                    new ProductSupplier { SupplierID = suppliers[24].SupplierID, ProductID = products[24].ProductID },

                    
                };
                context.ProductSuppliers.AddRange(productSuppliers);
                context.SaveChanges();
            }
        }
    }
}
