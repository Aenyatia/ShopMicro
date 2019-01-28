using System.Threading.Tasks;
using OnlineShop.Shared.CQS.Commands;

namespace OnlineShop.Shared.CQS.Handlers
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent
	{
		Task HandleAsync(TEvent @event);
	}
}
