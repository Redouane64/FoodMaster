using MediatR;

namespace FoodMaster.WebSite.Queries.Admin.CreateMeal
{
    public class GetIngredientsRequest : IRequest<IngredientViewModel[]>
    {

    }
}
