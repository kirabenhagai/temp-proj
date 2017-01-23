using Domain;
using NHibernate.Mapping.ByCode.Conformist;

namespace myWebApplication.Domain
{
	public class SearchHistoryMapping : ClassMapping<SearchHistory>
	{
			public SearchHistoryMapping()
			{
				Table("search_history");
				Id(p => p.Id, map => map.Column("id"));
				Property(p => p.Time, map => map.Column("time"));
				Property(p => p.SearchTerm, map => map.Column("search_term"));
			}
	}
}