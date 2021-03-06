using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite
{
    public class MealMapping : Profile
    {
        public MealMapping()
        {
            CreateMap<Models.Meal, Domain.Meal>()
                .ForMember(dest => dest.Category,
                    options => options.MapFrom<CategoryIdValueResolver, string>(s => s.Category));
        }

        private class CategoryIdValueResolver : IMemberValueResolver<Models.Meal, Domain.Meal, string, int>
        {
            private readonly ICollection<Category> categories;

            public CategoryIdValueResolver(ICollection<Category> categories)
            {
                this.categories = categories;
            }
            public int Resolve(Models.Meal source, Domain.Meal destination, string sourceMember, int destMember, ResolutionContext context)
            {
                return categories.FirstOrDefault(c => c.Name.Equals(sourceMember, StringComparison.OrdinalIgnoreCase))?.Id ?? -1;
            }
        }
    }
}