using eClothes.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eClothes.Models
{
    public class Discounts : IEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "Discount name")]
        [Required(ErrorMessage = "Discount name is required")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "The name must be between 4 and 40 chars")]
        public string Name { get; set; }

        [Display(Name = "Discount percentage")]
        [Required(ErrorMessage = "Discount percentage is required")]
        public int Discount { get; set; }


        public List<Clothes_Discounts>? Clothes_Discounts { get; set; }
    }
}
