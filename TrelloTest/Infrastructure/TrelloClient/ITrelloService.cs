using System;
using TrelloTest.Models.Trello;

namespace TrelloTest.Infrastructure.TrelloClient
{
	public interface ITrelloService
	{
		Uri Url { get; }

		TrelloBoard Board(string token, string boardId);

		TrelloBoards Boards(string token);

		TrelloList List(string token, string listId);

		void AddComment(string token, string cardId, string comment);
	}
}
