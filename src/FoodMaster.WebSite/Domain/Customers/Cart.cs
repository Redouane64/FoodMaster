using System.Collections.Generic;

namespace FoodMaster.WebSite.Domain.Customers
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }

    }
}