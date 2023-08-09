using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafe_DeTerunjing.Data;
using Cafe_DeTerunjing.Models;

namespace Cafe_DeTerunjing.Pages.MenuModel
{
    public class EditModel : PageModel
    {
        private readonly Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext _context;

        public EditModel(Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext context)
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

            var menus =  await _context.MenuS.FirstOrDefaultAsync(m => m.Id == id);
            if (menus == null)
            {
                return NotFound();
            }
            MenuS = menus;
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

            _context.Attach(MenuS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuSExists(MenuS.Id))
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

        private bool MenuSExists(int id)
        {
          return (_context.MenuS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
