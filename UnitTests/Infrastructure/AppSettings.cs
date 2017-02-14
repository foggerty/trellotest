using NUnit.Framework;
using TrelloTest.Infrastructure.Config;
using TrelloTest.Infrastructure.Exceptions;

namespace UnitTests.Infrastructure
{
	[TestFixture]
	public class AppSettings
	{
		[Test]
		public void Throws_exception_when_no_string_key()
		{
			Assert.Throws<ConfigException>(() => AppConfig.GetString("Nothing here."));
		}

		[Test]
		public void Throws_exception_when_no_int_key()
		{
			Assert.Throws<ConfigException>(() => AppConfig.GetInt("Nothing here."));
		}

		[Test]
		public void Happy_string_path_is_happy()
		{
			var test = AppConfig.GetString("GoodString");

			Assert.AreEqual("Moose", test);
		}

		[Test]
		public void Happy_int_path_is_happy()
		{
			var test = AppConfig.GetInt("GoodInt");

			Assert.AreEqual(123, test);
		}

		public void Bad_string_throws_exception()
		{
			Assert.Throws<ConfigException>(() => AppConfig.GetString("BadString"));
		}

		[Test]
		public void Bad_int_throws_exception()
		{
			Assert.Throws<ConfigException>(() => AppConfig.GetInt("BadInt"));
		}
	}
}
