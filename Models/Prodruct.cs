using System.ComponentModel.DataAnnotations;

namespace ProductSuppliers.Models
{
    public class Product
    {
        public int ProductID {get; set;}
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName {get; set;} = string.Empty;
        [Display(Name = "Part Number")]
        [Required]
        public string PartNumber {get; set;} = string.Empty;
        public List<ProductSupplier>? ProductSuppliers {get; set;} = default!; // Navigation Property. Product can have many suppliers

    }
}