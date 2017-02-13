namespace TrelloTest.Infrastructure.Trello
{
	public interface ITrelloUpdate
	{
		// ToDo - try bad input, see what Trello throws and put in an actual retun type
		void AddComment(string cardId, string comment);
	}
}
