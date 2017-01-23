using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace myWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			AutoFacConfig.RegisterAutoFac();
        }
    }
}
