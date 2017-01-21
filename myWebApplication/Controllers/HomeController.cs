using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using myWebApplication.Configurations;
using System.Net;
using Newtonsoft.Json;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;
using myWebApplication.Domain;
using myWebApplication.Models;

namespace myWebApplication.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductProvider _productProvider;
		private readonly ISearchHistoryProvider _searchHistoryProvider;
		private readonly IApplicationSettings _applicationSettings;

		public HomeController(IProductProvider productProvider, ISearchHistoryProvider searchHistoryProvider, IApplicationSettings applicationSettings)
		{
			_productProvider = productProvider;
			_searchHistoryProvider = searchHistoryProvider;
			_applicationSettings = applicationSettings;
		}

		[Route("Index")]
		public ActionResult Index()
		{
			return View();
		}

		[Route("Search")]
		public ActionResult Search(string query)
		{
			var searchModel = _productProvider.SearchProducts(_applicationSettings, query);
			if (searchModel == null)
				return RedirectToAction("Search", "Home", new { query = "baby" });

			_searchHistoryProvider.AddToHistory(query);

			return PartialView(searchModel.Products);
		}

		[Route("SearchHistory")]
		public ActionResult SearchHistory()
		{
			var searchHistoryResult = _searchHistoryProvider.GetHistory();

			return PartialView(searchHistoryResult.Histories);
		}
	}
}