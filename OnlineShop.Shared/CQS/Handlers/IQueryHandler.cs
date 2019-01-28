using OnlineShop.Shared.CQS.Queries;
using System.Threading.Tasks;

namespace OnlineShop.Shared.CQS.Handlers
{
	public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query);
	}
}
