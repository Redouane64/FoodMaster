using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodMaster.WebSite.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<MenuItem> Meals { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "French Fried",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/french-fries.jpg"
            },
            new MenuItem
            {
                Name = "Hanburger XL Beef",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/hamburger.jpg"
            },
            new MenuItem
            {
                Name = "Garlic Soup",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/soup.jpg"
            },
            new MenuItem
            {
                Name = "Shawarma XL",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/shawarma.jpg"
            },
            new MenuItem
            {
                Name = "Chicken Nuggets",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/chicken-nuggets.jpg"
            }
        };

        public List<MenuItem> Desserts { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Ice Cream",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/icecream.jpg"
            },
            new MenuItem
            {
                Name = "Cheesecake 100g",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/cheesecake.jpg"
            },
            new MenuItem
            {
                Name = "Jelly",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/jelly.jpg"
            },
            new MenuItem
            {
                Name = "Chocolate Cake",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/cake-chocolate.jpg"
            },
            new MenuItem
            {
                Name = "Berries Cheesecake",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/cheesecake-with-berries.jpg"
            },
            new MenuItem
            {
                Name = "Cake",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/cake-bread.jpg"
            }
        };

        public List<MenuItem> Drinks { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Coke 0.33L",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/coke.jpg"
            },
            new MenuItem
            {
                Name = "Coffee",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/coffee.jpg"
            },
            new MenuItem
            {
                Name = "Milkshake",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/milkshake.jpg"
            },
            new MenuItem
            {
                Name = "Pepsi 0.33L",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/pepsi.jpg"
            },
            new MenuItem
            {
                Name = "Beer 0.5L",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Image = "/images/beer.jpg"
            }
        };

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
