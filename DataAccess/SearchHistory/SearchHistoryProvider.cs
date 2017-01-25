using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using NHibernate;
using NHibernate.Criterion;

namespace DataAccess.SearchHistory
{
	public interface ISearchHistoryProvider
	{
		IEnumerable<SearchHistoryDto> GetHistory();
		void AddToHistory(string searchTerm);
	}

	public class SearchHistoryProvider : ISearchHistoryProvider
	{
		public IEnumerable<SearchHistoryDto> GetHistory()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var searchHistory =
					session.CreateCriteria<SearchHistoryDto>()
						.AddOrder(Order.Desc("Time"))
						.SetMaxResults(5)
						.List<SearchHistoryDto>()
						.Reverse();
				return searchHistory;
			}
		}

		public void AddToHistory(string searchTerm)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var histories = session.CreateCriteria(typeof(SearchHistoryDto))
					.Add(Restrictions.Eq("SearchTerm", searchTerm))
					.List<SearchHistoryDto>();
				foreach (SearchHistoryDto s in histories)
					session.Delete(s);

				var searchHistory = new SearchHistoryDto() { SearchTerm = searchTerm, Time = DateTime.Now };
				session.Save(searchHistory);
				session.Flush();
			}
		}
	}
}