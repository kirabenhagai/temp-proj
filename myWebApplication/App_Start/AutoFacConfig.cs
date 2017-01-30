using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace myWebApplication
{
	public class AutoFacConfig
	{
		public static void RegisterAutoFac()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			RegisterComponents(builder);

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}

		private static void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("Domain")).InstancePerLifetimeScope().AsImplementedInterfaces();
			builder.RegisterAssemblyTypes(Assembly.Load("DataAccess")).InstancePerLifetimeScope().AsImplementedInterfaces();
			builder.RegisterAssemblyTypes(Assembly.Load("myWebApplication")).InstancePerLifetimeScope().AsImplementedInterfaces();
			builder.RegisterControllers(Assembly.Load("myWebApplication"));
		}
	}
}