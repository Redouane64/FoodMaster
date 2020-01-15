using System.Collections.Generic;

namespace FoodMaster.WebSite.ViewModels
{
    public class Menu
    {
        public string Category { get; set; }
        public IEnumerable<ViewModels.Meal> Meals { get; set; }
    }
}
