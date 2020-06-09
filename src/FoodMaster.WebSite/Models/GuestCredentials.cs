using System;
using System.ComponentModel.DataAnnotations;

namespace FoodMaster.WebSite.Models
{
    public class GuestCredentials
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
