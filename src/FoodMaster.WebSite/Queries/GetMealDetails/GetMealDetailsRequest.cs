using FoodMaster.WebSite.Queries.Common;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetMealDetails
{
    public class GetMealDetailsRequest : IRequest<MealViewModel>
    {
        public int MealId { get; set; }
    }
}
