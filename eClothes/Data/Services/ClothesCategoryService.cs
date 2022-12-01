using eClothes.Data.Base;
using eClothes.Data.ViewModels;
using eClothes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eClothes.Data.Services
{
    public class ClothesCategoryService : EntityBaseRepository<ClothesCategory>, IClothesCategoryService
    {
        private readonly AppDbContext _context;
        public ClothesCategoryService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ClothesCategory> GetCategoryByName(string categoryName)
        {
            var clothDetails = await _context.Clothes_Categories.FirstOrDefaultAsync(n => n.Name == categoryName);
            return clothDetails;
        }
        public async Task<NewClothesCategoryDropdownVM> GetCategoriesDropdown()
        {
            var response = new NewClothesCategoryDropdownVM()
            {
                ClothesCategory = await _context.Clothes_Categories.OrderBy(n => n.Name).ToListAsync(),
            };
            return response;
        }
    }
}
