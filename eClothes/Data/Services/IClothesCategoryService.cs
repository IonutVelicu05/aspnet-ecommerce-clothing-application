using eClothes.Data.Base;
using eClothes.Data.ViewModels;
using eClothes.Models;

namespace eClothes.Data.Services
{
    public interface IClothesCategoryService : IEntityBaseRepository<ClothesCategory>
    {
        Task<ClothesCategory> GetCategoryByName(string categoryName);
        Task<NewClothesCategoryDropdownVM> GetCategoriesDropdown();
    }
}
