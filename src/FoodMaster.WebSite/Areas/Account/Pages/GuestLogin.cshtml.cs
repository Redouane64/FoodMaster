using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Commands;
using FoodMaster.WebSite.Commands.LoginGuest;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Events;
using FoodMaster.WebSite.Filters;
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
        private readonly IMediator mediator;

        public GuestLoginModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public GuestCredentials GuestCredentials { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                if(ModelState.ContainsKey("GuestCredentials.BirthDate"))
                {
                    ModelState.Remove("GuestCredentials.BirthDate");
                    ModelState.AddModelError("GuestCredentials.BirthDate", "Invalid date.");
                }

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

            await mediator.Publish(new SignOutNotification(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage();
        }
    }
}