using System.Linq;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetCategories
{
    public class GetCategoriesRequest : IRequest<CategoryViewModel[]>
    {
    }
}
