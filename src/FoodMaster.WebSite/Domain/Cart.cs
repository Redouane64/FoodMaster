using System.Collections.Generic;

namespace FoodMaster.WebSite.Domain
{
    public class Cart
    {
        public string UserId { get; set; }

        public ICollection<CartItem> Items { get; set; }

    }
}