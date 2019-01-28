using OnlineShop.Shared.Types;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShop.Shared.Mongo
{
	public interface IMongoRepository<TEntity> where TEntity : IIdentifiable
	{
		Task<TEntity> GetAsync(Guid id);
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

		Task AddAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(Guid id);

		Task<bool> ExistsAsync(Guid id);
		Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
	}
}
