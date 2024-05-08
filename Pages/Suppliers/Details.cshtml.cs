using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductSuppliers.Models;

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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.Include(s => s.ProductSuppliers).ThenInclude(sc => sc.Product).FirstOrDefaultAsync(m => m.SupplierID == id);
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

            ProductSupplier ProductToDrop = _context.ProductSuppliers.Find(ProductIdToDelete, id.Value)!;

            if (ProductToDrop != null)
            {
                _context.Remove(ProductToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("No Products Here");
            }

            return RedirectToPage(new {id = id});
        }


    }
}
