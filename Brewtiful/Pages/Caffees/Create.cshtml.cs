using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Brewtiful.Data;
using Brewtiful.Models;
using System.Security.Policy;

namespace Brewtiful.Pages.Caffees
{
    public class CreateModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public CreateModel(Brewtiful.Data.BrewtifulContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "ID", "VendorName");
            return Page();
        }

        [BindProperty]
        public Caffee Caffee { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Caffee.Add(Caffee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
