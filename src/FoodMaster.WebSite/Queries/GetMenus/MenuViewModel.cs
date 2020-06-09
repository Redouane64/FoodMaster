using System.Collections.Generic;
using FoodMaster.WebSite.Queries.Common;
using MediatR;

namespace FoodMaster.WebSite.Queries.GetMenus
{
    public class MenuViewModel : IRequest
    {
        public string Category { get; set; }
        public IEnumerable<MealViewModel> Meals { get; set; }
    }
}
