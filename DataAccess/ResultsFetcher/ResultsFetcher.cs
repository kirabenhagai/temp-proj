using System.Collections.Generic;
using System.Net;
using Domain;
using Newtonsoft.Json;

namespace DataAccess.ResultsFetcher
{
	public class ResultsFetcher : IResultsFetcher
	{
		private readonly IUriProvider _provider;

		public ResultsFetcher(IUriProvider provider)
		{
			_provider = provider;
		}
		public IList<ProductModel> Fetch(string search)
		{
			using (var client = new WebClient())
			{
				var json = client.DownloadString(_provider.GetSearchUri(search));
				var results = JsonConvert.DeserializeObject<ProductSearchResultModel>(json);
				return results?.Products;
			}
		}
	}
}
