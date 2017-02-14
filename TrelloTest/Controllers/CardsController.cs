using System.Web.Mvc;
using TrelloTest.Infrastructure.Logging;
using TrelloTest.Infrastructure.TrelloClient;
using TrelloTest.Models.Trello;

namespace TrelloTest.Controllers
{
	public class CardsController : Controller
	{
		private readonly ILog _log;
		private readonly ITrelloService _trelloService;

		public CardsController(
			ILog log,
			ITrelloService trelloService)
		{
			_log = log;
			_trelloService = trelloService;
		}

		public ActionResult Boards()
		{
			// if user is not authenticated, redirect to main page

			var boards = _trelloService.Boards();

			return View(boards);
		}

		public ActionResult Board(string boardId)
		{
			// if user is not authenticated, redirect to main page

			var board = _trelloService.Board(boardId);

			return View(board);
		}

		public ActionResult List(string listId)
		{
			// if user is not authenticated, redirect to main page

			var list = _trelloService.List(listId);

			return View(list);
		}

		public ActionResult Card(string cardId, string listId)
		{
			// if user is not authenticated, redirect to main page

			var card = new TrelloCard
			{
				Id = cardId,
				ListId = listId,
				NewComment = string.Empty
			};

			return View(card);
		}

		public ActionResult UpdateCard(string newComment, string cardId, string listId)
		{
			_trelloService.AddComment(cardId, newComment);

			return RedirectToAction("cards", "cards", new { listId = listId });
		}
	}
}