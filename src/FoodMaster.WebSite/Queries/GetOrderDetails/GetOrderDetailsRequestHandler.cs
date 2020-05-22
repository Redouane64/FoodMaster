using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Queries.Common;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetOrderDetails
{
    public class GetOrderDetailsRequestHandler : IRequestHandler<GetOrderDetailsRequest, Order>
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public GetOrderDetailsRequestHandler(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public Task<Order> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var order = ordersService.Get(order => order.Id == request.OrderId);

            if (order == null)
            {
                return Task.FromResult(default(Order));
            }

            return Task.FromResult(mapper.Map<Order>(order));
        }
    }
}
