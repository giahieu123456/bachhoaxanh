$(".buy").click(function (e) {
	$(e.target).next().show();

})

$(".minus").click(function (e) {
	var x = $(e.target).parent().find("input");
	var total = Number(x.val());
	if (total < 2) {
		$(e.target).parent().parent().find("a:nth-child(2)");
		$(e.target).parent().hide();

	} else {
		x.val(total - 1);

	}
});
$(".plus").click(function (e) {
	var x = $(e.target).parent().find("input");

	var total = Number(x.val());
	if (total >= 1) {
	}
	if (total >= 50) {
		$(".popup-soldout").show();

	} else {
		x.val(total + 1);
	}

});
$(".ajs-ok").click(function () {
	$(".popup-soldout").hide();

})