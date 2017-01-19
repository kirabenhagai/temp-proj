using System.Collections.Generic;

namespace myWebApplication.Domain
{
	public class SearchHistoryList
	{
		public SearchHistoryList(IEnumerable<SearchHistory> histories)
		{
			this.Histories = histories;
		}
		public IEnumerable<SearchHistory> Histories { get; set; }
	}
}