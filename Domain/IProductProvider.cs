using System.Collections.Generic;

namespace Domain
{
	public interface IProductProvider
	{
		IList<ProductModel> SearchProducts(string search);
	}
}
