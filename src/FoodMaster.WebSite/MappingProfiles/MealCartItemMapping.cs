using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class MealCartItemMapping : Profile
    {
        public MealCartItemMapping()
        {
            CreateMap<Domain.CartItem, ViewModels.CartItem>()
                .ForMember(dest => dest.Item, options => options.MapFrom<MealMemberValueResolver, int>(item => item.ItemId))
                .ForMember(dest => dest.Quantity, options => options.MapFrom(item => item.Quantity))
                .ForMember(dest => dest.Price, options => options.MapFrom<PriceMemberValueResilver, Meal>(item => default));
        }

        private class MealMemberValueResolver : IMemberValueResolver<Domain.CartItem, ViewModels.CartItem, int, Meal>
        {
            private readonly IMealsService mealsService;

            public MealMemberValueResolver(IMealsService mealsService)
            {
                this.mealsService = mealsService;
            }

            public Meal Resolve(Domain.CartItem source, ViewModels.CartItem destination, int sourceMember, Meal destMember, ResolutionContext context)
            {
                return mealsService.Get(item => item.Id == source.ItemId);
            }
        }

        private class PriceMemberValueResilver : IMemberValueResolver<Domain.CartItem, ViewModels.CartItem, Meal, decimal>
        {
            private readonly IMealsService mealsService;

            public PriceMemberValueResilver(IMealsService mealsService)
            {
                this.mealsService = mealsService;
            }

            public decimal Resolve(Domain.CartItem source, ViewModels.CartItem destination, Meal sourceMember, decimal destMember, ResolutionContext context)
            {
                return mealsService.Get(item => item.Id == source.ItemId).Price;
            }
        }
    }
}
