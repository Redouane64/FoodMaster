using System;

using Microsoft.AspNetCore.Identity;

namespace FoodMaster.WebSite.Domain.Customers
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}