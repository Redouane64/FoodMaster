using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        public ICollection<UserClaim> Claims { get; set; }
        public ICollection<UserRole> Roles { get; set; }

    }
}