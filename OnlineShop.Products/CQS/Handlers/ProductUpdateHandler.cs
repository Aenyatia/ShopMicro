using OnlineShop.Products.CQS.Commands;
using OnlineShop.Products.CQS.Events;
using OnlineShop.Products.Exceptions;
using OnlineShop.Products.Repositories;
using OnlineShop.Shared;
using OnlineShop.Shared.CQS.Handlers;
using OnlineShop.Shared.Types;
using System.Threading.Tasks;

namespace OnlineShop.Products.CQS.Handlers
{
	public class ProductUpdateHandler : ICommandHandler<UpdateProduct>
	{
		private readonly IProductRepository _productRepository;
		private readonly IBusPublisher _busPublisher;

		public ProductUpdateHandler(IProductRepository productRepository, IBusPublisher busPublisher)
		{
			_productRepository = productRepository;
			_busPublisher = busPublisher;
		}

		public async Task HandleAsync(UpdateProduct command)
		{
			var product = await _productRepository.GetAsync(command.Id);
			if (product == null)
				throw new OnlineShopException(Code.ProductNotFound, $"Product with id '{command.Id}' was not found.");

			product.SetName(command.Name);
			product.SetDescription(command.Description);
			product.SetVendor(command.Vendor);
			product.SetPrice(command.Price);
			product.SetQuantity(command.Quantity);

			await _productRepository.UpdateAsync(product);
			await _busPublisher.PublishAsync(new ProductUpdated(command.Id, command.Name, command.Description,
				command.Vendor, command.Price, command.Quantity));
		}
	}
}
