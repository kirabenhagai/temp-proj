using System;

namespace myWebApplication.Configurations
{
	public class ApplicationSettings : IApplicationSettings
	{
		public long AppId => 21160L;
		public string AppToken => "0_21160_253402300799_1_210320f73b3bb8ff9ba3c8b15e5ff4693161004dee8094535767c6825cbd18fa";
		public string AppHash => "2fa5c29cd3988e6e0a89aecd422493018a315f27f38b2aa6dd0e5ea759a884e4";
		public int Limit => 9;
		public string Description => "description,imageUrl,url";
		public string Types=> "Brand,Store,Clique,Author, Artist, Site,Image,AppWall,Vertical,Category,SubCategory,AutoCreated,Venue,PublicFigure,Partner,Expert,Seller";
		public Uri SecureApiUrl => new Uri("https://sandboxplatform.shopyourway.com/");
		public Uri SearchApiUrl => new Uri("https://sandboxplatform.shopyourway.com/products/search");
		public Uri GetProductUrl => new Uri("https://sandboxplatform.shopyourway.com/products/get");
	}
}
