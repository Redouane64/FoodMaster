using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMaster.WebSite.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int SelectedQuantity { get; set; }
    }
}
