using FoodMaster.WebSite.Abstraction.Repositories;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface ICartService : IRepository<Meal>
    {
        bool Has(Meal item);
    }
}
