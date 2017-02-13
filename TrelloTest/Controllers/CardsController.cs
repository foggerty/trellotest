using System;
using System.Web.Mvc;
using TrelloTest.Infrastructure.Logging;
using TrelloTest.Infrastructure.Trello;
using TrelloTest.Models.Trello;

namespace TrelloTest.Controllers
{
	public class CardsController : Controller
	{
		private readonly ILog _log;
		private readonly ITrelloQuery _query;
		private readonly ITrelloUpdate _update;

		public CardsController(
			ILog log,
			ITrelloQuery query,
			ITrelloUpdate update)
		{
			_log = log;
			_query = query;
			_update = update;
		} 
		
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

		public ActionResult Card(string cardId, string listId)
		{
			// if user is not authenticated, redirect to main page

			var card = new TrelloCard { Id = cardId, NewComment = string.Empty };

			return View(card);
		}

		public ActionResult UpdateCard(string newComment, string cardId, string listId)
		{
			_update.AddComment(cardId, newComment);

			return RedirectToAction("cards", "cards", new { listId = listId } );
		}

		/// <summary>
		/// Utility method to trap (expected) exceptions/errors from any of the Trello
		/// providers, meaning can all be handled in one place.
		/// </summary>
		/// <typeparam name="T">The return type.</typeparam>
		/// <param name="method">Function that will be making the call to Trello.</param>
		/// <returns></returns>
		private T TrelloTrap<T>(Func<T> method)
		{
			try
			{
				return method();
			}
			catch(Exception ex)
			{
				_log.Error("Error when communicating with Trello.", ex);

				throw;
			}
		}
	}
}