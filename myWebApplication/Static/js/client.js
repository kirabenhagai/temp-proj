function searchQuery(query, success, error) {
	$.get("/Home/Search?query=" + encodeURI(query), success).error(error);
}
