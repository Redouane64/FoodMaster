using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMaster.WebSite
{
    [Authorize(Roles = "Admin")]
    public class MenusModel : PageModel
    {
        private readonly IMealsService mealsService;
        private readonly IMapper mapper;

        public MenusModel(IMealsService mealsService, IMapper mapper)
        {
            this.mealsService = mealsService;
            this.mapper = mapper;
        }

        public IEnumerable<Menu> Menus => mapper.Map<IEnumerable<Menu>>(mealsService.GetAllGroupedByCategory());

        public IActionResult OnPost([FromForm]int itemId)
        {

            return RedirectToPage();
        }
    }
}
