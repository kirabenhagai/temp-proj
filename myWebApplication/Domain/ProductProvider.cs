using System.Collections.Generic;
using System.Linq;
using System.Net;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;
using myWebApplication.Configurations;
using Newtonsoft.Json;

namespace myWebApplication.Domain
{
	public class ProductProvider
	{
		UriProvider uriProvider = new UriProvider();
		public ProductSearchResultModel SearchProducts(ApplicationSettings settings, string search)
		{
			using (var client = new WebClient())
			{
				var json = client.DownloadString(uriProvider.GetSearchUri(search, settings));
				return JsonConvert.DeserializeObject<ProductSearchResultModel>(json);
			}
		}

		public ProductModel GetProduct(int productId, ApplicationSettings settings)
		{
			using (var client = new WebClient())
			{
				var json = client.DownloadString(uriProvider.GetProductUrl(productId, settings));
				var list = JsonConvert.DeserializeObject<IList<ProductModel>>(json);
				return list.Single();
			}
		}
	}
}