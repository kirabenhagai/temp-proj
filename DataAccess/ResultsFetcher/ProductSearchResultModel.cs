using System.Collections.Generic;
using Domain;

namespace DataAccess.ResultsFetcher
{
	internal class ProductSearchResultModel
	{
		public long Count { get; set; }
		public IList<ProductModel> Products { get; set; }
	}
}