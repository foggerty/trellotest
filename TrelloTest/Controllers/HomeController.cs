using System.Web.Mvc;
using TrelloTest.Infrastructure.Logging;

namespace TrelloTest.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILog _log;

		public HomeController(ILog log)
		{
			_log = log;
		}

		public ActionResult Index()
		{
			_log.Info("I hope this is all connected up....");

			return View();
		}
	}
}