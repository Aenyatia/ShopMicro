using OnlineShop.Shared.CQS.Commands;
using System.Threading.Tasks;

namespace OnlineShop.Shared.CQS.Dispatchers
{
	public interface ICommandDispatcher
	{
		Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
