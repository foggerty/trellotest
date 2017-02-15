using System.Web.Mvc;
using TrelloTest.Infrastructure.Logging;
using TrelloTest.Infrastructure.TrelloClient;
using TrelloTest.Models.Home;

namespace TrelloTest.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILog _log;
		private readonly ITrelloService _trelloService;

		public HomeController(
			ILog log,
			ITrelloService trelloService)
		{
			_log = log;
			_trelloService = trelloService;
		}

		public ActionResult Index()
		{
			var url = _trelloService.Url;
			var home = new Home
			{
				TrelloUrl = url.ToString(),
				AccessToken = string.Empty
			};

			return View(home);
		}

		public RedirectToRouteResult Authenticate(Home home)
		{
			return RedirectToAction("boards", "cards", new { token = home.AccessToken });
		}

		public ActionResult TrelloError(string message)
		{
			return View(new { message = message });
		}
	}
}