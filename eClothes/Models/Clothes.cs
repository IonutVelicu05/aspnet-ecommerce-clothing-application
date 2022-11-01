using eClothes.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace eClothes.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; }
        public ClothesCategories ClothesCategory { get; set;}
        public List<Clothes_Discounts> Clothes_Discounts { get; set; }

        //producator
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
