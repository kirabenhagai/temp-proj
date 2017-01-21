using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;

namespace myWebApplication.Domain
{
	public interface ISearchHistoryProvider
	{
		SearchHistoryList GetHistory();
		void AddToHistory(string query);
	}

	public class SearchHistoryProvider : ISearchHistoryProvider
	{
		public SearchHistoryList GetHistory()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var searchHistory =
					session.CreateCriteria<SearchHistory>()
						.AddOrder(Order.Desc("Time"))
						.SetMaxResults(5)
						.List<SearchHistory>()
						.Reverse();
				return new SearchHistoryList(searchHistory);
			}
		}

		public void AddToHistory(string query)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				using (ITransaction trans = session.BeginTransaction())
				{
					var histories = session.CreateCriteria(typeof(SearchHistory))
						.Add(Restrictions.Eq("SearchTerm", query))
						.List<SearchHistory>();
					foreach (SearchHistory s in histories)
						session.Delete(s);

					var searchHistory = new SearchHistory() {SearchTerm = query, Time = DateTime.Now};
					session.SaveOrUpdate(searchHistory);
					trans.Commit();
				}
			}
		}
	}
}