using FoodMaster.WebSite.Queries.Common;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetOrderDetails
{
    public class GetOrderDetailsRequest : IRequest<Order>
    {
        public string OrderId { get; set; }
    }
}
