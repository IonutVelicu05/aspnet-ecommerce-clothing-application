using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eClothes.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		public string Email { get; set; }

		public string UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; }

		public List<OrderItem> OrderItems { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
		public string Total { get; set; }
		public string OrderConfirmed { get; set; }
    }
}
