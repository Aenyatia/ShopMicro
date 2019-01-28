using Autofac;

namespace OnlineShop.Shared.CQS.Dispatchers
{
	public static class Extensions
	{
		public static void AddDispatchers(this ContainerBuilder builder)
		{
			builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
			builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
			builder.RegisterType<Dispatcher>().As<IDispatcher>();
		}
	}
}
