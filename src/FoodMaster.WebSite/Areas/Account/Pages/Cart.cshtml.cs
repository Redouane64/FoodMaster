using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    public class CartModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartModel(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        public IEnumerable<CartItem> CartItems => mapper.Map<IEnumerable<CartItem>>(cartService.GetAll());

        public string FullName => User.FindFirst(ClaimTypes.Name).Value;

        public void OnGet()
        {

        }

        public IActionResult OnPostSendOrder([FromForm]OrderDetails orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var items = cartService.GetAll();

            if (!items.Any())
            {
                return Page();
            }

            return Page();
        }

        public void OnPost([FromForm]int itemId)
        {            
            cartService.DeleteByItemId(itemId);
        }
    }
}