using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cafe_DeTerunjing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cafe_DeTerunjing.Data
{
    public class Cafe_DeTerunjingContext : IdentityDbContext<ApplicationUser>
    {
        public Cafe_DeTerunjingContext (DbContextOptions<Cafe_DeTerunjingContext> options)
            : base(options)
        {
        }

        public DbSet<Cafe_DeTerunjing.Models.MenuS> MenuS { get; set; } = default!;
    }
}
