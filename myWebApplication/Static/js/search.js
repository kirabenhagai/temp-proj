var enterKeyCode = 13;
$(document).ready(function () {
	var scope = $("#search-box");
	var searchTextbox = scope.find(".search-content-js");
	var searchButton = scope.find(".search-button-js");
	var lastSearches = scope.find(".last-searches-js");
	var searchResults = $(".all-search-result-js");

	setSearchEvents();
	updateSearchHistory();

	function search() {
		var query = scope.find(".search-content-js").val().trim();
		if (query === "")
			return;
		searchResults.html("<h2>Loading...</h2>");
		searchQuery(query, searchQuerySuccess, searchQueryError);
	}

	function searchQuerySuccess(data) {
		searchResults.html(data);
		updateSearchHistory();
	}

	function searchQueryError(err) {
		searchResults.html("Error occured while searching your results.");
	}

	function searchTerm(query) {
		searchTextbox.val(query);
		search();
	}

	function setSearchEvents() {
		searchButton.click(search);
		searchTextbox
			.keyup(function(event) {
				if (event.keyCode === enterKeyCode) {
					search();
				}
			});
	}

	function updateSearchHistory() {
		$.get("/Home/SearchHistory", function (data) {
			lastSearches.html(data);
			lastSearches.find(".search-href").each(function() {
				$(this).on('click', function() { searchTerm($(this.firstChild).text()); });
			});
		});
	}

});
