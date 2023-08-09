using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cafe_DeTerunjing.Data;
using Cafe_DeTerunjing.Models;

namespace Cafe_DeTerunjing.Pages.MenuModel
{
    public class CreateModel : PageModel
    {
        private readonly Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext _context;

        public CreateModel(Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MenuS MenuS { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MenuS == null || MenuS == null)
            {
                return Page();
            }

            _context.MenuS.Add(MenuS);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
