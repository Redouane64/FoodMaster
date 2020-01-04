using System.Collections.Generic;

namespace FoodMaster.WebSite.Domain
{
    public class Cart
    {
        public string UserId { get; set; }

        public ICollection<Meal> Meals { get; set; }

    }
}