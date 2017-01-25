using Domain;
using NHibernate.Mapping.ByCode.Conformist;

namespace DataAccess.SearchHistory
{
	public class SearchHistoryMapping : ClassMapping<SearchHistoryDto>
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