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
    public class DetailsModel : PageModel
    {
        private readonly Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext _context;

        public DetailsModel(Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext context)
        {
            _context = context;
        }

      public MenuS MenuS { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MenuS == null)
            {
                return NotFound();
            }

            var menus = await _context.MenuS.FirstOrDefaultAsync(m => m.Id == id);
            if (menus == null)
            {
                return NotFound();
            }
            else 
            {
                MenuS = menus;
            }
            return Page();
        }
    }
}
