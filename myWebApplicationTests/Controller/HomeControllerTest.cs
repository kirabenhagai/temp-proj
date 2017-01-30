using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.SearchHistory;
using Domain;
using myWebApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace myWebApplicationTests.Controller
{
	[TestClass]
	public class HomeControllerTest
	{
		private readonly Mock<IProductProvider> _productProvider = new Mock<IProductProvider>();
		private readonly Mock<ISearchHistoryProvider> _searchHistoryProvider = new Mock<ISearchHistoryProvider>();
		private readonly Mock<IApplicationSettings> _applicationSettings = new Mock<IApplicationSettings>();
		private HomeController _target;

		[TestInitialize]
		public void Setup()
		{
			_target = new HomeController(_productProvider.Object, _searchHistoryProvider.Object, _applicationSettings.Object);
		}

		[TestMethod]
		public void Home_WhenHomeRoute_RetutnsViewResult()
		{
			var result = _target.Home();

			Assert.IsInstanceOfType(result, typeof(ViewResult));
			Assert.IsNull((result as ViewResult).Model);
		}

		[TestMethod]
		public void Search_WhenSearchQuery_PassResultsFromProductsProviderToView()
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
			_productProvider.Setup(p => p.SearchProducts("myquery")).Returns(products);

			var result = _target.Search("myquery");

			_productProvider.Verify(p => p.SearchProducts("myquery"), Times.Once());
			_searchHistoryProvider.Verify(s => s.AddToHistory("myquery"), Times.Once);

			Assert.IsInstanceOfType(result, typeof(PartialViewResult));
			var data = (IList<ProductModel>)((PartialViewResult)result).Model;
			Assert.AreSame(products, data);
		}

		[TestMethod] 
		public void Search_WhenNoResults_RedirectToHome()
		{
			_productProvider.Setup(p => p.SearchProducts("myquery")).Returns((IList<ProductModel>) null);

			var result = _target.Search("myquery") as RedirectToRouteResult;

			_productProvider.Verify(p => p.SearchProducts("myquery"), Times.Once());
			_searchHistoryProvider.Verify(s => s.AddToHistory("myquery"), Times.Never);
			Assert.IsNotNull(result);
			Assert.AreEqual("Search", result.RouteValues["action"].ToString());
			Assert.AreEqual("Home", result.RouteValues["controller"].ToString());
		}

		[TestMethod]
		public void SearchHistory_WhenPressOnHostory_PassResultsFromHistoryProviderToView()
		{
			var histories = new List<SearchHistoryDto>()
			{
				new SearchHistoryDto() {Id=1, Time = DateTime.MinValue, SearchTerm = "Supox"},
				new SearchHistoryDto() {Id=2, Time = DateTime.MinValue, SearchTerm = "Tula" }
			};
			_searchHistoryProvider.Setup(h => h.GetHistory()).Returns(histories);

			var result = _target.SearchHistory();

			_searchHistoryProvider.Verify(s => s.GetHistory(), Times.Once);
			Assert.IsInstanceOfType(result, typeof(PartialViewResult));
			var data = (IList<SearchHistoryDto>)((PartialViewResult)result).Model;
			Assert.AreSame(histories, data);
		}
	}
}
