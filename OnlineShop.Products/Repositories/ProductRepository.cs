using OnlineShop.Products.Domain;
using OnlineShop.Shared.Mongo;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Products.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IMongoRepository<Product> _repository;

		public ProductRepository(IMongoRepository<Product> repository)
		{
			_repository = repository;
		}

		public async Task<Product> GetAsync(Guid id)
			=> await _repository.GetAsync(id);

		public async Task<bool> ExistsAsync(Guid id)
			=> await _repository.ExistsAsync(id);

		public async Task AddAsync(Product product)
			=> await _repository.AddAsync(product);

		public async Task UpdateAsync(Product product)
			=> await _repository.UpdateAsync(product);

		public async Task DeleteAsync(Guid id)
			=> await _repository.DeleteAsync(id);
	}
}
