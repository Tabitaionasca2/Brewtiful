using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Brewtiful.Data;
using Brewtiful.Models;

namespace Brewtiful.Pages.Vendors
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
            return Page();
        }

        [BindProperty]
        public Vendor Vendor { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vendor.Add(Vendor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
