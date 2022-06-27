using FoodMaster.WebSite.Domain.Customers;
using FoodMaster.WebSite.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodMaster.WebSite.Data
{
    public class FoodMasterDataContext : IdentityDbContext<User>
    {
        public FoodMasterDataContext(DbContextOptions<FoodMasterDataContext> options)
            : base(options)
        { }
    }
}
