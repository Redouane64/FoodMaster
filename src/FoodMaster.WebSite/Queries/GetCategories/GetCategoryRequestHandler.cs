using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FoodMaster.WebSite.Domain;

using MediatR;

namespace FoodMaster.WebSite.Queries.GetCategories
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoriesRequest, CategoryViewModel[]>
    {
        private readonly ICollection<Category> categories;

        public GetCategoryRequestHandler(ICollection<Category> categories)
        {
            this.categories = categories;
        }

        public Task<CategoryViewModel[]> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(categories.Select(c => new CategoryViewModel { Name = c.Name });
        }
    }
}
