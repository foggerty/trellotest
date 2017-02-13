using System;

namespace TrelloTest.Infrastructure.Logging
{
	/// <summary>
	/// Slim wrapper around NLog, so (say) unit testing asssemblies don't need
	/// to import NLog, makes for easier mocking etc.
	/// </summary>
	public interface ILog
	{
		void Info(string msg);

		void Error(string msh);

		void Error(string msg, Exception ex);

		// warnings etc as needed....
	}
}
