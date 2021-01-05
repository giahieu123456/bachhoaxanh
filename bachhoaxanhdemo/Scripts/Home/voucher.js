$(".card").click(function () {
	$(".popup-voucher").show()
})
$(".close").click(function () {
	$(".popup-voucher").hide()
})
$(window).on('click', function (e) {
	if ($(e.target).is('.popup-voucher')) {

		$(".popup-voucher").hide()
	}
})



$(".radio-vlaue").click(function () {

	$(".main-voucher-step2").show();
	$(".main-voucher-step3").show();
	y = parseInt($('input[name="radio-total"]:checked').val());
	x = parseInt($(".qty-input").val());
	$(".pay-total").text(x * y);
})
$(".down").click(function () {
	var x = $(".qty-input").val();
	var total = Number(x);
	if (total < 2) {
		$(".down").addClass("blurred")

	} else {
		$(".up").removeClass("blurred")
		$(".qty-input").val(total - 1);
	}
	y = parseInt($('input[name="radio-total"]:checked').val());
	x = parseInt($(".qty-input").val());
	$(".pay-total").text(x * y);
})

$(".up").click(function () {
	var x = $(".qty-input").val();
	var total = Number(x);
	if (total >= 1) {
		$(".down").removeClass("blurred")
	}
	if (total >= 100) {
		$(".up").addClass("blurred")
	} else {
		$(".qty-input").val(total + 1);
	}
	y = parseInt($('input[name="radio-total"]:checked').val());
	x = parseInt($(".qty-input").val());
	$(".pay-total").text(x * y);

})