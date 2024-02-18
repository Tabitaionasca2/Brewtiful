using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Brewtiful.Data;
using Brewtiful.Models;

namespace Brewtiful.Pages.Vendors
{
    public class DeleteModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public DeleteModel(Brewtiful.Data.BrewtifulContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.FirstOrDefaultAsync(m => m.ID == id);

            if (vendor == null)
            {
                return NotFound();
            }
            else
            {
                Vendor = vendor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor != null)
            {
                Vendor = vendor;
                _context.Vendor.Remove(Vendor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
