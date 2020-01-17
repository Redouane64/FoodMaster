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

        public IEnumerable<Meal> GetAllByCategoryId(int category)
        {
            return meals.Where(meal => meal.Category == category);
        }

        public bool HasItemWithId(int itemId)
        {
            return meals.Any(item => item.Id == itemId);
        }

        public Meal GetById(int id)
        {
            return _base.Get(meal => meal.Id == id);
        }


        #region IRepository explicit implementation

        void IRepository<Meal>.Create(Meal item)
        {
            meals.Add(item);
        }

        void IRepository<Meal>.Delete(Meal item)
        {
            meals.Remove(item);
        }

        Meal IRepository<Meal>.Get(Func<Meal, bool> predicate)
        {
            return meals.FirstOrDefault(predicate);
        }

        IEnumerable<Meal> IRepository<Meal>.GetAll()
        {
            return meals;
        }

        public IEnumerable<Meal> GetPreparableMeals()
        {
            return meals.Where(m => stockService.Contains(m.Ingredients));
        }

        #endregion
    }
}
