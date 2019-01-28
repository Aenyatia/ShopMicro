using OnlineShop.Products.Domain;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Products.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetAsync(Guid id);
		Task<bool> ExistsAsync(Guid id);

		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Guid id);
	}
}
