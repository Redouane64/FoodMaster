using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    public class OrderDetailsModel : PageModel
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public OrderDetailsModel(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public ViewModels.Order Order { get; set; }

        public IActionResult OnGet()
        {
            if(RouteData.Values.TryGetValue("orderId", out var orderId))
            {
                var order = ordersService.Get(order => order.Id == orderId.ToString());

                if (order is null)
                {
                    return NotFound();
                }

                Order = mapper.Map<ViewModels.Order>(order);

            }

            return Page();
        }
    }
}