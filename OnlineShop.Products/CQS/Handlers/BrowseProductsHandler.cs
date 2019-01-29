using OnlineShop.Products.CQS.Queries;
using OnlineShop.Products.Dtos;
using OnlineShop.Products.Repositories;
using OnlineShop.Shared.CQS.Handlers;
using System.Threading.Tasks;

namespace OnlineShop.Products.CQS.Handlers
{
	public class BrowseProductsHandler : IQueryHandler<BrowseProducts, ProductDto>
	{
		private readonly IProductRepository _productRepository;

		public BrowseProductsHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<ProductDto> HandleAsync(BrowseProducts query)
		{
			var pagedResult = await _productRepository.BrowseAsync(query);
			var products = pagedResult.Items.Select(p => new ProductDto
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Vendor = p.Vendor,
				Price = p.Price,
				Quantity = p.Quantity
			}).ToList();

			return PagedResult<ProductDto>.From(pagedResult, products);
		}
	}
}
