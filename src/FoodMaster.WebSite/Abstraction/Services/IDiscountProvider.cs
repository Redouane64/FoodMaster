using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMaster.WebSite.Abstraction.Services
{
    public interface IDiscountProvider
    {
        float GetDiscount();
    }
}
