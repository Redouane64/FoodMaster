using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace FoodMaster.WebSite.Domain
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PasswordHash { get; set; }

        [JsonIgnore]
        public ICollection<Claim> Claims { get; set; }

        public string Role { get; set; }

    }
}