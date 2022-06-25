using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain.Menus
{
    public class MealIngredient
    {
        [Column("meal_id")]
        public int MealId { get; set; }
        public Meal Meal { get; set; }

        [Column("ingredient_id")]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}