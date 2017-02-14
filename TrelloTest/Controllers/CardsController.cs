using System;
using System.Web.Mvc;
using TrelloNet;
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

		public ActionResult Boards(string token)
		{
			return CallTrello(token,
				() =>
				{
					var boards = _trelloService.Boards(token);

					return View(boards);
				});
		}

		public ActionResult Board(string token, string boardId)
		{
			return CallTrello(token,
				() =>
				{
					var board = _trelloService.Board(token, boardId);

					return View(board);
				});
		}

		public ActionResult List(string token, string listId)
		{
			return CallTrello(token,
				() =>
				{
					var list = _trelloService.List(token, listId);

					return View(list);
				});
		}

		public ActionResult UpdateCard(string token, string newComment, string cardId, string listId)
		{
			return CallTrello(token,
				() =>
				{
					_trelloService.AddComment(token, cardId, newComment);

					return RedirectToAction("list", "cards", new { token = token, listId = listId });
				});
		}

		public ActionResult Card(string token, string cardId, string listId)
		{
			if (string.IsNullOrWhiteSpace(token))
			{
				return RedirectToAction("index", "home");
			}

			var card = new TrelloCard
			{
				Id = cardId,
				ListId = listId,
				NewComment = string.Empty,
				Token = token
			};

			return View(card);
		}

		/// <summary>
		/// Centralised exception handling for all calls to Trello.
		/// Will trap and handle Trello exceptions, all others bubble up
		/// and are handled as usual (i.e. not at all in this particular app).
		/// Will also redirect user to 'login' page if the token is missing.
		/// </summary>
		/// <param name="token">Trello auth token</param>
		/// <param name="call">Call to Trello.</param>
		/// <returns></returns>
		private ActionResult CallTrello(string token, Func<ActionResult> call)
		{
			if (string.IsNullOrWhiteSpace(token))
			{
				return RedirectToAction("index", "home");
			}

			try
			{
				return call();
			}
			catch (TrelloException ex)
			{
				return RedirectToAction("trelloError", "home", new { message = ex.Message });
			}
		}
	}
}