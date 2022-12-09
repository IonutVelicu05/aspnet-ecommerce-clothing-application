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
				ClothesCategoryId = cloth.ClothesCategoryId,
				PriceAfterDiscount = cloth.Price,
				DiscountId = cloth.DiscountId
			};
			await _context.Clothes.AddAsync(newCloth);
			await _context.SaveChangesAsync();
			var newDiscount = new Clothes_Discounts()
			{
				ClothId = newCloth.Id,
				DiscountId = newCloth.DiscountId
            };
            await _context.Clothes_Discounts.AddAsync(newDiscount);
            await _context.SaveChangesAsync();
            /*
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
					_context.Clothes_Discounts.Add(newDiscount);
					//await _context.Clothes_Discounts.AddAsync(newDiscount);
				}
				await _context.SaveChangesAsync();
			}*/
        }
        public async Task<List<Clothes>> GetAllWithDiscounts()
        {
            var clothes = await _context.Clothes.ToListAsync();
            var discounts = await _context.Clothes_Discounts.ToListAsync();

            foreach (var cloth in clothes)
            {
                foreach (var discount in discounts)
                {
                    if (cloth.Id == discount.ClothId)
                    {
                        var discountPercentage = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == discount.DiscountId);
                        cloth.PriceAfterDiscount = cloth.Price - cloth.Price * discountPercentage.Discount / 100;
                    }
                }
            }
            return clothes;
        }

        public async Task<List<Clothes>> GetMaleClothesWithDiscounts()
        {
            var clothes = await _context.Clothes.Where(n => n.Gender == "M").ToListAsync();
            var discounts = await _context.Clothes_Discounts.ToListAsync();

            foreach (var cloth in clothes)
            {
                foreach (var discount in discounts)
                {
                    if (cloth.Id == discount.ClothId)
                    {
                        var discountPercentage = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == discount.DiscountId);
                        cloth.PriceAfterDiscount = cloth.Price - cloth.Price * discountPercentage.Discount / 100;
                    }
                }
            }
            return clothes;
        }
        public async Task<List<Clothes>> GetFemaleClothesWithDiscounts()
        {
            var clothes = await _context.Clothes.Where(n => n.Gender == "F").ToListAsync();
            var discounts = await _context.Clothes_Discounts.ToListAsync();

            foreach (var cloth in clothes)
            {
                foreach (var discount in discounts)
                {
                    if (cloth.Id == discount.ClothId)
                    {
                        var discountPercentage = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == discount.DiscountId);
                        cloth.PriceAfterDiscount = cloth.Price - cloth.Price * discountPercentage.Discount / 100;
                    }
                }
            }
            return clothes;
        }
        public async Task<ClothesCategory> GetCategoryByName(string name)
		{
			var categoryDetails = await _context.Clothes_Categories.FirstOrDefaultAsync(n => n.Name == name);
			return categoryDetails;
		}

		public async Task<Clothes> GetClothByIdAsync(int id)
		{
			//var clothDetails = await _context.Clothes.Include(p => p.Producer).Include(cd => cd.Clothes_Discounts).ThenInclude(d => d.Discounts)
			//.FirstOrDefaultAsync(n => n.Id == id);
			var clothDetails = await _context.Clothes.Include(p => p.Producer).FirstOrDefaultAsync(n => n.Id == id);
			var clothCategory = await _context.Clothes_Categories.FirstOrDefaultAsync(n => n.Id == clothDetails.ClothesCategoryId);
			var clothDiscounts = await _context.Clothes_Discounts.FirstOrDefaultAsync(n => n.ClothId == clothDetails.Id);
			if(clothDiscounts != null)
			{
				var discountNumber = await _context.Discounts.FirstOrDefaultAsync(n => n.Id == clothDiscounts.DiscountId);
				clothDetails.PriceAfterDiscount = clothDetails.Price - clothDetails.Price * discountNumber.Discount / 100;
			}
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

		public async Task UpdateClothAsync(NewClothesVM cloth)
		{
			var dbCloth = await _context.Clothes.FirstOrDefaultAsync(n => n.Id == cloth.Id);
			if (dbCloth != null)
			{
				dbCloth.Name = cloth.Name;
				dbCloth.Description = cloth.Description;
				dbCloth.Price = cloth.Price;
				dbCloth.Gender = cloth.Gender;
				dbCloth.Size = cloth.Size;
				dbCloth.Stock = cloth.Stock;
				dbCloth.ImageURL = cloth.ImageURL;
				dbCloth.ProducerId = cloth.ProducerId;
				dbCloth.ClothesCategoryId = cloth.ClothesCategoryId;
				dbCloth.DiscountId = cloth.DiscountId;
			}
			await _context.SaveChangesAsync();
			//remove discounts
			var existingDiscounts = _context.Clothes_Discounts.Where(n => n.ClothId == cloth.Id).ToList();
			_context.Clothes_Discounts.RemoveRange(existingDiscounts);
			await _context.SaveChangesAsync();

            var newDiscount = new Clothes_Discounts()
            {
                ClothId = dbCloth.Id,
                DiscountId = dbCloth.DiscountId
            };
            await _context.Clothes_Discounts.AddAsync(newDiscount);
            await _context.SaveChangesAsync();

            //add new discounts 
            /*
            if (cloth.ClothesDiscountIds.Count > 0)
            {
                foreach (var discountId in cloth.ClothesDiscountIds)
                {
                    var newDiscount = new Clothes_Discounts()
                    {
                        ClothId = cloth.Id,
                        DiscountId = discountId
                    };
                    await _context.Clothes_Discounts.AddAsync(newDiscount);
                }
                await _context.SaveChangesAsync();
            }*/
        }

		public async Task DeleteClothAsync(int id)
		{
            var cloth = _context.Clothes.Where(n => n.Id == id).ToList();
            _context.Clothes.RemoveRange(cloth);
            await _context.SaveChangesAsync();
        }
	}
}
