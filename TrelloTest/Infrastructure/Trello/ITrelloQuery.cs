using System.Collections.Generic;
using TrelloTest.Models.Trello;

namespace TrelloTest.Infrastructure.Trello
{
	public interface ITrelloQuery
	{
		List<TrelloTuple> AllBoards();

		List<TrelloTuple> AllLists(string boardId);

		List<TrelloTuple> AllCards(string listId);
	}
}
