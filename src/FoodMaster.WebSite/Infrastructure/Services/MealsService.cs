using System;
using System.Collections.Generic;
using System.Linq;

using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class MealsService : IMealsService
    {
        private readonly ICollection<Meal> meals;
        private readonly IStockService stockService;
        private readonly IRepository<Meal> _base;
        public MealsService(ICollection<Meal> meals, IStockService stockService)
        {
            this.meals = meals;
            this.stockService = stockService;
            this._base = this as IRepository<Meal>;
        }

        public IEnumerable<Domain.Menu> GetAllGroupedByCategory()
        {
            return this.GetPreparableMeals()
                        .GroupBy(
                            item => item.CategoryId, 
                            (category, items) => new Domain.Menu { Category = category, Meals = items.ToArray() }
                        );
        }

        public bool HasItemWithId(int itemId)
        {
            return meals.Any(item => item.Id == itemId);
        }

        public Domain.Meal GetById(int id)
        {
            return _base.Get(meal => meal.Id == id);
        }


        #region IRepository explicit implementation

        void IRepository<Domain.Meal>.Create(Meal item)
        {
            meals.Add(item);
        }

        void IRepository<Domain.Meal>.Delete(Meal item)
        {
            meals.Remove(item);
        }

        Meal IRepository<Domain.Meal>.Get(Func<Domain.Meal, bool> predicate)
        {
            return meals.FirstOrDefault(predicate);
        }

        IEnumerable<Domain.Meal> IRepository<Domain.Meal>.GetAll()
        {
            return meals;
        }

        public IEnumerable<Domain.Meal> GetPreparableMeals()
        {
            return meals.Where(m => stockService.Contains(m.Ingredients));
        }

        #endregion
    }
}
