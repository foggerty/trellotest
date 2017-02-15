using System.Collections.Generic;

namespace TrelloTest.Models.Trello
{
	public class TrelloBoard : TrelloItem
	{ 
		public List<TrelloTuple> Lists { get; set; }
	}
}