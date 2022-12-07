using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace eClothes.Data.ViewModels
{
	public class ShoppingCartFormVM
	{
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "County is required")]
        public string County { get; set; }
        [Required(ErrorMessage = "Zipcode is required")]
        public string Zipcode { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public int PhoneNumber { get; set; }
	}
}
