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

    owlCarouselBanner.mouseenter(function () {
     
        prevBtn.addClass('hint');
        nextBtn.addClass('hint');
    })

    owlCarouselBanner.mouseleave(function () {
        prevBtn.removeClass('hint');
        nextBtn.removeClass('hint');
    })

});