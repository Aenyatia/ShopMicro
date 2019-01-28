using Newtonsoft.Json;
using OnlineShop.Shared.CQS.Commands;
using System;

namespace OnlineShop.Products.CQS.Events
{
	public class ProductUpdated : IEvent
	{
		public Guid Id { get; }
		public string Name { get; }
		public string Description { get; }
		public string Vendor { get; }
		public decimal Price { get; }
		public int Quantity { get; }

		[JsonConstructor]
		public ProductUpdated(Guid id, string name, string description, string vendor, decimal price, int quantity)
		{
			Id = id;
			Name = name;
			Description = description;
			Vendor = vendor;
			Price = price;
			Quantity = quantity;
		}
	}
}
