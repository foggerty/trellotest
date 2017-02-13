using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrelloTest.Infrastructure.Logging;
using TrelloTest.Models.Trello;

namespace TrelloTest.Infrastructure.Trello
{
	public class TrelloStub : ITrelloAuth, ITrelloQuery, ITrelloUpdate
	{
		private ILog _log;

		public TrelloStub(ILog log)
		{
			_log = log;
		}

		public void AddComment(string cardId, string comment)
		{
			_log.Info($"Updating card {cardId} with message '{comment}'.");
		}

		public List<TrelloTuple> AllBoards()
		{
			return new List<TrelloTuple>
			{
				new TrelloTuple { Id= "1", Label="Fred" },
				new TrelloTuple { Id="2", Label="Ethel" }
			};
		}

		public List<TrelloTuple> AllCards(string listId)
		{
			return new List<TrelloTuple>
			{
				new TrelloTuple { Id= "1", Label="Moose" },
				new TrelloTuple { Id="2", Label="Badger" }
			};
		}

		public List<TrelloTuple> AllLists(string boardId)
		{
			return new List<TrelloTuple>
			{
				new TrelloTuple { Id= "1", Label="Night" },
				new TrelloTuple { Id="2", Label="Day" }
			};
		}
	}
}