using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace FoodMaster.WebSite.Domain
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Claim> Claims { get; set; }

    }
}