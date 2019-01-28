using System.Threading.Tasks;
using OnlineShop.Shared.CQS.Commands;

namespace OnlineShop.Shared.CQS.Handlers
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);
	}
}
