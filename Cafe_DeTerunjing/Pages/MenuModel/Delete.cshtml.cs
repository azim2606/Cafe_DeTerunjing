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
    public class DeleteModel : PageModel
    {
        private readonly Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext _context;

        public DeleteModel(Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MenuS == null)
            {
                return NotFound();
            }
            var menus = await _context.MenuS.FindAsync(id);

            if (menus != null)
            {
                MenuS = menus;
                _context.MenuS.Remove(MenuS);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
