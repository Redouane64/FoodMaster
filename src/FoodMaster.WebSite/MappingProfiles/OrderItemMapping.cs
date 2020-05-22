using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class OrderItemMapping : Profile
    {
        public OrderItemMapping()
        {
            CreateMap<Domain.OrderItem, Queries.Common.OrderItem>()
                .ForMember(dest => dest.Meal, options => options.MapFrom<ItemMemberValueResolver, int>(s => s.MealId))
                .ForMember(dest => dest.Price, options => options.MapFrom<PriceMemberValueResolver, Domain.OrderItem>(s => s))
                .ForMember(dest => dest.UnitPrice, options => options.MapFrom<UnitPriceMemberValueResolver, Domain.OrderItem>(s => s));
        }

        private class ItemMemberValueResolver : IMemberValueResolver<Domain.OrderItem, Queries.Common.OrderItem, int, Meal>
        {
            private readonly IMealsService mealsService;

            public ItemMemberValueResolver(IMealsService mealsService)
            {
                this.mealsService = mealsService;
            }

            public Meal Resolve(Domain.OrderItem source, Queries.Common.OrderItem destination, int sourceMember, Meal destMember, ResolutionContext context)
            {
                return mealsService.GetById(sourceMember);
            }
        }

        private class PriceMemberValueResolver : IMemberValueResolver<Domain.OrderItem, Queries.Common.OrderItem, Domain.OrderItem, decimal>
        {
            private readonly IMealsService mealsService;

            public PriceMemberValueResolver(IMealsService mealsService)
            {
                this.mealsService = mealsService;
            }

            public decimal Resolve(Domain.OrderItem source, Queries.Common.OrderItem destination, Domain.OrderItem sourceMember, decimal destMember, ResolutionContext context)
            {
                return mealsService.GetById(source.MealId).Price * sourceMember.Quantity;
            }
        }

        private class UnitPriceMemberValueResolver : IMemberValueResolver<Domain.OrderItem, Queries.Common.OrderItem, Domain.OrderItem, decimal>
        {
            private readonly IMealsService mealsService;

            public UnitPriceMemberValueResolver(IMealsService mealsService)
            {
                this.mealsService = mealsService;
            }

            public decimal Resolve(Domain.OrderItem source, Queries.Common.OrderItem destination, Domain.OrderItem sourceMember, decimal destMember, ResolutionContext context)
            {
                return mealsService.GetById(source.MealId).Price;
            }
        }
    }
}
