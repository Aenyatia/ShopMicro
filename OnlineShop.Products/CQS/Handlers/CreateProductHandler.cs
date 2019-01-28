using System.Threading.Tasks;
using OnlineShop.Products.CQS.Commands;
using OnlineShop.Products.Domain;
using OnlineShop.Products.Exceptions;
using OnlineShop.Products.Repositories;
using OnlineShop.Shared.CQS.Handlers;
using OnlineShop.Shared.Types;

namespace OnlineShop.Products.CQS.Handlers
{
	public sealed class CreateProductHandler : ICommandHandler<CreateProduct>
	{
		private readonly IProductRepository _productRepository;

		public CreateProductHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task HandleAsync(CreateProduct command)
		{
			if (await _productRepository.ExistsAsync(command.Id))
				throw new OnlineShopException(Code.ProductAlreadyExists, $"Product '{command.Name}' already exists.");

			var product = new Product(command.Id, command.Name, command.Description,
				command.Vendor, command.Price, command.Quantity);

			await _productRepository.AddAsync(product);
		}
	}
}
