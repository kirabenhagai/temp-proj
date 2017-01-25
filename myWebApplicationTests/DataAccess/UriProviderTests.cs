using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ResultsFetcher;
using DataAccess.SearchHistory;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace myWebApplicationTests.DataAccess
{
	[TestClass]
	public class UriProviderTests
	{
		private readonly Mock<IApplicationSettings> _applicationSettings = new Mock<IApplicationSettings>();
		private IUriProvider _target;

		[TestInitialize]
		public void Setup()
		{
			_target = new UriProvider(_applicationSettings.Object);
		}

		[TestMethod]
		public void TestGetSearchUri_OnSearch_ShouldReturnTheRightUri()
		{
			_applicationSettings.Setup(p => p.AppToken).Returns("token");
			_applicationSettings.Setup(p => p.AppHash).Returns("hash");
			_applicationSettings.Setup(p => p.SearchApiUrl).Returns(new Uri("http://sears.com/searchApi"));
			
			var uri = _target.GetSearchUri("MyUri");

			Assert.AreEqual(new Uri("http://sears.com/searchApi?q=MyUri&limit=20&token=token&hash=hash"), uri);
		}



	}
}
