using System;
using System.Collections.Generic;
using System.Linq;
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

        public void OnGet()
        {

        }

        public void OnPost([FromForm]int itemId)
        {            
            cartService.DeleteByItemId(itemId);
        }
    }
}