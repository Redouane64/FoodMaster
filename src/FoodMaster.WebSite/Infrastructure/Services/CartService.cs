using System;
using System.Collections.Generic;
using System.Linq;
using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICollection<CartItem> cart;
        private readonly IMealsService mealsService;
        private readonly IRepository<CartItem> _base;

        public CartService(ICollection<CartItem> cart, IMealsService mealsService)
        {
            this.cart = cart;
            this.mealsService = mealsService;
            _base = this as IRepository<CartItem>;
        }

        public decimal GetCartTotal()
        {
            return cart.Join(
                    mealsService.GetAll(), 
                    cartItem => cartItem.ItemId, 
                    meal => meal.Id, 
                    (c, m) => new { c.Quantity, m.Price })
                .Sum(item => item.Price * item.Quantity);
        }

        public CartItem GetByItemId(int itemId)
        {
            return cart.FirstOrDefault(item => item.ItemId == itemId);
        }

        public void CreateFromItemId(int itemId)
        {
            var item = new CartItem {
                ItemId = itemId,
                Quantity = 1
            };

            _base.Create(item);
        }

        public void DeleteByItemId(int itemId)
        {
            var item = GetByItemId(itemId);

            if (item is null)
            {
                return;
            }

            _base.Delete(item);
        }

        public bool HasItemWithId(int itemId)
        {
            return cart.Where(cartItem => cartItem.ItemId == itemId).Any();
        }

        public IEnumerable<CartItem> GetAll()
        {
            return cart;
        }

        CartItem IRepository<CartItem>.Get(Func<CartItem, bool> predicate)
        {
            return cart.FirstOrDefault(predicate);
        }

        void IRepository<CartItem>.Create(CartItem item)
        {
            cart.Add(item);
        }

        void IRepository<CartItem>.Delete(CartItem item)
        {
            cart.Remove(item);
        }

        public void Clear()
        {
            cart.Clear();
        }
    }
}
