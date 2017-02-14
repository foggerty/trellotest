using System;
using System.Collections.Generic;
using TrelloTest.Models.Trello;

namespace TrelloTest.Infrastructure.TrelloClient
{
	public interface ITrelloService
	{
		Uri Url { get; }

		void Authorise(string token);

		TrelloBoard Board(string boardId);

		List<TrelloTuple> Boards();

		TrelloList List(string listId);

		void AddComment(string cardId, string comment);
	}
}
