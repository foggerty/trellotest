using System;
using System.Linq;
using TrelloNet;
using TrelloTest.Infrastructure.Config;
using TrelloTest.Models.Trello;

namespace TrelloTest.Infrastructure.TrelloClient
{
	public class TrelloService : ITrelloService
	{
		private readonly  Trello _trello;

		public TrelloService(Trello trello)
		{
			_trello = trello;
		}

		public Uri Url
		{
			get
			{
				var appName = AppConfig.AppName();
				return _trello.GetAuthorizationUrl(appName, Scope.ReadWrite);
			}
		}

		public void AddComment(string token, string cardId, string comment)
		{
			_trello.Authorize(token);

			_trello.Cards.AddComment(new CardId(cardId), comment);
		}

		public TrelloBoards Boards(string token)
		{
			_trello.Authorize(token);

			var results = _trello.Boards.ForMe(BoardFilter.All);

			if (results == null)
			{
				return new TrelloBoards { Token = token };
			}

			var boards =  results
				.Select(x => new TrelloTuple { Id = x.Id, Label = x.Name } )
				.ToList();

			return new TrelloBoards { Token = token, Boards = boards };
		}

		public TrelloBoard Board(string token, string boardId)
		{
			_trello.Authorize(token);

			var board = _trello.Boards.WithId(boardId);
			var lists = _trello
				.Lists
				.ForBoard(new BoardId(boardId))
				.Select(x => new TrelloTuple { Id = x.Id, Label = x.Name })
				.ToList();

			return new TrelloBoard
			{
				Id = board.Id,
				Name = board.Name,
				Lists = lists
			};	
		}

		public TrelloList List(string token, string listId)
		{
			_trello.Authorize(token);

			var list = _trello.Lists.WithId(listId);
			var cards = _trello
				.Cards
				.ForList(new ListId(listId))
				.Select(x => new TrelloTuple { Id = x.Id, Label = x.Name })
				.ToList();

			return new TrelloList
			{
				Id = list.Id,
				BoardId = list.IdBoard,
				Name = list.Name,
				Cards = cards
			};
		}
	}
}