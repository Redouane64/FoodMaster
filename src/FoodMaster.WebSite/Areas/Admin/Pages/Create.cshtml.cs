using System.Collections.Generic;
using System.Threading.Tasks;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Commands.CreateMeal;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Filters;
using FoodMaster.WebSite.Queries.Admin.CreateMeal;
using FoodMaster.WebSite.Queries.GetCategories;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    public class CreateModel : PageModel
    {
        private readonly IMediator mediator;
        private readonly IStockService stockService;

        public CreateModel(IMediator mediator, IStockService stockService)
        {
            this.mediator = mediator;
            this.stockService = stockService;
        }

        [BindProperty]
        public Commands.CreateMeal.Meal Meal { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public async Task OnGet()
        {
            Ingredients = await mediator.Send(new GetIngredientsRequest());
            Categories = await mediator.Send(new GetCategoriesRequest());
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Move this validation somewhere
            if(!stockService.Contains(Meal.Ingredients))
            {
                ModelState.AddModelError("Invalid Ingredients", "One or more ingredient name is not valid.");
                return Page();
            }

            _ = await mediator.Send(Meal);

            return RedirectToPage("Menus");
        }
    }
}
