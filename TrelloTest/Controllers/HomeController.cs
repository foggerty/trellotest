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
			// determine if user is authenticted against Trello.  If yes, redirect to boards page.

			return View();
		}

		public RedirectToRouteResult Authenticate()
		{
			// if user is already authenticated, redirect to boards page

			return RedirectToAction("boards", "cards");
		}
	}
}