using AutoMapper;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class MealMenuItemMapper : Profile
    {
        public MealMenuItemMapper()
        {
            CreateMap<Meal, MenuItem>();
        }
    }
}
