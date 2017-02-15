namespace TrelloTest.Models.Trello
{
	public class TrelloCard : TrelloItem
	{
		public string ListId { get; set; }

		public string NewComment { get; set; }
	}
}