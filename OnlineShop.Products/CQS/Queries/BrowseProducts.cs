using OnlineShop.Products.Dtos;
using OnlineShop.Shared.CQS.Queries;

namespace OnlineShop.Products.CQS.Queries
{
	public class BrowseProducts : IQuery<ProductDto>
	{
		public decimal PriceFrom { get; set; }
		public decimal PriceTo { get; set; } = decimal.MaxValue;
	}
}
