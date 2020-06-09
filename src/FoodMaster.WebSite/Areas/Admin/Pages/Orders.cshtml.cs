using System.Collections.Generic;
using System.Threading.Tasks;

using FoodMaster.WebSite.Queries.Common;
using FoodMaster.WebSite.Queries.GetOrders;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    public class OrdersModel : PageModel
    {
        private readonly IMediator mediator;

        public OrdersModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IEnumerable<Order> Orders { get; set; }

        public async Task OnGet()
        {
            Orders = await mediator.Send(new GetOrdersRequest());
        }
    }
}