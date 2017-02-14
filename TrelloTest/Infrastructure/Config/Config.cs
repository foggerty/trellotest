using System;
using System.Configuration;
using TrelloTest.Infrastructure.Exceptions;

namespace TrelloTest.Infrastructure.Config
{
	/// <summary>
	/// This is just a simple wrapper around the app.config app settings.
	/// The idea is that instead of having magic strings everywhere code needs
	/// to access something in config, this gets called.  It also forces
	/// people to indictae if they want a defaut value, otherwise a missing 
	/// application key is considered a serious (deployment) bug - fail early!
	/// 
	/// This means that:
	///   a) developers have to explicitly specify if they want "default"
	///      values.  I've been bitten a few times by odd behaviour because
	///      of code that "worked" with nulls, despite the assumption that the
	///      key/value would always be set.
	///   b) All magic config strings are in one place.
	///   c) Easy to test/mock.  Just replace the pubilc functions with something
	///      that returns a known value.
	///      
	/// There's slight problem in that the GetXyz() methods need to be public
	/// to be unit tested, meaning that they can be abused if people don't feel
	/// like adding their keys to here, and then a new access method - code
	/// reviews FTW.
	/// </summary>
	public static class Config
	{
		private const string TrelloKey = "TrelloApiKey";

		public static Func<string> TrelloApiKey = () => GetString(TrelloKey);

		public static string GetString(string key)
		{
			TestKey(key);

			return ConfigurationManager.AppSettings[key];
		}

		public static string GetStringWithDefault(string key, string def)
		{
			var result = ConfigurationManager.AppSettings[key];

			return result == null ? def : result;
		}

		public static int GetInt(string key)
		{
			TestKey(key);

			return TestInt(key);			
		}

		public static int GetIntWithDefault(string key, int def)
		{
			var test = ConfigurationManager.AppSettings[key];
			int result;

			if (!int.TryParse(test, out result))
			{
				return def;
			}

			return result;
		}

		private static int TestInt(string key)
		{
			var test = ConfigurationManager.AppSettings[key];
			int result;

			if(!int.TryParse(test, out result))
			{
				throw new ConfigException("Invalid integer value in app.config for key '{key}'");
			}

			return result;
		}

		private static void TestKey(string key)
		{
			var test = ConfigurationManager.AppSettings[key];

			if(string.IsNullOrWhiteSpace(test))
			{
				throw new ConfigException($"Could not find key '{key}' in app.config.");
			}
		}
	}
}