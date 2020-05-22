using System.Threading;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;

using MediatR;

namespace FoodMaster.WebSite.Commands.DeleteMeal
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IMealsService mealsService;

        public DeleteMealCommandHandler(IMealsService mealsService)
        {
            this.mealsService = mealsService;
        }

        public Task<Unit> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var meal = mealsService.GetById(request.MealId);

            if (meal != null)
            {
                mealsService.Delete(meal);
            }

            return Task.FromResult(default(Unit));
        }
    }
}
