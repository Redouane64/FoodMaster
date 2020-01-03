using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Exceptions;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class MealsService : IMealsService
    {
        private readonly ICollection<Meal> meals;
        private readonly IStockService stockService;

        public MealsService(ICollection<Meal> meals, IStockService stockService)
        {
            this.meals = meals;
            this.stockService = stockService;
        }

        public IEnumerable<Meal> GetAllByCategory(Category category)
        {
            return meals.Where(meal => meal.Category == category);
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

        #endregion
    }
}
