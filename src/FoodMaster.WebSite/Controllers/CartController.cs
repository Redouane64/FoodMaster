using FoodMaster.WebSite.Abstraction.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodMaster.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CartController : ControllerBase
    {
        private readonly IMealsService mealsService;
        private readonly ICartService cartService;

        public CartController(IMealsService mealsService, ICartService cartService)
        {
            this.mealsService = mealsService;
            this.cartService = cartService;
        }

        [HttpPost("{id:int}", Name = nameof(Create))]
        public IActionResult Create([FromRoute] int id)
        {
            var meal = mealsService.Get(meal => meal.Id == id);

            if (meal == null)
            {
                return NotFound();
            }

            cartService.Create(meal);

            return Created("/cart", null);
        }

        [HttpDelete("{id:int}", Name = nameof(Delete))]
        public IActionResult Delete([FromRoute] int id)
        {
            var meal = mealsService.Get(meal => meal.Id == id);

            if (meal == null)
            {
                return NotFound();
            }

            cartService.Delete(meal);

            return NoContent();
        }
    }
}