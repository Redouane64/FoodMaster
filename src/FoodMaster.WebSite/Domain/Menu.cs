using System.Collections.Generic;

namespace FoodMaster.WebSite.Domain
{
    public class Menu
    {
        public int Category { get; set; }
        public ICollection<Domain.Meal> Meals { get; set; }
    }
}
