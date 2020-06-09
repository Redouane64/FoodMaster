using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetMenus
{
    public class GetMenusRequestHandler : IRequestHandler<GetMenusRequest, IEnumerable<MenuViewModel>>
    {
        private readonly IMealsService mealsService;
        private readonly IMapper mapper;

        public GetMenusRequestHandler(IMealsService mealsService, IMapper mapper)
        {
            this.mealsService = mealsService;
            this.mapper = mapper;
        }

        public Task<IEnumerable<MenuViewModel>> Handle(GetMenusRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(mapper.Map<IEnumerable<MenuViewModel>>(mealsService.GetAllGroupedByCategory()));
        }
    }
}
