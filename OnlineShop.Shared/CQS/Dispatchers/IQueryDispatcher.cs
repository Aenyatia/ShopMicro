using OnlineShop.Shared.CQS.Queries;
using System.Threading.Tasks;

namespace OnlineShop.Shared.CQS.Dispatchers
{
	public interface IQueryDispatcher
	{
		Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
	}
}
