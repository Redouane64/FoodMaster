using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Data;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodMaster.WebSite.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly IMealsService mealsService;

        public IEnumerable<CategoryMenu<MenuItem>> Menu => mapper.Map<IEnumerable<CategoryMenu<MenuItem>>>(
                mealsService.GetAll().GroupBy(item => item.Category, (category, items) => new CategoryMenu<Meal> { Category = category, Menu = items })
            );

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
