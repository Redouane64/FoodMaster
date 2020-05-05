using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    public class UserLoginModel : PageModel
    {
        private readonly IMediator mediator;

        public UserLoginModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [BindProperty]
        public LoginCredentials LoginCredentials { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var claims = await mediator.Send(LoginCredentials);

            if (claims is null)
            {
                ModelState.AddModelError("Invalid Credentials", "Invalid credentials.");
                return Page();
            }

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            return RedirectToPagePermanent("Index");
        }

    }
}