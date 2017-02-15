using System.Collections.Generic;

namespace TrelloTest.Models.Trello
{
	public class TrelloBoards
	{
		public string Token { get; set; }

		public List<TrelloTuple> Boards { get; set; }
	}
}