using System;
using System.Collections.Generic;
using System.Linq;

using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ICollection<Order> orders;

        public OrdersService(ICollection<Order> orders)
        {
            this.orders = orders;
        }

        public IEnumerable<Order> GetOrdersByUserId(string userId)
        {
            return orders.Where(order => order.UserId == userId).ToArray();
        }

        #region IRepository<Order> implementation
        void IRepository<Order>.Create(Order item)
        {
            orders.Add(item);
        }

        void IRepository<Order>.Delete(Order item)
        {
            orders.Remove(item);
        }

        Order IRepository<Order>.Get(Func<Order, bool> predicate)
        {
            return orders.FirstOrDefault(predicate);
        }

        IEnumerable<Order> IRepository<Order>.GetAll()
        {
            return orders;
        }
        #endregion
    }
}
