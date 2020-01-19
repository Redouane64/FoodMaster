using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IMealsService mealsService;
        private readonly IStockService stockService;
        private readonly IMapper mapper;

        public CreateModel(IMealsService mealsService, IStockService stockService, IMapper mapper)
        {
            this.mealsService = mealsService;
            this.stockService = stockService;
            this.mapper = mapper;
        }

        [BindProperty]
        public Models.Meal Meal { get; set; }

        public IEnumerable<Ingredient> Ingredients { get => stockService.GetAll(); }

        [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if(!stockService.Contains(Meal.Ingredients))
            {
                ModelState.AddModelError("Invalid Ingredients", "One or more ingredient name is not valid.");
                return Page();
            }

            Domain.Meal meal = mapper.Map<Domain.Meal>(Meal);
            meal.Id = mealsService.GetAll().Max(m => m.Id) + 1;

            mealsService.Create(meal);

            return RedirectToPage("Menus");
        }
    }
}
