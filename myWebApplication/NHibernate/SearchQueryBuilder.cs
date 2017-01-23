using System;
using myWebApplication.Configurations;

namespace myWebApplication.Domain
{
	public class SearchQueryBuilder
	{
		public Uri SearchApiUrl { get; }
		public int Limit { get; }
		public string Token { get; }
		public string Hash { get; }
		public string Query { get; set; }

		private ApplicationSettings _settings = new ApplicationSettings();

		public SearchQueryBuilder()
		{
			SearchApiUrl = _settings.SearchApiUrl;
			Limit = _settings.Limit;
			Token = _settings.AppToken;
			Hash = _settings.AppHash;
		}
	}
}