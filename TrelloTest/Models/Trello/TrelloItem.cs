namespace TrelloTest.Models.Trello
{
	public class TrelloItem : ITrelloItem
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Token { get; set; }
	}
}