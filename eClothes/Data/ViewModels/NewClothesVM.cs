using eClothes.Data.Base;
using eClothes.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eClothes.Models
{
    public class NewClothesVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cloth image url is required")]
        [Display(Name = "Cloth image url")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Cloth name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Stock is required")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Size is required")]
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public int ClothesCategoryId { get; set;}

        [Required(ErrorMessage = "Discount is required, if you don't want any select [ 0. No discount ]")]
        public List<int> ClothesDiscountIds { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
    }
}
