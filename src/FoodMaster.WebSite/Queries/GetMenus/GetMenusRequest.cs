
using System.Collections.Generic;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetMenus
{
    public class GetMenusRequest : IRequest<IEnumerable<MenuViewModel>>
    {
    }
}
