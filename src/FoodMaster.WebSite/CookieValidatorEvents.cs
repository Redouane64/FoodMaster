using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FoodMaster.WebSite
{
    public class CookieValidatorEvents : CookieAuthenticationEvents
    {
        private readonly IUsersService usersService;

        public CookieValidatorEvents(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async override Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userId = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = usersService.GetById(userId);

            if(user == null)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await RedirectToLogin(new RedirectContext<CookieAuthenticationOptions>(context.HttpContext, context.Scheme, context.Options, context.Properties, "account/login"));
            }
        }
    }
}
