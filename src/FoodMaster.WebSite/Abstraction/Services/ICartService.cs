using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface ICartService : IRepository<CartItem>
    {
        void Clear();
        decimal GetCartTotal();
        CartItem GetByItemId(int itemId);
        void CreateFromItemId(int itemId);
        void DeleteByItemId(int itemId);
        bool HasItemWithId(int itemId);
    }
}
