using System.Collections.Generic;
using DataAccess.ResultsFetcher;
using Domain;

namespace DataAccess.SearchHistory
{
	public class ProductProvider : IProductProvider
	{
		private readonly IResultsFetcher _fetcher;
		private readonly IApplicationSettings _settings;

		public ProductProvider(IResultsFetcher fetcher, IApplicationSettings settings)
		{
			_fetcher = fetcher;
			_settings = settings;
		}

		public IList<ProductModel> SearchProducts(string search)
		{
			var emptyResults = new List<ProductModel>();
			if (string.IsNullOrEmpty(search))
				return emptyResults;

			var results = _fetcher.Fetch(search);
			if (results == null)
				return emptyResults;

			foreach (var p in results)
			{
				p.ProductUrl = _settings.ProductUrlPrefix + p.ProductUrl;
			}
			return results;
		}
	}
}
