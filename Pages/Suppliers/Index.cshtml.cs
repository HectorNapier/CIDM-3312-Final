using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductSuppliers.Models;

namespace CIDM_3312_Final.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly ProductSuppliers.Models.RazorPagesContext _context;

        public IndexModel(ProductSuppliers.Models.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = await _context.Suppliers
            .Include(s => s.ProductSuppliers) // Include ProductSuppliers if needed
                .ThenInclude(ps => ps.Product) // Then include Product
            .ToListAsync();

        }
    }
}
