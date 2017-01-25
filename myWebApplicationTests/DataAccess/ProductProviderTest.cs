using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SearchHistory;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace myWebApplicationTests.DataAccess
{
	[TestClass]
	public class ProductProviderTest
	{
		private readonly Mock<IResultsFetcher> _fetcher = new Mock<IResultsFetcher>();
		private readonly Mock<IApplicationSettings> _applicationSettings = new Mock<IApplicationSettings>();
		private IProductProvider _target;

		[TestInitialize]
		public void Setup()
		{
			_target = new ProductProvider(_fetcher.Object, _applicationSettings.Object);
		}

		[TestMethod]
		public void TestSearchProducts_OnNull_ShouldReturnEmptyResults()
		{
			_fetcher.Setup(p => p.Fetch("myquery")).Returns((IList<ProductModel>) null);

			var results = _target.SearchProducts("my_query");

			_fetcher.Verify(p => p.Fetch("my_query"), Times.Once);

			Assert.AreEqual(0, results.Count);
		}

		[TestMethod]
		public void TestSearchProducts_OnResultsFromFetcher_ShouldReturnResults()
		{
			var products = new List<ProductModel>()
			{
				new ProductModel()
				{
					Description = "car",
					ImageUrl = "http://img",
					Name = "BMW",
					Price = 10000,
					ProductUrl = "http://bmw.com"
				}
			};
			_fetcher.Setup(p => p.Fetch("myquery")).Returns(products);

			var results = _target.SearchProducts("myquery");

			_fetcher.Verify(p => p.Fetch("myquery"), Times.Once);

			Assert.AreEqual(products, results);
		}

	}
}
