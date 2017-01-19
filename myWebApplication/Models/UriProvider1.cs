using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using myWebApplication.Configurations;

namespace myWebApplication.Models
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