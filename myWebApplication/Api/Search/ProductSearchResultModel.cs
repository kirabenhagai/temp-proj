using System.Collections.Generic;
using System.ComponentModel;
using myWebApplication.Api.Products;

namespace myWebApplication.Api.Search
{
	public class ProductSearchResultModel
	{
		[Description("Total products count")]
		public long Count { get; set; }
		[Description("Products matching the search request")]
		public IList<ProductModel> Products { get; set; }
	}
}