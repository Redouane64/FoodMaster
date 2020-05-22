using FoodMaster.WebSite.Queries.Common;
using MediatR;

namespace FoodMaster.WebSite.Queries.GetOrders
{
    public class GetOrdersRequest : IRequest<Order[]>
    {
        public string UserId { get; set; }

    }
}
