using eClothes.Models;

namespace eClothes.Data.Services
{
    public interface IDiscountsService
    {
        Task<IEnumerable<Discounts>> GetAllAsync();

        Task<Discounts> GetByIdAsync(int id);

        Task AddAsync(Discounts discounts);

        Task<Discounts> UpdateAsync(int id, Discounts newDiscount);

        Task DeleteAsync(int id);
    }
}
