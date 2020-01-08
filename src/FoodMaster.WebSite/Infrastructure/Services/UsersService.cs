using System;
using System.Collections.Generic;
using System.Linq;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly ICollection<User> users;

        public UsersService(ICollection<User> users)
        {
            this.users = users;
        }

        public void Create(User item)
        {
            users.Add(item);
        }

        public void Delete(User item)
        {
            users.Remove(item);
        }

        public User Get(Func<User, bool> predicate)
        {
            return users.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(string userId)
        {
            return Get(u => u.Id == userId);
        }
    }
}
