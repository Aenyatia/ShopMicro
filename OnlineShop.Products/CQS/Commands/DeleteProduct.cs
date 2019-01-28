using Newtonsoft.Json;
using OnlineShop.Shared.CQS.Commands;
using System;

namespace OnlineShop.Products.CQS.Commands
{
	public class DeleteProduct : ICommand
	{
		public Guid Id { get; }

		[JsonConstructor]
		public DeleteProduct(Guid id)
		{
			Id = id;
		}
	}
}
