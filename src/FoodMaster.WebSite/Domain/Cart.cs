using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class Cart
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }

    }
}