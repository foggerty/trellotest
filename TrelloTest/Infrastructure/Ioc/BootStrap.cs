using Ninject.Modules;
using Ninject.Web.Common;
using NLog;
using TrelloNet;
using TrelloTest.Infrastructure.Config;
using TrelloTest.Infrastructure.Logging;
using TrelloTest.Infrastructure.TrelloClient;

namespace TrelloTest.Infrastructure.Ioc
{
	public class BootStrap : NinjectModule
	{
		public override void Load()
		{
			Logging();
			Trello();
		}

		private void Logging()
		{
			Bind<ILogger>().ToMethod(x => LogManager.GetCurrentClassLogger());
			Bind<ILog>().To<Log>().InSingletonScope(); // NLog is thread safe
		}

		private void Trello()
		{
			var appKey = AppConfig.TrelloApiKey();

			Bind<Trello>().ToMethod(x => new Trello(appKey)).InRequestScope();
			Bind<ITrelloService>().To<TrelloService>().InRequestScope();
		}
	}
}