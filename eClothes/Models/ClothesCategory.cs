using eClothes.Data.Base;
using eClothes.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eClothes.Models
{
	public class ClothesCategory : IEntityBase
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "The name is required")]
		[Display(Name = "Nume categorie de haine")]
		public string Name { get; set; }

        public List<Clothes>? Clothes_Categories { get; set; }
    }
}
