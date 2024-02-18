using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Brewtiful.Models;

namespace Brewtiful.Data
{
    public class BrewtifulContext : DbContext
    {
        public BrewtifulContext (DbContextOptions<BrewtifulContext> options)
            : base(options)
        {
        }

        public DbSet<Brewtiful.Models.Caffee> Caffee { get; set; } = default!;
        public DbSet<Brewtiful.Models.Vendor> Vendor { get; set; } = default!;
    }
}
