using System;
using System.Collections.Generic;

namespace FoodMaster.WebSite.Domain
{
    public class Order
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public OrderStatus Status { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}