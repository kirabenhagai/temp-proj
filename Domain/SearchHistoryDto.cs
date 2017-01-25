using System;

namespace Domain
{
	public class SearchHistoryDto
	{
		public virtual long Id { get; set; }
		public virtual DateTime Time { get; set; }
		public virtual string SearchTerm { get; set; }
	}
}
