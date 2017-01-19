using System.ComponentModel;

namespace myWebApplication.Api.Search
{
	[Description("Single facet's value")]
	public class FacetValueModel
	{
		public FacetValueModel(string key, string description, int count)
		{
			Key = key;
			Description = description;
			Count = count;
		}

		[Description("Number of products filtered by this value")]
		public int Count { get; set; }
		[Description("Facet value's description")]
		public string Description { get; set; }
		[Description("Facet value's key. Use this key as a value in the 'filter' parameter of the api")]
		public string Key { get; set; }
	}
}