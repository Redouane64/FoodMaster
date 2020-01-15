using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class MealMenuMapping : Profile
    {
        public MealMenuMapping()
        {
            CreateMap<Domain.Meal, ViewModels.Meal>()
                .ForMember(dest => dest.InCart, options => options.MapFrom<ItemInCartValueResolver, bool>(m => default));

            CreateMap<Domain.Menu, ViewModels.Menu>()
                .ForMember(dest => dest.Category, options => options.MapFrom<CategoryNameValueResolver, int>(s => s.Category));
        }

        private class ItemInCartValueResolver : IMemberValueResolver<Domain.Meal, ViewModels.Meal, bool, bool>
        {
            private readonly ICartService cartService;

            public ItemInCartValueResolver(ICartService cartService)
            {
                this.cartService = cartService;
            }

            public bool Resolve(Domain.Meal source, ViewModels.Meal destination, bool sourceMember, bool destMember, ResolutionContext context)
            {
                return cartService.HasItemWithId(source.Id);
            }
        }

        private class CategoryNameValueResolver : IMemberValueResolver<Domain.Menu, ViewModels.Menu, int, string>
        {
            private readonly ICollection<Category> categories;

            public CategoryNameValueResolver(ICollection<Category> categories)
            {
                this.categories = categories;
            }

            public string Resolve(Domain.Menu source, ViewModels.Menu destination, int sourceMember, string destMember, ResolutionContext context)
            {
                return categories.FirstOrDefault(c => c.Id == sourceMember)?.Name ?? "Uncategorized";
            }
        }
    }
}
