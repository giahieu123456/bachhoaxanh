

$(document).ready(function () {
	$(".sb-container").addClass("header-cart")
	$(".sb-container").mouseenter(function () {
		$(".sb-container").removeClass("header-cart")
		$("")
	})
	$(".sb-container").mouseleave(function () {
		$(".sb-container").addClass("header-cart")
	})
	
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
	$(".txtorder").click(function (e) {
		$(e.target).next().show().focus()
		$(e.target).addClass("name-order-after")	
	})
	$(window).on('click', function (e) {
		if ($(e.target).is('.main-cart')) {			
			$(".ip").each(function () {
				if (this.value.length == 0) {
					$(this).hide();	
					$(this).prev().removeClass("name-order-after");
				}
            })
			
		}
		
		
	})
	
	

	
})