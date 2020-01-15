﻿namespace FoodMaster.WebSite.ViewModels
{
    public class OrderItem
    {
        public Domain.Meal Meal { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
    }
}
