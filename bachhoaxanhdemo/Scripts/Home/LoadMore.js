$(function () {

    var loadCount = 1;
    var loading = $("#loading");
    $(document).ready(function () {


        $('.viewmore').click(function (e) {
            
            var page_index = 0;
            $(e.target).prev().children().map(function (item) {
                return page_index = page_index + 1;
            })
            var idcate = $(e.target).prev().attr('data-id')

            var url = "/Home/LoadMoreProduct/";
            $.ajax({
                url: url,
                data: { idcate: idcate, page_index: page_index },
                

                success: function (data) {
                    
                    if (data.length !== 0) {
                        //$(data.ModelString).insertBefore(".cateproduct").find().hide().fadeIn(2000);
                        var a = $(e.target).prev().html();
                        $(e.target).prev().html(a + data.ModelString);
                    }

                    var ajaxModelCount = data.ModelCount;
                    if (ajaxModelCount<4) {
                        $(e.target).hide().fadeOut(2000);
                    }

                },
                error: function (xhr, status, error) {
                    console.log(xhr.responseText);
                    alert("message : \n" +
                        "An error occurred, for more info check the js console" +
                        "\n status : \n" + status + " \n error : \n" + error);
                }
            });

            console.log(page_index)
            console.log(idcate)
        })


    });
});    