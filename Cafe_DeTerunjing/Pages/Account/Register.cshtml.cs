using Cafe_DeTerunjing.Data;
using Cafe_DeTerunjing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cafe_DeTerunjing.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Registration Input { get; set; }
        private Cafe_DeTerunjingContext _db;
        private readonly UserManager<ApplicationUser> _userInManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegistrationModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            Cafe_DeTerunjingContext db)

        {
            _userInManager = userManager; 
            _signInManager = signInManager; 
            _roleManager = roleManager;
            _logger = logger;
            _db = db;

        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                Task
            }
        }



    }
}
