using Ninject.Modules;
using Ninject.Web.Common;
using NLog;
using TrelloTest.Infrastructure.Logging;
using TrelloTest.Infrastructure.Trello;

namespace TrelloTest.Infrastructure.Ioc
{
	public class BootStrap : NinjectModule
	{
		private void Logging()
		{
			// Logging
			Bind<ILogger>().ToMethod(x => LogManager.GetCurrentClassLogger());
			Bind<ILog>().To<Log>().InSingletonScope(); // NLog is thread safe

			// Trello client
			//Bind<ITrelloAuth>().To<TrelloAuth>().InRequestScope();
			//Bind<ITrelloQuery>().To<TrelloQuery>().InRequestScope();
			//Bind<ITrelloUpdate>().To<TrelloUpdate>().InRequestScope();

			Bind<ITrelloAuth>().To<TrelloStub>().InRequestScope();
			Bind<ITrelloQuery>().To<TrelloStub>().InRequestScope();
			Bind<ITrelloUpdate>().To<TrelloStub>().InRequestScope();
		}

		public override void Load()
		{
			Logging();
		}
	}
}