﻿using System.ComponentModel.DataAnnotations.Schema;

using FoodMaster.WebSite.Domain.Menus;

namespace FoodMaster.WebSite.Domain.Orders
{
    public class OrderItem
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("meal_id")]
        public int MealId { get; set; }
        public Dish Dish { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}