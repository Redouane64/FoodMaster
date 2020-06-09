using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class Role
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
