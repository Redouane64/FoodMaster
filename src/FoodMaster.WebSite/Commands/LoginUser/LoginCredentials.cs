using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

using MediatR;

namespace FoodMaster.WebSite.Commands.LoginUser
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
