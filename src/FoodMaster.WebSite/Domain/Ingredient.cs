using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class Ingredient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        public ICollection<MealIngredient> Meals { get; set; }

    }
}