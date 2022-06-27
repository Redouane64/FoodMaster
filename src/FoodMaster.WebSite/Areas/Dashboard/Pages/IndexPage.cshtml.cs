using FoodMaster.WebSite.Infrastructure.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Areas.Dashboard.Pages;

[Authorize(Roles = "Administrator")]
public class IndexPage : PageModel
{
    public void OnGet()
    {

    }
}