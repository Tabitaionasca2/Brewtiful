using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Brewtiful.Data;
using Brewtiful.Models;
using System.Net;
using System.Drawing.Drawing2D;

namespace Brewtiful.Pages.Caffees
{
    public class IndexModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public IndexModel(Brewtiful.Data.BrewtifulContext context)
        {
            _context = context;
        }

        public IList<Caffee> Caffee { get;set; } = default!;
        public CaffeeData CaffeeD { get; set; }
        public int CaffeeID { get; set; }
        public string NameSort { get; set; }
        public string BrandSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            CaffeeD = new CaffeeData();
            NameSort = String.IsNullOrEmpty(sortOrder) ? " name_desc " : "";
            BrandSort = sortOrder == "brand" ? "brand_desc" : "brand";
            CurrentFilter = searchString;

            CaffeeD.Caffees = await _context.Caffee
              //      .Include(b => b.Name)
                    .Include(b => b.Vendor)
                    .Include(b => b.CaffeeCategories)
                    .ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .OrderBy(b => b.Brand)
                    .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                CaffeeD.Caffees = CaffeeD.Caffees.Where(s => s.Brand.Contains(searchString) || s.Name.Contains(searchString));
            }

                switch (sortOrder) // functie de sortare
            {
                case " name_desc ":
                    CaffeeD.Caffees = CaffeeD.Caffees.OrderByDescending(s => s.Name);
                    break;
                case " brand_desc ":
                    CaffeeD.Caffees = CaffeeD.Caffees.OrderByDescending(s => s.Brand);
                    break;
                case "brand":
                    CaffeeD.Caffees = CaffeeD.Caffees.OrderBy(s => s.Brand);
                    break;
                default:
                    CaffeeD.Caffees = CaffeeD.Caffees.OrderBy(s => s.Name);
                    break;
            }
        }
    }
}
