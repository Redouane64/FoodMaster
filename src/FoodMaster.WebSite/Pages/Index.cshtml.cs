using System.Collections.Generic;
using System.Threading.Tasks;

using FoodMaster.WebSite.Queries.GetMenus;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite.Pages
{
    [Authorize]
    [ResponseCache(NoStore = true)]
    public class IndexModel : PageModel
    {
        private readonly IMediator mediator;

        public IEnumerable<MenuViewModel> Menu { get; set; }

        public IndexModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task OnGet()
        {
            Menu = await mediator.Send(new GetMenusRequest());
        }
    }
}
