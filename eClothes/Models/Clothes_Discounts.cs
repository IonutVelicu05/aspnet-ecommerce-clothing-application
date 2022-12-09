using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eClothes.Models
{
    public class Clothes_Discounts
    {
        [Key]
        public int Id { get; set; }

        public int ClothId { get; set; }
        //[ForeignKey("ClothId")]
        //public Clothes Clothes { get; set; }

        public int DiscountId { get; set; }
        //[ForeignKey("DiscountId")]
        //public Discounts Discounts { get; set; }
    }
}
