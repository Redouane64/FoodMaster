using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        public void Create(User user, string password)
        {
            user.PasswordHash = ComputePasswordHash(password);
            Create(user);
        }

        public void Delete(User item)
        {
            users.Remove(item);
        }

        public User FindByUserName(string username)
        {
            return Get(user => user.UserName.Equals(username));
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

        public bool VerifyPassword(User user, string password)
        {
            return user.PasswordHash.Equals(ComputePasswordHash(password));
        }

        private string ComputePasswordHash(string password)
        {
            using var hashAlgorithm = SHA256.Create();

            var passwordAsBytes = Encoding.ASCII.GetBytes(password);

            return Convert.ToBase64String(hashAlgorithm.ComputeHash(passwordAsBytes));      
        }
    }
}
