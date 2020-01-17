using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Pages
{
    [Authorize]
    [ResponseCache(NoStore = true)]
    public class IndexModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly IMealsService mealsService;

        public IEnumerable<ViewModels.Menu> Menu => mapper.Map<IEnumerable<ViewModels.Menu>>(mealsService.GetPreparableMeals().GroupBy(item => item.Category, (category, items) => new Domain.Menu { Category = category, Meals = items.ToArray() }));

        public IndexModel(IMapper mapper, IMealsService mealsService)
        {
            this.mapper = mapper;
            this.mealsService = mealsService;
        }

        public void OnGet()
        {
        }
    }
}
