using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IUsersService : IRepository<User>
    {
        User GetById(string userId);
    }
}