using System.Collections.Generic;

namespace Domain
{
	public interface IResultsFetcher
	{
		IList<ProductModel> Fetch(string search);
	}

}
