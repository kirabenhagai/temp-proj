using System;
using myWebApplication.Configurations;

namespace myWebApplication.Domain
{
	public class UriProvider
	{
		public Uri GetSearchUri(string search, ApplicationSettings settings)
		{
			return new Uri($"{settings.SearchApiUrl}?q={search}&limit=20&token={settings.AppToken}&hash={settings.AppHash}");
		}

		public Uri GetProductUrl(int productId, ApplicationSettings settings)
		{
			return new Uri($"{settings.GetProductUrl}?ids={productId}&token={settings.AppToken}&hash={settings.AppHash}");
		}
	}
}