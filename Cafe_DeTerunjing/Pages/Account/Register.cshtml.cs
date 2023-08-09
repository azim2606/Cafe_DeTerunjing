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

        public RegisterModel(
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
                Task<bool> hasRegUserRole = _roleManager.RoleExistsAsync("Admin");
                hasRegUserRole.Wait();

                if(!hasRegUserRole.Result)
                {
                    var roleResult = _roleManager.CreateAsync(new IdentityRole("Admin"));
                    roleResult.Wait();
                }
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userInManager.CreateAsync(user,Input.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    Task<IdentityResult> newUserRole = _userInManager.AddToRoleAsync(user, "Admin");
                    newUserRole.Wait();

                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }



    }
}
