using System.Collections.Generic;
using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IStockService : IRepository<Ingredient>
    {
        bool Contains(IEnumerable<int> ingredients);
    }
}
