$(document).ready(function () {
    $(".nav-parent").click(function (e) {
        $(".nav-parent").not(e.target).removeClass("nav-parent-open").next().hide(300);
        $(e.target).toggleClass("nav-parent-open").next().toggle(300);
    })
  
   
});