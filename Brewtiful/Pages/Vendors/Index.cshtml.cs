using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Brewtiful.Data;
using Brewtiful.Models;
using System.Security.Policy;

namespace Brewtiful.Pages.Vendors
{
    public class IndexModel : PageModel
    {
        private readonly Brewtiful.Data.BrewtifulContext _context;

        public IndexModel(Brewtiful.Data.BrewtifulContext context)
        {
            _context = context;
        }

        public IList<Vendor> Vendor { get;set; } = default!;
        public VendorIndexData VendorData { get; set; }
        public int VendorID { get; set; }
        public int CaffeeID { get; set; }
        public async Task OnGetAsync(int? id, int? CaffeeID)
        {
            VendorData = new VendorIndexData();
            VendorData.Vendors = await _context.Vendor
           .Include(i => i.Caffees)
           .OrderBy(i => i.VendorName)
           .ToListAsync();
            if (id != null)
            {
                VendorID = id.Value;
                Vendor vendor = VendorData.Vendors
                .Where(i => i.ID == id.Value).Single();
                VendorData.Caffees = vendor.Caffees;
            }
        }
    }
}
