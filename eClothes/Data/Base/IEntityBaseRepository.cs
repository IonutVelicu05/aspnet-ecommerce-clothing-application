using eClothes.Models;
using System.Linq.Expressions;

namespace eClothes.Data.Base
{
	public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] expressions);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
