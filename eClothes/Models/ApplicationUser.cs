using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eClothes.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string Fullname { get; set; }
    }
}
