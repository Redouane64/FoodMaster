using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;

using MediatR;

namespace FoodMaster.WebSite.Commands.CreateMeal
{
    public class CreateMealRequestHandler : IRequestHandler<Meal>
    {
        private readonly IStockService stockService;
        private readonly IMealsService mealsService;
        private readonly IMapper mapper;

        public CreateMealRequestHandler(IStockService stockService, IMealsService mealsService, IMapper mapper)
        {
            this.stockService = stockService;
            this.mealsService = mealsService;
            this.mapper = mapper;
        }

        public Task<Unit> Handle(Meal request, CancellationToken cancellationToken)
        {
            Domain.Meal meal = mapper.Map<Domain.Meal>(request);
            meal.Id = mealsService.GetAll().Max(m => m.Id) + 1;
            mealsService.Create(meal);

            return Task.FromResult(default(Unit));
        }

    }
}
