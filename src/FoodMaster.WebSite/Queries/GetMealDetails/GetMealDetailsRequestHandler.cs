using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Queries.Common;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetMealDetails
{
    public class GetMealDetailsRequestHandler : IRequestHandler<GetMealDetailsRequest, MealViewModel>
    {
        private readonly IMealsService mealsService;
        private readonly IMapper mapper;

        public GetMealDetailsRequestHandler(IMealsService mealsService, IMapper mapper)
        {
            this.mealsService = mealsService;
            this.mapper = mapper;
        }

        public Task<MealViewModel> Handle(GetMealDetailsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(mapper.Map<MealViewModel>(mealsService.GetById(request.MealId)));
        }
    }
}
