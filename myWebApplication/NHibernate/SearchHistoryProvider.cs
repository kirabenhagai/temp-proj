using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using NHibernate;
using NHibernate.Criterion;

namespace myWebApplication.Domain
{
	public interface ISearchHistoryProvider
	{
		IEnumerable<SearchHistory> GetHistory();
		void AddToHistory(string query);
	}

	public class SearchHistoryProvider : ISearchHistoryProvider
	{
		public IEnumerable<SearchHistory> GetHistory()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var searchHistory =
					session.CreateCriteria<SearchHistory>()
						.AddOrder(Order.Desc("Time"))
						.SetMaxResults(5)
						.List<SearchHistory>()
						.Reverse();
				return searchHistory;
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