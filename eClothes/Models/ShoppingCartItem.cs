using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eClothes.Models
{
	public class ShoppingCartItem
	{
		[Key]
		public int Id { get; set; }

		public Clothes Cloth { get; set; }
		public int Amount { get; set; }

		public string ShoppingCartId { get; set; }

	}
}
