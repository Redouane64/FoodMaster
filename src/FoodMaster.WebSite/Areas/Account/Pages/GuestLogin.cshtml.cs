using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Commands;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Filters;
using FoodMaster.WebSite.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Areas.Account.Pages
{
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    [BindProperties]
    public class GuestLoginModel : PageModel
    {
        private readonly IUsersService usersService;
        private readonly IMediator mediator;

        public GuestLoginModel(IUsersService usersService, IMediator mediator)
        {
            this.usersService = usersService;
            this.mediator = mediator;
        }

        public GuestCredentials GuestCredentials { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var claims = await mediator.Send(GuestCredentials);

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

            if (user.Role.Equals(Roles.Guest.ToString()))
            {
                usersService.Delete(user);
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage();
        }
    }
}