using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class MealCartItemMapping : Profile
    {
        public MealCartItemMapping()
        {
            CreateMap<Meal, CartItem>()
                .ForMember(dest => dest.Item, options => options.MapFrom(meal => meal))
                .ForMember(dest => dest.Quantity, options => options.MapFrom(meal => 1));
        }
    }
}
