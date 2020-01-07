using System.Collections.Generic;

using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IOrdersService : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByUserId(string userId);
    }
}
