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

        public List<MenuItem> Menu { get; } = new List<MenuItem>
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
