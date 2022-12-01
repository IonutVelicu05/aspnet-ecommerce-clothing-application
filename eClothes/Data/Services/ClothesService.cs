using eClothes.Data.Base;
using eClothes.Data.ViewModels;
using eClothes.Models;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Data.Services
{
	public class ClothesService : EntityBaseRepository<Clothes>, IClothesService
	{
		private readonly AppDbContext _context;
		public ClothesService(AppDbContext context) : base(context)
		{
			_context =	context;
		}

		public async Task AddNewClothAsync(NewClothesVM cloth)
		{
			var newCloth = new Clothes()
			{
				Name = cloth.Name,
				Description = cloth.Description,
				Price = cloth.Price,
				Gender = cloth.Gender,
				Size = cloth.Size,
				Stock = cloth.Stock,
				ImageURL = cloth.ImageURL,
				ProducerId = cloth.ProducerId,
				ClothesCategoryId = cloth.ClothesCategoryId
			};
			await _context.Clothes.AddAsync(newCloth);
			await _context.SaveChangesAsync();
			//add discounts 
			if(cloth.ClothesDiscountIds.Count > 0)
			{
				foreach (var discountId in cloth.ClothesDiscountIds)
				{
					var newDiscount = new Clothes_Discounts()
					{
						ClothId = newCloth.Id,
						DiscountId = discountId
					};
					await _context.Clothes_Discounts.AddAsync(newDiscount);
				}
				await _context.SaveChangesAsync();
			}
		}

		public async Task<ClothesCategory> GetCategoryByName(string name)
		{
			var categoryDetails = await _context.Clothes_Categories.FirstOrDefaultAsync(n => n.Name == name);
			return categoryDetails;
		}

		public async Task<Clothes> GetClothByIdAsync(int id)
		{
			var clothDetails = await _context.Clothes.Include(p => p.Producer).Include(cd => cd.Clothes_Discounts).ThenInclude(d => d.Discounts)
				.FirstOrDefaultAsync(n => n.Id == id);
			var clothCategory = await _context.Clothes_Categories.FirstOrDefaultAsync(n => n.Id == clothDetails.ClothesCategoryId);
			clothDetails.ClothesCategory.Name = clothCategory.Name;
			return clothDetails;
		}

		public async Task<NewClothesDropdownsVM> GetNewClothDropdownsValues()
		{
			var response = new NewClothesDropdownsVM()
			{
				Discounts = await _context.Discounts.OrderBy(n => n.Name).ToListAsync(),
				Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
				Categories = await _context.Clothes_Categories.OrderBy(n => n.Name).ToListAsync()
			};
			return response;
		}
	}
}
