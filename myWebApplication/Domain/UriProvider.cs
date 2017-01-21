using System;
using myWebApplication.Configurations;

namespace myWebApplication.Domain
{
	public interface IUriProvider
	{
		Uri GetSearchUri(string search, IApplicationSettings applicationSettings);
		Uri GetProductUrl(int productId, IApplicationSettings applicationSettings);
	}

	public class UriProvider : IUriProvider
	{
		public Uri GetSearchUri(string search, IApplicationSettings applicationSettings)
		{
			return new Uri($"{applicationSettings.SearchApiUrl}?q={search}&limit=20&token={applicationSettings.AppToken}&hash={applicationSettings.AppHash}");
		}

		public Uri GetProductUrl(int productId, IApplicationSettings applicationSettings)
		{
			return new Uri($"{applicationSettings.GetProductUrl}?ids={productId}&token={applicationSettings.AppToken}&hash={applicationSettings.AppHash}");
		}
	}
}