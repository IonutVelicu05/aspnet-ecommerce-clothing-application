using eClothes.Data.Base;
using eClothes.Data.ViewModels;
using eClothes.Models;

namespace eClothes.Data.Services
{
	public interface IClothesService : IEntityBaseRepository<Clothes>
	{
		Task<Clothes> GetClothByIdAsync(int id);
		Task<NewClothesDropdownsVM> GetNewClothDropdownsValues();
		Task AddNewClothAsync(NewClothesVM cloth);
		Task<ClothesCategory> GetCategoryByName(string name);
	}
}
