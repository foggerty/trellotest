using System.Collections.Generic;

namespace TrelloTest.Models.Trello
{
	public class TrelloBoard : ITrelloItem
	{
		public string Id { get; set; }

		public string Name { get; set; }
		public List<TrelloTuple> Lists { get; set; }
	}
}