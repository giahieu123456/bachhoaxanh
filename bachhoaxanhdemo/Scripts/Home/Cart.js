

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
	})
	$(".noselect-plus").click(function (e) {
		var x = $(e.target).parent().find("input");
		var total = Number(x.val());
		if (total > 49) {
			$(".popup-soldout").show()
		} else {
			x.val(total + 1);
			$(".noselect-minus").removeClass("blurred")
		}
	})
	$(".ajs-ok").click(function () {
		$(".popup-soldout").hide()
    })
	
	$(".txtorder").click(function (e) {
		$(e.target).parent().addClass("color-border")
		$(".txtorder").not(e.target).parent().removeClass("color-border")
		$(e.target).next().show().focus()
		$(e.target).addClass("name-order-after").removeClass("name-order-befor")
		x = $(".txtorder").not(e.target);
		console.log(x)
		$(x).map(function (index, item) {
			if ($(item).next().val().length == 0) {
				$(item).next().hide();
				$(item).removeClass("name-order-after").addClass("name-order-befor")
            }
		})                
	})
	$(window).on('click', function (e) {
		if ($(e.target).is('.main-cart')) {
			$(".txt").removeClass("color-border")
			$(".ip").each(function () {
				if (this.value.length == 0) {
					$(this).hide();	
					$(this).prev().removeClass("name-order-after", 1000).addClass("name-order-befor");
				}
            })
			
		}		
	})
	$(".IsCallOthers").click(function () {
		$(".receiver").toggle();
	})
	$(".adressrow-left ").click(function () {
		$(".group-city").slideToggle("slow");
    })
	$(".seargh-city").keydown(function () {
		input = $(".seargh-city").val().toUpperCase();
		if (!input) {
			$(".chosse-a-city").parent().show();
		} else {
			$(".chosse-a-city").map(function (i, item) {
				if ($(item).text().toUpperCase().indexOf(input) > -1) {
					$(item).parent().show();
				} else {
					$(item).parent().hide();
                }
            })   
        }
	})
	
	$(".chosse-a-city").click(function (e) {
		x = $(e.target).text()
		$(".city").text(x);
		$(".group-city").hide();
	})

	
	$(".time-receive").click(function () {
		$(".datetime-receive").map(function (i, item) {
			$(item).text()
		})
	})
	$(".span-delivery-time").click(function (e) {
		$(e.target).next().slideToggle()
	})
	$(".datetime-receive").click(function (e) {
		$(e.target).parent().slideUp()
		$(e.target).parent().prev().text($(e.target).text())
	})
	$(".clear-all").click(function () {
		$(".popup-clear-cart").show()
	})
	$(".ajs-no").click(function () {
		$(".popup-clear-cart").hide()
	})
	$(".btn-step").click(function () {
		$(".order-cart").show()
		$(".content-cart").hide()		
	})
	$(".backstep").click(function () {
		$(".order-cart").hide()
		$(".content-cart").show()
	})
	$
	$(".confirm-order").click(function () {
		$(".check-null-order").map(function (i, item) {
			if ($(item).text =="" || $(item).val() == "") {
				alert("rtr")
			} else {
				alert("sadsakhdkjsa")
			}
		})	
	})
	var dt = new Date();
	var time = dt.getHours()
	
	if (time > 17) {
		$(".check-day").text("Ngày mai")
		$(".check-hour").text("08h - 12h-Phí: 15.000 ")
	}
})