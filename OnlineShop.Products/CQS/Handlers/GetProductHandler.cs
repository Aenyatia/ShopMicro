using OnlineShop.Products.CQS.Queries;
using OnlineShop.Products.Dtos;
using OnlineShop.Products.Repositories;
using OnlineShop.Shared.CQS.Handlers;
using System.Threading.Tasks;

namespace OnlineShop.Products.CQS.Handlers
{
	public class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
	{
		private readonly IProductRepository _productRepository;

		public GetProductHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<ProductDto> HandleAsync(GetProduct query)
		{
			var product = await _productRepository.GetAsync(query.Id);

			return product == null ? null : new ProductDto
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Vendor = product.Vendor,
				Price = product.Price,
				Quantity = product.Quantity
			};
		}
	}
}
