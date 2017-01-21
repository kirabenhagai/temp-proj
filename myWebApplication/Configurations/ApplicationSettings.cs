using System;

namespace myWebApplication.Configurations
{
	public interface IApplicationSettings
	{
		long AppId { get; }
		string AppToken { get; }
		string AppHash { get; }
		Uri SearchApiUrl { get; }
		Uri GetProductUrl { get; }
		Uri ProductUrlPrefix { get; }
	}

	public class ApplicationSettings : IApplicationSettings
	{
		public long AppId => 19825L;
		public string AppToken => "0_19825_253402300799_1_9ecca97e6231ff71ccd62bbafbf2a9f9c924e17229a0a38c0417c74ef02bec2f";
		public string AppHash => "7f54692fbc3174304383983dd056466a9ab2f3c9efe9a9de8030a07f09a401ce";
		public Uri SearchApiUrl => new Uri("https://platform.shopyourway.com/products/search");
		public Uri GetProductUrl => new Uri("https://platform.shopyourway.com/products/get");
		public Uri ProductUrlPrefix => new Uri("https://shopyourway.com");
	}
}
