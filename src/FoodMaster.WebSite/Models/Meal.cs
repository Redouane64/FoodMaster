using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodMaster.WebSite.Models
{
    public class Meal
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public IEnumerable<int> Ingredients { get; set; }

        [Required()]
        [Range(1, 9999)]
        public decimal Price { get; set; }

        [Required()]
        [Range(0, 9999)]
        public float Calories { get; set; }
    }
}