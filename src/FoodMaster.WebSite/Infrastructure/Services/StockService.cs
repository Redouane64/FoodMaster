using System;
using System.Collections.Generic;
using System.Linq;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly ICollection<Ingredient> ingredients;

        public StockService(ICollection<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public bool Contains(IEnumerable<int> ingredients)
        {
            return ingredients.All(id => this.ingredients.Any(ing => ing.Id == id && ing.Quantity > 0));
        }

        public void Create(Ingredient item)
        {

            ingredients.Add(item);
        }

        public void Delete(Ingredient item)
        {
            ingredients.Remove(item);
        }

        public Ingredient Get(Func<Ingredient, bool> predicate)
        {
            return ingredients.FirstOrDefault(predicate);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return ingredients;
        }
    }
}
