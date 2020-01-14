using System;
using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    public class UserLoginModel : PageModel
    {

        private readonly IUsersService usersService;

        public UserLoginModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [BindProperty]
        public LoginCredentials LoginCredentials { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = usersService.FindByUserName(LoginCredentials.UserName);

            if (user is null)
            {
                ModelState.AddModelError("Invalid Credentials", "Invalid credentials.");
                return Page();
            }

            if (!usersService.VerifyPassword(user, LoginCredentials.Password))
            {
                ModelState.AddModelError("Invalid Credentials", "Invalid credentials.");
                return Page();
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            return RedirectToPagePermanent("Index");
        }

    }
}