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
		public ApplicationSettings applicationSettings = new ApplicationSettings();
		public ProductProvider ProductProvider = new ProductProvider();
		public ProductSearchResultModel ProductSearchResultModel { get; set; }

		[Route("Index")]
		public ActionResult Index()
		{
			return View();
		}

		[Route("Search")]
		public ActionResult Search(string query)
		{
			var searchModel = ProductProvider.SearchProducts(applicationSettings, query);
			if (searchModel == null)
				return RedirectToAction("Search", "Home", new { query = "baby" });

			var searchHistoryProvider = new SearchHistoryProvider();

			searchHistoryProvider.AddToHistory(query);

			return PartialView(searchModel.Products);
		}

		[Route("SearchHistory")]
		public ActionResult SearchHistory()
		{
			var searchHistoryProvider = new SearchHistoryProvider();

			var searchHistoryResult = searchHistoryProvider.GetHistory();

			return PartialView(searchHistoryResult.Histories);
		}
	}
}