using System;

namespace OnlineShop.Shared.Types
{
	public class OnlineShopException : Exception
	{
		public string Code { get; }

		public OnlineShopException()
		{
		}

		public OnlineShopException(string code)
		{
			Code = code;
		}

		public OnlineShopException(string message, params object[] args)
			: this(string.Empty, message, args)
		{
		}

		public OnlineShopException(string code, string message, params object[] args)
			: this(null, code, message, args)
		{
		}

		public OnlineShopException(Exception innerException, string message, params object[] args)
			: this(innerException, string.Empty, message, args)
		{
		}

		public OnlineShopException(Exception innerException, string code, string message, params object[] args)
			: base(string.Format(message, args), innerException)
		{
			Code = code;
		}
	}
}
