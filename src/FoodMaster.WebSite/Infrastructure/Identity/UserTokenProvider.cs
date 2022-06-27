using System.Threading.Tasks;

using FoodMaster.WebSite.Domain.Customers;

using Microsoft.AspNetCore.Identity;

namespace FoodMaster.WebSite.Infrastructure.Identity;

public class UserTokenProvider : TotpSecurityStampBasedTokenProvider<User>
{
    public static readonly string ProviderName = "UserTokenProvider";

    public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<User> manager, User user)
    {
        return Task.FromResult(false);
    }
}