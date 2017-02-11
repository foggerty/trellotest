using System;
using NLog;

namespace TrelloTest.Infrastructure.Logging
{
	public class Log : ILog
	{
		private readonly ILogger _logger;

		public Log(ILogger logger)
		{
			_logger = logger;
		}

		public void Info(string msg)
		{
			_logger.Info(msg);
		}

		public void Error(string msg)
		{
			_logger.Error(msg);
		}

		public void Error(string msg, Exception ex)
		{
			_logger.Error(ex, msg);
		}
	}
}