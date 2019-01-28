using Autofac;
using OnlineShop.Shared.CQS.Commands;
using OnlineShop.Shared.CQS.Handlers;
using System.Threading.Tasks;

namespace OnlineShop.Shared.CQS.Dispatchers
{
	public class CommandDispatcher : ICommandDispatcher
	{
		private readonly IComponentContext _context;

		public CommandDispatcher(IComponentContext context)
		{
			_context = context;
		}

		public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
			=> await _context.Resolve<ICommandHandler<TCommand>>().HandleAsync(command);
	}
}
