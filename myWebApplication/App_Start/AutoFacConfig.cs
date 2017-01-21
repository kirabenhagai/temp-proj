using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using myWebApplication.Configurations;
using myWebApplication.Domain;

namespace myWebApplication
{
	public class AutoFacConfig
	{
		public static void RegisterAutoFac()
		{
			var builder = new ContainerBuilder();

			// Register your MVC controllers. (MvcApplication is the name of
			// the class in Global.asax.)
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// OPTIONAL: Register model binders that require DI.
			builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
			builder.RegisterModelBinderProvider();

			// OPTIONAL: Register web abstractions like HttpContextBase.
			builder.RegisterModule<AutofacWebTypesModule>();

			// OPTIONAL: Enable property injection in view pages.
			builder.RegisterSource(new ViewRegistrationSource());

			// OPTIONAL: Enable property injection into action filters.
			builder.RegisterFilterProvider();

			RegisterComponents(builder);

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


		}

		private static void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterType<UriProvider>().As<IUriProvider>().InstancePerRequest();
			builder.RegisterType<SearchHistoryProvider>().As<ISearchHistoryProvider>().InstancePerRequest();
			builder.RegisterType<ProductProvider>().As<IProductProvider>().InstancePerRequest();
			builder.RegisterType<ApplicationSettings>().As<IApplicationSettings>().InstancePerRequest();
		}
	}
}