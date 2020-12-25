$(function () {

    var loadCount = 1;
    var loading = $("#loading");
    $("#loadMore").on("click", function (e) {

        e.preventDefault();

        $(document).on({

            ajaxStart: function () {
                loading.show();
            },
            ajaxStop: function () {
                loading.hide();
            }
        });

        

        loadCount = loadCount + 1;
    });
});    