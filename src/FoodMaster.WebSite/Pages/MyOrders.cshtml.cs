using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Queries.Common;
using FoodMaster.WebSite.Queries.GetOrderDetails;
using FoodMaster.WebSite.Queries.GetOrders;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "User,Guest")]
    public class MyOrdersModel : PageModel
    {
        private readonly IMediator mediator;

        public MyOrdersModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IEnumerable<Order> Orders { get; set; }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGet([FromRoute]string orderId)
        {

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (String.IsNullOrEmpty(orderId))
            {
                Orders = await mediator.Send(new GetOrdersRequest() { UserId = userId });
            }
            else
            {
                var order = await mediator.Send(new GetOrderDetailsRequest() { OrderId = orderId });
                
                if(order == null)
                {
                    return NotFound();
                }

                Order = order;
            }

            return Page();
        }
    }
}