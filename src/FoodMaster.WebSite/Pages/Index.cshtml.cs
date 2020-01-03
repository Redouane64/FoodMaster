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
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper mapper;
        private readonly IMealsService mealsService;

        public List<MenuItem> Meals => mapper.Map<List<MenuItem>>(mealsService.GetAllByCategory(Category.Meal));

        public List<MenuItem> Desserts => mapper.Map<List<MenuItem>>(mealsService.GetAllByCategory(Category.Dessert));

        public List<MenuItem> Drinks => mapper.Map<List<MenuItem>>(mealsService.GetAllByCategory(Category.Drink));

        public IndexModel(ILogger<IndexModel> logger, IMapper mapper, IMealsService mealsService)
        {
            _logger = logger;
            this.mapper = mapper;
            this.mealsService = mealsService;
        }

        public void OnGet()
        {

        }
    }
}
