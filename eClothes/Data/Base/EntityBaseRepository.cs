using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eClothes.Data.Base

{
	public class EntityBaseRepository<T> : EntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		public Task AddAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<T> UpdateAsync(int id, T entity)
		{
			throw new NotImplementedException();
		}
	}
}
