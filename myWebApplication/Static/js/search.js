var enterKeyCode = 13;
$(document).ready(function () {
	var scope = $("#baseDiv");
	var searchTextbox = scope.find(".search-content");
	var searchButton = scope.find(".search-button-class");
	var lastSearches = scope.find(".last-searches");
	var searchResults = $(".all-search-result");

	setSearchEvents();
	updateSearchHistory();

	function search() {
		var query = scope.find(".search-content").val().trim();
		if (query == "")
			return;
		searchResults.html("<h2>Loading...</h2>");
		var results = $.get("/Home/Search?query=" + encodeURI(query),
			function (data) {
				searchResults.html(data);
				updateSearchHistory();
			}).error(function (err) {
				searchResults.html("Error occured while searching your results.");
			});
	}

	function searchTerm(query) {
		searchTextbox.val(query);
		search();
	}

	function setSearchEvents() {
		searchButton.click(search);
		searchTextbox
			.keyup(function(event) {
				if (event.keyCode == enterKeyCode) {
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
