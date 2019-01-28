using OnlineShop.Products.Domain;
using OnlineShop.Shared.Mongo;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Products.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IMongoContext<Product> _context;

		public ProductRepository(IMongoContext<Product> context)
		{
			_context = context;
		}

		public async Task<Product> GetAsync(Guid id)
			=> await _context.GetAsync(id);

		public async Task<bool> ExistsAsync(string name)
			=> await _context.ExistsAsync(p => p.Name == name);

		public async Task AddAsync(Product product)
			=> await _context.AddAsync(product);

		public async Task UpdateAsync(Product product)
			=> await _context.UpdateAsync(product);

		public async Task DeleteAsync(Guid id)
			=> await _context.DeleteAsync(id);
	}
}
