using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Extensions
{
    public static class OrderStatusEnumExtension
    {
        public static string GetDescription(this OrderStatus orderStatus)
        {
            return orderStatus.GetType()
                .GetField(orderStatus.ToString())
                .GetCustomAttributes(false)
                .OfType<DescriptionAttribute>()
                .FirstOrDefault()?.Description ?? orderStatus.ToString();
        }
    }
}
