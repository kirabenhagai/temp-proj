using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWebApplication.Configurations
{
	public interface IApplicationSettings
	{
		long AppId { get; }
		string AppToken { get; }
		string AppHash { get; }
		Uri SecureApiUrl { get;}
	}
}