using OnlineShop.Products.Exceptions;
using OnlineShop.Shared.Extensions;
using OnlineShop.Shared.Types;
using System;

namespace OnlineShop.Products.Domain
{
	public class Product : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public string Vendor { get; private set; }
		public decimal Price { get; private set; }
		public int Quantity { get; private set; }

		public Product(Guid id, string name, string description, string vendor, decimal price, int quantity)
			: base(id)
		{
			SetName(name);
			SetDescription(description);
			SetVendor(vendor);
			SetPrice(price);
			SetQuantity(quantity);
		}

		public void SetName(string name)
		{
			if (name.IsEmpty())
				throw new OnlineShopException(Code.EmptyProductName, "Product name cannot be empty.");

			Name = name.Trim().ToLowerInvariant();
			SetUpdateDate();
		}

		public void SetDescription(string description)
		{
			if (description.IsEmpty())
				throw new OnlineShopException(Code.EmptyProductDescription, "Product description cannot be empty.");

			Description = description.Trim();
			SetUpdateDate();
		}

		public void SetVendor(string vendor)
		{
			if (vendor.IsEmpty())
				throw new OnlineShopException(Code.EmptyProductVendor, "Product vendor cannot be empty.");

			Vendor = vendor.Trim().ToLowerInvariant();
			SetUpdateDate();
		}

		public void SetPrice(decimal price)
		{
			if (price <= 0)
				throw new OnlineShopException(Code.InvalidProductPrice, "Product price cannot be zero or negative.");

			Price = price;
			SetUpdateDate();
		}

		public void SetQuantity(int quantity)
		{
			if (quantity < 0)
				throw new OnlineShopException(Code.InvalidProductQuantity, "Product quantity cannot be negative.");

			Quantity = quantity;
			SetUpdateDate();
		}
	}
}
