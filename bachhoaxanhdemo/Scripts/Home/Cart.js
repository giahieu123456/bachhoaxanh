$(document).ready(function () {
	$(".noselect-minus").click(function (e) {
		var x = $(e.target).parent().find("input");
		var total = Number(x.val());
		if (total < 2) {
			$(e.target).parent().parent().find("a:nth-child(2)");
			$(".noselect-minus").addClass("blurred")
		} else {
			x.val(total - 1);
		}
	});
	$(".delete")   
})