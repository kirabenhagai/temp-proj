using System.Collections.Generic;
using System.ComponentModel;
using Domain;

namespace DataAccess
{
	internal class ProductSearchResultModel
	{
		public long Count { get; set; }
		public IList<ProductModel> Products { get; set; }
	}
}