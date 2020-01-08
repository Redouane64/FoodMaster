using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    public class OrdersModel : PageModel
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public OrdersModel(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IEnumerable<ViewModels.Order> Orders { get; set; }

        public void OnGet()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Orders = mapper.Map<IEnumerable<ViewModels.Order>>(ordersService.GetOrdersByUserId(userId));
        }
    }
}