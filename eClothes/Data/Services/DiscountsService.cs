using eClothes.Models;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Data.Services
{
    public class DiscountsService : IDiscountsService
    {
        private readonly AppDbContext _context;
        public DiscountsService(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Discounts discount)
        {
            _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Discounts.FirstOrDefaultAsync(n => n.Id == id);
            _context.Discounts.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Discounts>> GetAllAsync()
        {
            var results = await _context.Discounts.ToListAsync();
            return results;
        }

        public async Task<Discounts> GetByIdAsync(int id)
        {
            var results = await _context.Discounts.FirstOrDefaultAsync(n => n.Id == id);
            return results;
        }

        public async Task<Discounts> UpdateAsync(int id, Discounts newDiscount)
        {
            _context.Update(newDiscount);
            await _context.SaveChangesAsync();
            return newDiscount;
        }
    }
}
