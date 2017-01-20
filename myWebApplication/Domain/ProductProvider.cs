using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;
using myWebApplication.Configurations;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace myWebApplication.Domain
{
	public class ProductProvider
	{
		UriProvider uriProvider = new UriProvider();
		public ProductSearchResultModel SearchProducts(ApplicationSettings settings, string search)
		{
			var emptyResults = new ProductSearchResultModel() { Products = new List<ProductModel>(), Count = 0 };
			if (string.IsNullOrEmpty(search))
				return emptyResults;

			using (var client = new WebClient())
			{
				var json = client.DownloadString(uriProvider.GetSearchUri(search, settings));
				var results = JsonConvert.DeserializeObject<ProductSearchResultModel>(json);
				if (results == null)
					return emptyResults;

				foreach (var p in results.Products)
				{
					p.ProductUrl = settings.ProductUrlPrefix + p.ProductUrl;
				}
				return results;
			}
		}
	}
}