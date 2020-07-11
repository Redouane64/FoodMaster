﻿using System.Security.Claims;
using System.Threading.Tasks;
using FoodMaster.WebSite.Commands.RegisterUser;
using FoodMaster.WebSite.Filters;

using MediatR;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    public class RegisterModel : PageModel
    {
        private readonly IMediator mediator;

        public RegisterModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                if (ModelState.ContainsKey("UserDetails.BirthDate"))
                {
                    ModelState.Remove("UserDetails.BirthDate");
                    ModelState.AddModelError("UserDetails.BirthDate", "Invalid date.");
                }

                return Page();
            }

            var claims = await mediator.Send(UserDetails);

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            return RedirectToPagePermanent("Index");
        }

    }
}