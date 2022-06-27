using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using FoodMaster.WebSite.Areas.Dashboard.Pages;
using FoodMaster.WebSite.Domain.Customers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Areas.Account.Pages;

public class LoginPage : PageModel
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public LoginPage(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [Required]
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [BindProperty]
    public string Email { get; set; }

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [BindProperty]
    public string? Password { get; set; }

    [Display(Name = "Remember Me")]
    [BindProperty]
    public bool RememberMe { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await userManager.FindByEmailAsync(Email);
        if (user is null)
        {
            ModelState.AddModelError(String.Empty, "Incorrect credentials");
            return Page();
        }

        var signInResult = await signInManager.PasswordSignInAsync(
            user,
            Password,
            RememberMe,
            lockoutOnFailure: false);


        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError(String.Empty, "Incorrect credentials");
            return Page();
        }

        return RedirectToPagePermanent(nameof(IndexPage), routeValues: new { area = nameof(Dashboard) });
    }

    public async Task<IActionResult> OnPostSignOutAsync()
    {
        await signInManager.SignOutAsync();
        return RedirectToPagePermanent(nameof(LoginPage), routeValues: new { area = nameof(Account) });
    }
}