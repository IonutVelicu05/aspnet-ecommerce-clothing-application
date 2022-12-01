using eClothes.Models;

namespace eClothes.Data.ViewModels
{
	public class NewClothesDropdownsVM
	{
		public List<Discounts> Discounts { get; set; }
		public List<Producer> Producers { get; set; }
		public List<ClothesCategory> Categories { get; set; }

		public NewClothesDropdownsVM()
		{
			Producers = new List<Producer>();
			Discounts = new List<Discounts>();
			Categories = new List<ClothesCategory>();
		}
	}
}