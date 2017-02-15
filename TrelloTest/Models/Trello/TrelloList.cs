using System.Collections.Generic;

namespace TrelloTest.Models.Trello
{
	public class TrelloList : TrelloItem
	{ 
		public string BoardId { get; set; }

		public List<TrelloTuple> Cards { get; set; }
	}
}