namespace TrelloTest.Models.Trello
{
	public class TrelloCard : ITrelloItem
	{
		public string Id { get; set; }

		public string ListId { get; set; }

		public string NewComment { get; set; }

		public string Token { get; set; }
	}
}