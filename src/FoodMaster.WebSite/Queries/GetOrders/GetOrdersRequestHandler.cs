using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Queries.Common;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetOrders
{
    public class GetOrdersRequestHandler : IRequestHandler<GetOrdersRequest, Order[]>
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public GetOrdersRequestHandler(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public Task<Order[]> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            if(request.UserId is null)
            {
                return Task.FromResult(mapper.Map<Order[]>(ordersService.GetAll()));
            }
            else
            {
                return Task.FromResult(mapper.Map<Order[]>(ordersService.GetOrdersByUserId(request.UserId)));
            }
        }
    }
}
