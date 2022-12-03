using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eClothes.Models
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }

		public int Amount { get; set; }
		public double Price { get; set; }


		public int ClothId { get; set; }
        [ForeignKey("ClothId")]
        public Clothes Cloth { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
