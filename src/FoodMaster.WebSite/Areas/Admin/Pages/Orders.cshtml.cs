using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    public class OrdersModel : PageModel
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public OrdersModel(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IEnumerable<ViewModels.Order> Orders { get => mapper.Map<IEnumerable<ViewModels.Order>>(ordersService.GetAll()); }
    }
}