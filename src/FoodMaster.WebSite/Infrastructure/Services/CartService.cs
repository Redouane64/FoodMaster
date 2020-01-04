using System;
using System.Collections.Generic;
using System.Linq;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICollection<Meal> cart;

        public CartService(ICollection<Meal> cart)
        {
            this.cart = cart;
        }

        public void Create(Meal item)
        {
            cart.Add(item);
        }

        public void Delete(Meal item)
        {
            cart.Remove(item);
        }

        public Meal Get(Func<Meal, bool> predicate)
        {
            return cart.FirstOrDefault(predicate);
        }

        public IEnumerable<Meal> GetAll()
        {
            return cart;
        }

        public bool Has(Meal item)
        {
            return cart.Contains(item);
        }
    }
}
