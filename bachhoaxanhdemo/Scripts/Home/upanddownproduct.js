$(document).ready(function () {
	$(".buy").click(function (e) {
		$(e.target).next().show();
		productId = $(e.target).data("id")
		var url = "/Cart/AddItem/";
	
		$.ajax({
			url: url,
			data: { productId: productId, quantity: 1 },
			success: function () {
				alert("qwew")
            }
	})

	$(".down-ctsp").click(function (e) {
		var x = $(e.target).parent().find("input");
		var total = Number(x.val());
		if (total < 2) {
			$(e.target).parent().parent().find("a:nth-child(2)");
			$(e.target).parent().hide();

		} else {
			x.val(total - 1);
		}
	});
	$(".up-ctsp").click(function (e) {
		var x = $(e.target).parent().find("input");
		var total = Number(x.val());
		if (total >= 1) {
		}
		if (total >= 50) {
			$(".popup-soldout").show();

		} else {
			x.val(total + 1);
			$(".noselect-minus").removeClass("blurred")
		}

	});
	$(".ajs-ok").click(function () {
		$(".popup-soldout").hide();

	})
});
