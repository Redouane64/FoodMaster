using System.Collections.Generic;
using System.Threading.Tasks;

using FoodMaster.WebSite.Commands.DeleteMeal;
using FoodMaster.WebSite.Filters;
using FoodMaster.WebSite.Queries.GetMenus;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    public class MenusModel : PageModel
    {
        private readonly IMediator mediator;

        public MenusModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IEnumerable<MenuViewModel> Menus { get; set; }

        public async Task OnGet()
        {
            Menus = await mediator.Send(new GetMenusRequest());
        }

        public async Task<IActionResult> OnPost([FromForm]int itemId)
        {
            await mediator.Send(new DeleteMealCommand() { MealId = itemId });
            return RedirectToPage();
        }
    }
}
