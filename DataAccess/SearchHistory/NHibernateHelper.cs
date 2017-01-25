using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace DataAccess.SearchHistory
{
	public static class NHibernateHelper
	{
		private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory != null)
					return _sessionFactory;

				var configuration = new Configuration();
				configuration.Configure();
				var mapper = new ModelMapper();
				mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
				var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
				configuration.AddMapping(mapping);
				_sessionFactory = configuration.BuildSessionFactory();
				return _sessionFactory;
			}
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}