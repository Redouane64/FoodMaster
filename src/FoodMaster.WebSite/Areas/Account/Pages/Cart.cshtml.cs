using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;

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

        [BindProperty(SupportsGet = false)]
        public OrderDetails OrderDetails { get; set; }

        [TempData]
        [Required]
        [Display(Name = "I confirm the order.", ShortName = "Confirm")]
        public bool Confirmed { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostSendOrder()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var items = cartService.GetAll();

            if (!items.Any())
            {
                ModelState.AddModelError("Empty Cart", "You cannot send an order with an empty cart.");
                return Page();
            }

            return RedirectToPagePermanent("Index");
        }

        public void OnPost([FromForm]int itemId)
        {            
            cartService.DeleteByItemId(itemId);
        }
    }
}