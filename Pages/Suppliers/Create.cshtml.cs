using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using ProductSuppliers.Models;

namespace CIDM_3312_Final.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly ProductSuppliers.Models.RazorPagesContext _context;
            public CreateModel(ProductSuppliers.Models.RazorPagesContext context, ILogger<CreateModel> logger)
            {
                _context = context;
                _logger = logger; 

            }
        [BindProperty]
        public Supplier Supplier { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

            _logger.LogWarning("On Post Called");

            _context.Suppliers.Add(Supplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
