using System.Collections.Generic;

namespace TrelloTest.Models.Trello
{
	public class TrelloList : ITrelloItem
	{
		public string Id { get; set; }

		public string BoardId { get; set; }

		public List<TrelloTuple> Cards { get; set; }
	}
}