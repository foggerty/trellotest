using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloTest.Infrastructure.Exceptions
{
	public class ConfigException : Exception
	{
		public ConfigException(string msg) : base(msg)
		{ }
	}
}