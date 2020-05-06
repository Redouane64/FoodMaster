using System.Collections.Generic;

using FoodMaster.WebSite.ViewModels;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetMenus
{
    public class MenuViewModel : IRequest
    {
        public string Category { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}
