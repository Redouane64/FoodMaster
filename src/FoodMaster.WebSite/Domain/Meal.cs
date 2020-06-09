using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodMaster.WebSite.Domain
{
    public class Meal
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("menu_id")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public IEnumerable<MealIngredient> Ingredients { get; set; }

        [Column("calories")]
        public float Calories { get; set; }

    }
}