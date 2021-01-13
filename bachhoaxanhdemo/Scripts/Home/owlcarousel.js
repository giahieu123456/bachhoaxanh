$(document).ready(function () {

    const owlCarouselBanner = $('.owl-carousel');
    const prevBtn = $('.owl-prev');
    const nextBtn = $('.owl-next');

    owlCarouselBanner.owlCarousel({
        items: 1,
        slideSpeed: 300,
        nav: true,
        navText: ["", ""],
        lazyLoad: true,
        paginationSpeed: 400,        
        loop: true,
        autoplay: true,
        dots: true,
    });

    $(".slide-home").mouseenter(function () {
     
        $(".owl-prev").addClass('hint');
        $(".owl-next").addClass('hint');
    })

    $(".slide-home").mouseleave(function () {
        $(".owl-prev").removeClass('hint');
        $(".owl-next").removeClass('hint');
    })

});