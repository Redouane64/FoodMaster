using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Queries.GetMenus;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class MealMenuMapping : Profile
    {
        public MealMenuMapping()
        {
            CreateMap<Domain.Meal, ViewModels.Meal>()
                .ForMember(dest => dest.Ingredients, options => options.MapFrom<IngredientsValueResolver, IEnumerable<int>>(s => s.Ingredients))
                .ForMember(dest => dest.InCart, options => options.MapFrom<ItemInCartValueResolver, bool>(m => default));

            CreateMap<Domain.Menu, MenuViewModel>()
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

        private class CategoryNameValueResolver : IMemberValueResolver<Domain.Menu, MenuViewModel, int, string>
        {
            private readonly ICollection<Category> categories;

            public CategoryNameValueResolver(ICollection<Category> categories)
            {
                this.categories = categories;
            }

            public string Resolve(Domain.Menu source, MenuViewModel destination, int sourceMember, string destMember, ResolutionContext context)
            {
                return categories.FirstOrDefault(c => c.Id == sourceMember)?.Name ?? "Uncategorized";
            }
        }

        private class IngredientsValueResolver : IMemberValueResolver<Domain.Meal, ViewModels.Meal, IEnumerable<int>, IEnumerable<string>>
        {
            private readonly IStockService stockService;

            public IngredientsValueResolver(IStockService stockService)
            {
                this.stockService = stockService;
            }

            public IEnumerable<string> Resolve(Domain.Meal source, ViewModels.Meal destination, IEnumerable<int> sourceMember, IEnumerable<string> destMember, ResolutionContext context)
            {
                return stockService.GetAll().Join<Ingredient, int, int, string>(source.Ingredients, i => i.Id, i => i, (ing, id) => ing.Name);
            }
        }
    }
}
