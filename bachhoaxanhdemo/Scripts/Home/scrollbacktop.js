$(document).ready(function () {
	window.onscroll = function () { scrollFunction() };
	function scrollFunction() {
		if ($(document).scrollTop() > 400) {
			$(".backtop").show();
		} else {
			$(".backtop").hide();
		}
	}
	$(".backtop").click(function () {
		$(document).scrollTop(0);
	});
})