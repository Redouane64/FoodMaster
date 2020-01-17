using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.WebSite.Abstraction.Services;

namespace FoodMaster.WebSite.Infrastructure.Services
{
    public class BirthdayDiscountProvider : IDiscountProvider
    {
        public float GetDiscount() => 0.5f;
    }
}
