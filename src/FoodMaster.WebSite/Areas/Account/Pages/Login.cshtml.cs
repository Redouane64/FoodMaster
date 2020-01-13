using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Filters;
using FoodMaster.WebSite.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Areas.Account.Pages
{
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUsersService usersService;

        public LoginModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public GuestCredentials GuestCredentials { get; set; }

        public LoginCredentials LoginCredentials { get; set; }

        public async Task<IActionResult> OnPostGuestLoginAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var userId = Guid.NewGuid().ToString();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, GuestCredentials.FullName),
                new Claim(ClaimTypes.DateOfBirth, GuestCredentials.BirthDate.ToString())
            };

            var user = new User
            {
                Id = userId,
                FullName = GuestCredentials.FullName,
                BirthDate = GuestCredentials.BirthDate,
                Claims = new List<Claim>(claims)
            };
            
            usersService.Create(user);

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            return RedirectToPagePermanent("Index");
        }

        public async Task<IActionResult> OnPostUserLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = usersService.FindByUserName(LoginCredentials.UserName);

            if(user is null)
            {
                return Page();
            }

            if(!usersService.VerifyPassword(user, LoginCredentials.Password))
            {
                return Page();
            }


            var userId = Guid.NewGuid().ToString();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
            };

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            return RedirectToPagePermanent("Index");
        }

        public async Task<IActionResult> OnGetSignOutAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var user = usersService.Get(u => u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            usersService.Delete(user);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage();
        }
    }
}