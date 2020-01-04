using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Models
{
    public class CartItem
    {
        public Meal Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
