using System;
using System.Collections.Generic;

namespace FoodMaster.WebSite.Abstraction.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(Func<T, bool> predicate);
        void Create(T item);
        void Delete(T item);
    }
}