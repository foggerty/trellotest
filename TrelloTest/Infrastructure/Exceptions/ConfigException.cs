using System;

namespace TrelloTest.Infrastructure.Exceptions
{
	public class ConfigException : Exception
	{
		public ConfigException(string msg) : base(msg)
		{ }
	}
}