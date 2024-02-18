using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Brewtiful.Data;
using Brewtiful.Models;

namespace Brewtiful.Pages.Caffees
{
    public class DeleteModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public DeleteModel(Brewtiful.Data.BrewtifulContext context)
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

            var caffee = await _context.Caffee.FirstOrDefaultAsync(m => m.ID == id);

            if (caffee == null)
            {
                return NotFound();
            }
            else
            {
                Caffee = caffee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caffee = await _context.Caffee.FindAsync(id);
            if (caffee != null)
            {
                Caffee = caffee;
                _context.Caffee.Remove(Caffee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
