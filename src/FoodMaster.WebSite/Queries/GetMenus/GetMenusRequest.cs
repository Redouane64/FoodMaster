
using MediatR;

namespace FoodMaster.WebSite.Queries.GetMenus
{
    public class GetMenusRequest : IRequest<MenuViewModel[]>
    {
    }
}
