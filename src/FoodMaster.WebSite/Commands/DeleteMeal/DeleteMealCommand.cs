using MediatR;

namespace FoodMaster.WebSite.Commands.DeleteMeal
{
    public class DeleteMealCommand : IRequest
    {
        public int MealId { get; set; }

    }
}
