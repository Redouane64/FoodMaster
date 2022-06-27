namespace FoodMaster.WebSite.Domain.Menus
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }

    }
}