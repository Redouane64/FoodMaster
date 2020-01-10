using System;
using System.Collections.Generic;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.ViewModels
{
    public class Order
    {
        public string Id { get; set; }
        public string Client { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
