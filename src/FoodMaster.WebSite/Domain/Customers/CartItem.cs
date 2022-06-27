using FoodMaster.WebSite.Domain.Menus;

namespace FoodMaster.WebSite.Domain.Customers
{
    public class CartItem
    {
        public int Id { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int Quantity { get; set; }
    }
}