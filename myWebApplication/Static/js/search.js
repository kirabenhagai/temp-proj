var enterKeyCode = 13;
$(document).ready(function () {
	var scope = $("#baseDiv");

	function search() {
		var query = scope.find(".search-content").val();
		if (query == "")
			return;
		var results = $.get("/Home/Search?query=" + encodeURI(query),
			function (data) {
				$('#search-result').html(data);
				updateSearchHistory();
			}).error(function (err) {
				$('#search-result').html("Error occured while searching your results.");
			});
	}

	scope.find(".search-button-class").click(search);
	$("#search-query").on("input", search);
	$("#search-query").keyup(function (event) {
		if (event.keyCode == enterKeyCode) {
			search();
		}
	});

	function updateSearchHistory() {
		$.getJSON("/Home/SearchHistory", function (data) {
			var searches = scope.find(".last-searches");
			searches.empty();
			$.each(data,
				function () {
					$("<option />", {
						val: this.SearchTerm,
						text: this.SearchTerm
					}).appendTo(searches);
				});
		});
	}

	updateSearchHistory();
});
