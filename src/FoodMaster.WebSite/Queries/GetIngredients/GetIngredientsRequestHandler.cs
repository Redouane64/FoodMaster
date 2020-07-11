using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;

using MediatR;

namespace FoodMaster.WebSite.Queries.Admin.CreateMeal
{
    public class GetIngredientsRequestHandler : IRequestHandler<GetIngredientsRequest, IngredientViewModel[]>
    {
        private readonly IStockService stockService;
        private readonly IMapper mapper;

        public GetIngredientsRequestHandler(IStockService stockService, IMapper mapper)
        {
            this.stockService = stockService;
            this.mapper = mapper;
        }

        public Task<IngredientViewModel[]> Handle(GetIngredientsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(stockService.GetAll().Select(i => new IngredientViewModel { Id = i.Id, Name = i.Name }).ToArray());
        }
    }
}
