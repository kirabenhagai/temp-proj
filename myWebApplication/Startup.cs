using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myWebApplication.Startup))]

namespace myWebApplication
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
		}
	}
}
