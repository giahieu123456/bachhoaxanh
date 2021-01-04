$(document).ready(function () {
	$(".img-feedback").click(function () {
		$(".popup-cmt").show()
	})

	$(".close-cmt").click(function () {
		$(".popup-cmt").hide()
	})
	$(window).on('click', function (e) {
		if ($(e.target).is('.popup-cmt')) {

			$(".popup-cmt").hide()
		}
		if ($(e.target).is('.popup-soldout')) {

			$(".popup-soldout").hide()
		}
		if ($(e.target).is('.popup-delete')) {

			$(".popup-delete").hide()
		}
	})
})
