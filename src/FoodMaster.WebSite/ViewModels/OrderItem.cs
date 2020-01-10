using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.ViewModels
{
    public class OrderItem
    {
        public Meal Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
    }
}
