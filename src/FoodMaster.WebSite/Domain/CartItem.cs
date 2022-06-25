using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class CartItem
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("meal_id")]
        public int MealId { get; set; }
        public Meal Meal { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}