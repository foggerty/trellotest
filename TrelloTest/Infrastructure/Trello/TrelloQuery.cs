using System;
using System.Collections.Generic;
using TrelloTest.Models.Trello;

namespace TrelloTest.Infrastructure.Trello
{
	public class TrelloQuery : ITrelloQuery
	{
		public List<TrelloTuple> AllBoards()
		{
			throw new NotImplementedException();
		}

		public List<TrelloTuple> AllCards(string listId)
		{
			throw new NotImplementedException();
		}

		public List<TrelloTuple> AllLists(string boardId)
		{
			throw new NotImplementedException();
		}
	}
}