using System.Collections.Generic;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Models
{
    public class CategoryMenu<TMenuItem>
    {
        public Category Category { get; set; }
        public IEnumerable<TMenuItem> Menu { get; set; }
    }
}
