using eClothes.Data.Base;
using eClothes.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eClothes.Models
{
    public class Clothes : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }

        public int ClothesCategoryId { get; set; }
        [ForeignKey("ClothesCategoryId")]
        public ClothesCategory ClothesCategory { get; set;}

        [Required(ErrorMessage = "Discount is required, if you don't want any select [ 0. No discount ]")]
        public List<Clothes_Discounts> Clothes_Discounts { get; set; }


        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
