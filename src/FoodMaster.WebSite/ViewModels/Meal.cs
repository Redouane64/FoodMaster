using System.Collections.Generic;

namespace FoodMaster.WebSite.ViewModels
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public bool InCart { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public float Calories { get; set; }
    }
}
