using System.Web.Mvc;
using TrelloTest.Infrastructure.Trello;
using TrelloTest.Models.Trello;

namespace TrelloTest.Controllers
{
	public class CardsController : Controller
	{
		private ITrelloQuery _query;
		private ITrelloUpdate _upadate;

		public CardsController(
			ITrelloQuery query,
			ITrelloUpdate update)
		{
			_query = query;
			_upadate = update;
		} 
		
		// GET: Cards
		public ActionResult Boards()
		{
			// if user is not authenticated, redirect to main page

			var boards = _query.AllBoards();

			return View(boards);
		}

		public ActionResult Lists(string boardId)
		{
			// if user is not authenticated, redirect to main page

			var lists = _query.AllLists(boardId);
			var board = new TrelloBoard { Id = boardId, Lists = lists };

			return View(board);
		}

		public ActionResult Cards(string listId)
		{
			// if user is not authenticated, redirect to main page

			var cards = _query.AllCards(listId);
			var list = new TrelloList { Id = listId, Cards = cards };

			return View(list);
		}

		public ActionResult UpdateCard(string cardId)
		{
			// if user is not authenticated, redirect to main page

			return View();
		}
	}
}