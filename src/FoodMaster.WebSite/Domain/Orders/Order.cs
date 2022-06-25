using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using FoodMaster.WebSite.Domain.Customers;

namespace FoodMaster.WebSite.Domain.Orders
{
    public class Order
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        [Column("status")]
        public OrderStatus Status { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("comment")]
        public string Comment { get; set; }
    }
}