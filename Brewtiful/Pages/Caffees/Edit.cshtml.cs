using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brewtiful.Data;
using Brewtiful.Models;

namespace Brewtiful.Pages.Caffees
{
    public class EditModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public EditModel(Brewtiful.Data.BrewtifulContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Caffee Caffee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caffee =  await _context.Caffee.FirstOrDefaultAsync(m => m.ID == id);
            if (caffee == null)
            {
                return NotFound();
            }
            Caffee = caffee;
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "ID", "VendorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Caffee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaffeeExists(Caffee.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CaffeeExists(int id)
        {
            return _context.Caffee.Any(e => e.ID == id);
        }
    }
}
