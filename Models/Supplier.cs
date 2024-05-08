using System.ComponentModel.DataAnnotations;

namespace ProductSuppliers.Models
{
    public class Supplier
    {
        public int SupplierID {get; set;} // Primary Key
        [Required]
        public string SupplierName {get; set;} = string.Empty;
        public List<ProductSupplier> ProductSuppliers {get; set;} = default!; // Navigation Property. Supplier can have MANY products
    }

    public class ProductSupplier
    {
        public int SupplierID {get; set;}     // Composite Primary Key, Foreign Key 1
        public int ProductID {get; set;}    // Composite Primary Key, Foreign Key 2
        public Product Product {get; set;} = default!; // Navigation Property. One Product per ProductSuplier
        public Supplier Supplier {get; set;} = default!;   // Navigation Property. One supplier per ProductSuplier
    }
}