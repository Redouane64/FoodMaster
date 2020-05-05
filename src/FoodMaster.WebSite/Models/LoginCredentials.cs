using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;

namespace FoodMaster.WebSite.Models
{
    public class LoginCredentials : IRequest<Claim[]>
    {
        [Required]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
