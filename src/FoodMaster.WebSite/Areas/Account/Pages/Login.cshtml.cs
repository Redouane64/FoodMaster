using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Areas.Account.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUsersService usersService;

        public LoginModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public LoginCredentials Credentials { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var userId = Guid.NewGuid().ToString();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, Credentials.FullName),
                new Claim(ClaimTypes.DateOfBirth, Credentials.BirthDate.ToString())
            };

            var user = new User
            {
                FullName = Credentials.FullName,
                BirthDate = Credentials.BirthDate,
                Claims = new List<Claim>(claims)
            };
            
            usersService.Create(user);

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