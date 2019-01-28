using System;

namespace OnlineShop.Shared.Types
{
	public interface IIdentifiable
	{
		Guid Id { get; }
	}
}
