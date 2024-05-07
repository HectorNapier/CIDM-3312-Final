using Microsoft.EntityFrameworkCore;

namespace ProductSuppliers.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSupplier>().HasKey(s => new {s.SupplierID, s.ProductID});
        }

        public DbSet<Supplier> Supplier {get; set;} = default!;
        public DbSet<Product> Product {get; set;} = default!; 
        public DbSet<ProductSupplier> ProductSupplier {get; set;} = default!;
    }
}