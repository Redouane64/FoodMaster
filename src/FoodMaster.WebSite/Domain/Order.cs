using System.Collections.Generic;

namespace FoodMaster.WebSite.Domain
{
    public class Order
    {
        public string UserId { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public OrderStatus Status { get; set; }
    }
}