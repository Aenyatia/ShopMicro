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
	public class DeleteProductHandler : ICommandHandler<DeleteProduct>
	{
		private readonly IProductRepository _productRepository;
		private readonly IBusPublisher _busPublisher;

		public DeleteProductHandler(IProductRepository productRepository, IBusPublisher busPublisher)
		{
			_productRepository = productRepository;
			_busPublisher = busPublisher;
		}

		public async Task HandleAsync(DeleteProduct command)
		{
			if (await _productRepository.ExistsAsync(command.Id))
				throw new OnlineShopException(Code.ProductNotFound, $"Product with id '{command.Id}' was not found.");

			await _productRepository.DeleteAsync(command.Id);
			await _busPublisher.PublishAsync(new ProductDeleted(command.Id));
		}
	}
}
