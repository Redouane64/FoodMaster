using System.Threading.Tasks;

using FoodMaster.WebSite.Queries.Common;
using FoodMaster.WebSite.Queries.GetOrderDetails;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    public class OrderDetailsModel : PageModel
    {
        private readonly IMediator mediator;

        public OrderDetailsModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if(RouteData.Values.TryGetValue("orderId", out var orderId))
            {
                var order = await mediator.Send(new GetOrderDetailsRequest() { OrderId = orderId.ToString() });

                if (order is null)
                {
                    return NotFound();
                }

                Order = order;
            }

            return Page();
        }
    }
}