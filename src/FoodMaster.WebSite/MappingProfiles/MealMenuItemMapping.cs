using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class MealMenuItemMapping : Profile
    {
        public MealMenuItemMapping()
        {
            CreateMap<Meal, MenuItem>()
                .ForMember(dest => dest.InCart, options => options.MapFrom<ItemInCartValueResolver, bool>(m => true));

            CreateMap<CategoryMenu<Meal>, CategoryMenu<MenuItem>>();
        }

        private class ItemInCartValueResolver : IMemberValueResolver<Meal, MenuItem, bool, bool>
        {
            private readonly ICartService cartService;

            public ItemInCartValueResolver(ICartService cartService)
            {
                this.cartService = cartService;
            }

            public bool Resolve(Meal source, MenuItem destination, bool sourceMember, bool destMember, ResolutionContext context)
            {
                return cartService.Has(source);
            }
        }
    }
}
