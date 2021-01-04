$(document).ready(function () {
    $(".nav-parent").click(function (e) {
        $(".nav-parent").not(e.target).next().hide(300);
        $(e.target).next().toggle(300);
    })
});