using System;
using System.ComponentModel.DataAnnotations;

namespace FoodMaster.WebSite.Models
{
    public class LoginCredentials
    {
        [Required]
        [RegularExpression("[a-zA-Z]+\\s[a-zA-Z]+")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
