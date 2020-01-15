using System;
using System.Collections.Generic;
using System.Security.Claims;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "User,Guest")]
    public class MyOrdersModel : PageModel
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public MyOrdersModel(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IEnumerable<ViewModels.Order> Orders { get; set; }

        public ViewModels.Order Order { get; set; }

        public IActionResult OnGet([FromRoute]string orderId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (String.IsNullOrEmpty(orderId))
            {
                Orders = mapper.Map<IEnumerable<ViewModels.Order>>(ordersService.GetOrdersByUserId(userId));
            }
            else
            {
                var order = ordersService.Get(order => order.Id == orderId);
                
                if(order == null)
                {
                    return NotFound();
                }

                Order = mapper.Map<ViewModels.Order>(order);
            }

            return Page();
        }
    }
}