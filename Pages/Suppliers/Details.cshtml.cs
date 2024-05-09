using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductSuppliers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIDM_3312_Final.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly ProductSuppliers.Models.RazorPagesContext _context;

        public DetailsModel(ProductSuppliers.Models.RazorPagesContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger; 
        }


        public Supplier Supplier { get; set; } = default!;

        [BindProperty]
        public int ProductIdToDelete {get; set;}

        [BindProperty]
        
        [Display(Name = "Product")]
        public int ProductIdToAdd {get; set;}
        public List<Product> AllProducts {get; set;} = default!;
        public SelectList ProductsDropDown {get; set;} = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.Include(s => s.ProductSuppliers).ThenInclude(sc => sc.Product).FirstOrDefaultAsync(m => m.SupplierID == id);
            AllProducts = await _context.Products.ToListAsync();
            ProductsDropDown = new SelectList(AllProducts.Select(p => new { p.ProductID, DisplayText = $"{p.ProductName} - {p.PartNumber}" }), "ProductID", "DisplayText");

            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                Supplier = supplier;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteProductAsync(int? id)
        {
            _logger.LogWarning($"OnPost: SupplierId {id}, DROP Product {ProductIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.Include(s => s.ProductSuppliers!).ThenInclude(sc => sc.Product).FirstOrDefaultAsync(m => m.SupplierID == id);
            
            if (supplier == null)
            {
                return NotFound();
            }

            ProductSupplier? productToDrop = _context.ProductSuppliers.FirstOrDefault(sc => sc.ProductID == ProductIdToDelete && sc.SupplierID == id);

            if (productToDrop != null)
            {
                _context.Remove(productToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("No Products Here");
            }

            return RedirectToPage(new {id = id});
        }

        
        //on post for Add Product below here
            public async Task<IActionResult> OnPostAsync(int? id)
            {
                _logger.LogWarning($"OnPost: SupplierId {id}, ADD Product {ProductIdToAdd}");
                if (ProductIdToAdd == 0)
                {
                    ModelState.AddModelError("ProductIdToAdd", "This field is a required field.");
                    return Page();
                }
                if (id == null)
                {
                    return NotFound();
                }

                var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == ProductIdToAdd);            
                
                if (product == null)
                {
                    return NotFound();
                }

                if (!_context.ProductSuppliers.Any(sc => sc.ProductID == ProductIdToAdd && sc.SupplierID == id.Value))
                {
                    var productSupplierToAdd = new ProductSupplier { SupplierID = id.Value, ProductID = ProductIdToAdd };
                    _context.Add(productSupplierToAdd);
                    _context.SaveChanges();
                }
                else
                {
                    _logger.LogWarning("Product already in the Supplier's inventory");
                }

                return RedirectToPage(new { id = id });
            }


    }
}
