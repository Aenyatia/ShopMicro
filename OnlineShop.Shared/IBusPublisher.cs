using OnlineShop.Shared.CQS.Commands;
using System.Threading.Tasks;

namespace OnlineShop.Shared
{
	public interface IBusPublisher
	{
		Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
		Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
	}
}
