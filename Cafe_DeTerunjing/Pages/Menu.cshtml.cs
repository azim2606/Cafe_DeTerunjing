using Cafe_DeTerunjing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cafe_DeTerunjing.Pages
{
    public class Menu : PageModel
    {
        private readonly Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext _context;

        public Menu(Cafe_DeTerunjing.Data.Cafe_DeTerunjingContext context)
        {
            _context = context;
        }

        public IList<MenuS> MenuS { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MenuS != null)
            {
                MenuS = await _context.MenuS.ToListAsync();
            }
        }
    }
}
