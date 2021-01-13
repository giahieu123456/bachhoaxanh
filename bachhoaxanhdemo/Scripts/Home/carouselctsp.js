$('.owl-carousel').owlCarousel({
    margin: 10,
    slideSpeed: 300,
    nav: true,
    navText: ["<", ">"],
    lazyLoad: true,
    paginationSpeed: 400,
    loop: true,
    autoplay: true,
   
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 5
        }
    }
});
