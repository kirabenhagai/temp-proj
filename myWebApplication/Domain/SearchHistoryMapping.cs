using NHibernate.Mapping.ByCode.Conformist;

namespace myWebApplication.Domain
{
	public class SearchHistoryMapping : ClassMapping<SearchHistory>
	{
			public SearchHistoryMapping()
			{
				this.Table("search_history");
				this.Id(p => p.Id, map => map.Column("id"));
				this.Property(p => p.Time, map => map.Column("time"));
				this.Property(p => p.SearchTerm, map => map.Column("search_term"));
			}
	}
}