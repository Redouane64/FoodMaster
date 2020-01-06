using System;
using System.ComponentModel.DataAnnotations;

namespace FoodMaster.WebSite.Models
{
    public class LoginCredentials
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date value")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
