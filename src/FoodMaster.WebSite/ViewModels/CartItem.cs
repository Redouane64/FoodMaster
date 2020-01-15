using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.ViewModels
{
    public class CartItem
    {
        public Domain.Meal Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
