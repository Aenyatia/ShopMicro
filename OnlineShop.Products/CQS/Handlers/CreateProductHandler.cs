using OnlineShop.Products.CQS.Commands;
using OnlineShop.Products.CQS.Events;
using OnlineShop.Products.Domain;
using OnlineShop.Products.Exceptions;
using OnlineShop.Products.Repositories;
using OnlineShop.Shared;
using OnlineShop.Shared.CQS.Handlers;
using OnlineShop.Shared.Types;
using System.Threading.Tasks;

namespace OnlineShop.Products.CQS.Handlers
{
	public sealed class CreateProductHandler : ICommandHandler<CreateProduct>
	{
		private readonly IProductRepository _productRepository;
		private readonly IBusPublisher _busPublisher;

		public CreateProductHandler(IProductRepository productRepository, IBusPublisher busPublisher)
		{
			_productRepository = productRepository;
			_busPublisher = busPublisher;
		}

		public async Task HandleAsync(CreateProduct command)
		{
			if (await _productRepository.ExistsAsync(command.Name))
				throw new OnlineShopException(Code.ProductAlreadyExists, $"Product '{command.Name}' already exists.");

			var product = new Product(command.Id, command.Name, command.Description,
				command.Vendor, command.Price, command.Quantity);

			await _productRepository.AddAsync(product);
			await _busPublisher.PublishAsync(new ProductCreated(command.Id, command.Name, command.Description, command.Vendor, command.Price,
				command.Quantity));
		}
	}
}
