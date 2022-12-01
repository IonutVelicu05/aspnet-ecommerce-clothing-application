using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eClothes.Data.Base

{
	public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		public readonly AppDbContext _context;

		public EntityBaseRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
			await _context.SaveChangesAsync();
        }

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var result = await _context.Set<T>().ToListAsync();
			return result;
		}

		public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] expressions)
		{
			IQueryable<T> query = _context.Set<T>();
			query = expressions.Aggregate(query, (current, expressions) => current.Include(expressions));
			return await query.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
			return result;
		}

		public async Task UpdateAsync(int id, T entity)
		{
			EntityEntry entityEntry = _context.Entry<T>(entity);
			entityEntry.State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
