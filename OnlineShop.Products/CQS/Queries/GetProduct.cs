using OnlineShop.Products.Dtos;
using OnlineShop.Shared.CQS.Queries;
using System;

namespace OnlineShop.Products.CQS.Queries
{
	public class GetProduct : IQuery<ProductDto>
	{
		public Guid Id { get; set; }
	}
}
