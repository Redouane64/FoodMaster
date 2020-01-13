using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IUsersService : IRepository<User>
    {
        User GetById(string userId);

        bool VerifyPassword(User user, string password);
        User FindByUserName(string username);
        void Create(User user, string password);
    }
}