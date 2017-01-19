using System.Collections.Generic;
using System.ComponentModel;

namespace myWebApplication.Api.Search
{
	[Description("Single facet")]
	public class FacetModel
	{
		public FacetModel(string key, string description, IList<FacetValueModel> facetValues)
		{
			Key = key;
			Description = description;
			FacetValues = facetValues;
		}

		[Description("Collection of the facet's values returned in the search response ")]
		public IList<FacetValueModel> FacetValues { get; private set; }
		[Description("Facet's description")]
		public string Description { get; private set; }
		[Description("Facet's key. Use this key in the 'filter' parameter of the api")]
		public string Key { get; private set; }
	}
}
