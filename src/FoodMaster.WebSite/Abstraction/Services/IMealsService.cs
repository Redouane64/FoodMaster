using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;
using System.Collections.Generic;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IMealsService : IRepository<Meal>
    {
        IEnumerable<Domain.Meal> GetPreparableMeals();
        IEnumerable<Domain.Menu> GetAllGroupedByCategory();
        bool HasItemWithId(int itemId);
        Meal GetById(int id);
    }
}
