using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe_DeTerunjing.Data;
using Cafe_DeTerunjing.Models;

namespace Cafe_DeTerunjing.Pages.MenuModel
{
    public class IndexModel : PageModel
    {
        private readonly Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext _context;

        public IndexModel(Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext context)
        {
            _context = context;
        }

        public IList<MenuS> MenuS { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MenuS != null)
            {
                MenuS = await _context.MenuS.ToListAsync();
            }
        }
    }
}
