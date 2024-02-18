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
    public class DetailsModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public DetailsModel(Brewtiful.Data.BrewtifulContext context)
        {
            _context = context;
        }

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
    }
}
