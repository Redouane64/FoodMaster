using System.ComponentModel.DataAnnotations;

namespace FoodMaster.WebSite.Models
{
    public class OrderDetails
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
