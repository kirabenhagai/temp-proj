using System.Web.Mvc;
using DataAccess.SearchHistory;
using Domain;

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

		[Route("Home")]
		public ActionResult Home()
		{
			return View();
		}

		[Route("Search")]
		public ActionResult Search(string query)
		{
			var searchModel = _productProvider.SearchProducts(query);
			if (searchModel == null)
				return RedirectToAction("Search", "Home", new { query = "baby" });

			_searchHistoryProvider.AddToHistory(query);

			return PartialView(searchModel);
		}

		[Route("SearchHistory")]
		public ActionResult SearchHistory()
		{
			var searchHistoryResult = _searchHistoryProvider.GetHistory();

			return PartialView(searchHistoryResult);
		}
	}
}