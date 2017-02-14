using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloTest.Models.Trello
{
	public class TrelloBoards
	{
		public string Token { get; set; }

		public List<TrelloTuple> Boards { get; set; }
	}
}