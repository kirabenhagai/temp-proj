using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
	public interface IUriProvider
	{
		Uri GetSearchUri(string search);
	}

	public class UriProvider : IUriProvider
	{
		private readonly IApplicationSettings _settings;

		public UriProvider(IApplicationSettings settings)
		{
			this._settings = settings;
		}

		public Uri GetSearchUri(string search)
		{
			return new Uri($"{_settings.SearchApiUrl}?q={search}&limit=20&token={_settings.AppToken}&hash={_settings.AppHash}");
		}
	}
}
