using System;

namespace TrelloTest.Infrastructure.Exceptions
{
	/// <summary>
	/// Custom exeption to indicate that for whatever reason, there was
	/// a problem when communicating with Trello.
	/// </summary>
	public class TrelloComsException : Exception
	{
	}
}