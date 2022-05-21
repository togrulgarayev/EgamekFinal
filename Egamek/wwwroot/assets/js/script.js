// Game Carousel
$(document).ready(function (){
    $('.game-carousel').owlCarousel({
        loop:true,
        nav:true,
        dots:false,
        margin:10,
        autoplay:true,
        autoplayTimeout:3500,
        autoplayHoverPause:true,
        responsiveClass:true,
        responsive:{
            0:{
                items:1,
                nav:true
            },
            400:{
                items:1,
                nav:true
            },
            770:{
                items:2,
                nav:true
            },
            1000:{
                items:3,
                nav:true,
                loop:true
            },
            1300:{
                items:4,
                nav:true,
                loop:true
            }
        }
    });
})
// Game Carousel - End
