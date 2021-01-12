$(document).ready(function () {


    $(".star").click(function () {
        $(".formrating").show();
    })

    $(".submit-cmt-info").click(function () {
        var a = 0;
        $(".checknull").map(function (key, e) {
            if (e.value) {
                a = a + 1;
            }
            return a;
        })
        if (a < 4) {
            $(".popup-cmt-ctsp").show();
        } else { alert("succes") }
    })
    $(".submit-cmt-ctsp").click(function () {
        $(".popup-cmt-ctsp").hide();
    })
    $(window).on('click', function (e) {
        if ($(e.target).is('.popup-cmt-ctsp')) {

            $(".popup-cmt-ctsp").hide()
        }
    })

    $(".bl-vote").click(function () {
        $(".message-thanks").show();
        $(".main-vote-product").hide();
    });
    $(".bl-vote-sad").click(function () {
        $(".dialog2").show();
        $(".main-vote-product").hide();
    })
    $(".Btn-Send").click(function () {
        $(".dialog2").hide();
        $(".message-done").show();
    });

    $(".btnsendrating").click(function () {
        $(".btnsendrating").hide();
        $(".txt-cmt").hide();
        $(".box-chooserate").show();
    });
    $(".star").click(function (e) {
        var onstar = $(e.target).attr("data-index");
        var stars = $(e.target).parent().children();
        for (var i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass("bhx-stargolden");
            $(stars[i]).addClass("bhx-starblack");
        }
        for (var i = 0; i < onstar; i++) {
            $(stars[i]).addClass("bhx-stargolden");
            $(stars[i]).removeClass("bhx-starblack");
        }


    });
});