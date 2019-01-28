using OnlineShop.Shared.Messages;
using System.Threading.Tasks;

namespace OnlineShop.Shared.Handlers
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);
	}
}
