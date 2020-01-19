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

namespace FoodMaster.WebSite
{
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    public class RegisterModel : PageModel
    {
        private readonly IUsersService usersService;

        public RegisterModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var userId = Guid.NewGuid().ToString();
            var assignedRole = Roles.User.ToString();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, UserDetails.FullName),
                new Claim(ClaimTypes.Role, assignedRole)
            };

            var user = new User
            {
                Id = userId,
                UserName = UserDetails.UserName,
                FullName = UserDetails.FullName,
                BirthDate = UserDetails.BirthDate,
                Claims = new List<Claim>(claims),
                Role = assignedRole
            };

            usersService.Create(user, UserDetails.Password);

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            return RedirectToPagePermanent("Index");
        }

    }
}