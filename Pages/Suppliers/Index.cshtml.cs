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
        // paging
        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        //Sorting:
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;

        public IList<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Suppliers.Select(p => p);
            switch (CurrentSort)
                {

                    case "first_asc": 
                        query = query.OrderBy(p => p.SupplierName);
                        break;

                }



            Supplier = await query.Skip((PageNum-1)*PageSize).Take(PageSize).Include(s => s.ProductSuppliers).ThenInclude(ps => ps.Product).ToListAsync();

        }
    }
}
