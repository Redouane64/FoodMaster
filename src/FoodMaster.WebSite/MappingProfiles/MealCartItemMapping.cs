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
                .ForMember(dest => dest.Item, options => options.MapFrom<MealMemberValueResolver, int>(item => item.MealId))
                .ForMember(dest => dest.Quantity, options => options.MapFrom(item => item.Quantity))
                .ForMember(dest => dest.Price, options => options.MapFrom<PriceMemberValueResilver, Meal>(item => default));
        }

        private class MealMemberValueResolver : IMemberValueResolver<Domain.CartItem, ViewModels.CartItem, int, Domain.Meal>
        {
            private readonly IMealsService mealsService;

            public MealMemberValueResolver(IMealsService mealsService)
            {
                this.mealsService = mealsService;
            }

            public Domain.Meal Resolve(Domain.CartItem source, ViewModels.CartItem destination, int sourceMember, Domain.Meal destMember, ResolutionContext context)
            {
                return mealsService.Get(item => item.Id == source.MealId);
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
                return mealsService.Get(item => item.Id == source.MealId).Price;
            }
        }
    }
}
