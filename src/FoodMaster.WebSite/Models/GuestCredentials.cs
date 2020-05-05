using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

using MediatR;

namespace FoodMaster.WebSite.Models
{
    public class GuestCredentials : IRequest<Claim[]>
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
