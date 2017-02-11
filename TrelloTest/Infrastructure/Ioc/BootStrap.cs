using Ninject.Modules;
using NLog;
using TrelloTest.Infrastructure.Logging;

namespace TrelloTest.Infrastructure.Ioc
{
	public class BootStrap : NinjectModule
	{
		private void Logging()
		{
			Bind<ILogger>().ToMethod(x => LogManager.GetCurrentClassLogger());
			Bind<ILog>().To<Log>().InSingletonScope(); // NLog is thread safe
		}

		public override void Load()
		{
			Logging();
		}
	}
}