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
		Task UpdateClothAsync(NewClothesVM cloth);
		Task<ClothesCategory> GetCategoryByName(string name);
		Task<List<Clothes>> GetAllWithDiscounts();
		Task<List<Clothes>> GetMaleClothesWithDiscounts();
		Task<List<Clothes>> GetFemaleClothesWithDiscounts();
		Task DeleteClothAsync(int id);
	}
}
