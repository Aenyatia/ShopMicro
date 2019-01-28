using System.Threading.Tasks;
using OnlineShop.Shared.CQS.Commands;
using OnlineShop.Shared.CQS.Queries;

namespace OnlineShop.Shared.CQS.Dispatchers
{
	public interface IDispatcher
	{
		Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
		Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
	}
}
