using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Filters;
using FoodMaster.WebSite.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [ServiceFilter(typeof(WriteToDiskFilterAttribute))]
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public CartModel(ICartService cartService, IOrdersService ordersService, IMapper mapper)
        {
            this.cartService = cartService;
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IEnumerable<ViewModels.CartItem> CartItems => mapper.Map<IEnumerable<ViewModels.CartItem>>(cartService.GetAll());

        public string FullName => User.FindFirst(ClaimTypes.Name).Value;

        [BindProperty(SupportsGet = false)]
        public OrderDetails OrderDetails { get; set; }

        [TempData]
        [Required]
        [Display(Name = "I confirm the order.", ShortName = "Confirm")]
        public bool Confirmed { get; set; }

        [TempData]
        public bool HasBirthDay { get; set; }

        public void OnGet()
        {
            var userBirthDate = HttpContext.User.FindFirstValue(ClaimTypes.DateOfBirth);
            HasBirthDay = DateTime.Today.Subtract(Convert.ToDateTime(userBirthDate)).Days == 0;
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

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orderItems = items.Select(item => new Domain.OrderItem { MealId = item.ItemId, Quantity = item.Quantity }).ToList();
            var total = CartItems.Sum(ci => ci.Price * ci.Quantity);
            cartService.Clear();

            var order = new Order {
                Id = Guid.NewGuid().ToString(),
                Items = orderItems,
                UserId = userId,
                Address = $"{OrderDetails.Address}, {OrderDetails.PostalCode}.",
                PhoneNumber = OrderDetails.PhoneNumber,
                Date = DateTime.Now,
                Total = total,
                Comments = OrderDetails.Comments
            };

            ordersService.Create(order);

            return RedirectToPagePermanent("MyOrders");
        }

        public void OnPost([FromForm]int itemId)
        {            
            cartService.DeleteByItemId(itemId);
        }
    }
}