using Newtonsoft.Json;
using OnlineShop.Shared.CQS.Commands;
using System;

namespace OnlineShop.Products.CQS.Events
{
	public class ProductDeleted : IEvent
	{
		public Guid Id { get; }

		[JsonConstructor]
		public ProductDeleted(Guid id)
		{
			Id = id;
		}
	}
}
