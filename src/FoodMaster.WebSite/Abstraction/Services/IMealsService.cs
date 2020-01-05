using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;
using System.Collections.Generic;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IMealsService : IRepository<Meal>
    {
        IEnumerable<Meal> GetAllByCategory(Category category);
        bool HasItemWithId(int itemId);
    }
}
