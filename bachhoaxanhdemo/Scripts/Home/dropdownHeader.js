$(document).ready(function () {
    $(".nav-parent").click(function (e) {
        $(".nav-parent").not(e.target).next().hide();
        $(e.target).next().toggle();
    })
});