using Microsoft.EntityFrameworkCore;

namespace ProductSuppliers.Models
{
    public class RazorPagesContext : DbContext
    {
        public RazorPagesContext(DbContextOptions<RazorPagesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSupplier>().HasKey(ps => new { ps.SupplierID, ps.ProductID });
        }

        public DbSet<Supplier> Suppliers { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductSupplier> ProductSuppliers { get; set; } 
    }
}

