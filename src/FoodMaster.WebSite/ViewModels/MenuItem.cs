namespace FoodMaster.WebSite.ViewModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public bool InCart { get; set; }
    }
}
