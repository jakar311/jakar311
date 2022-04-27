const buttonGallery = document.querySelector(".clickerContent");
const buttonGallery2 = document.querySelector(".clickerContent2");
const slideGallery = document.querySelector(".sliding");
const slideGallery2 = document.querySelector(".sliding2");
const closeSliders = document.querySelector("section.content");
let btn = $('.btn');

buttonGallery.addEventListener('click', function () {
    slideGallery.classList.toggle('opacity');
});

buttonGallery2.addEventListener('click', function () {
    slideGallery2.classList.toggle('opacityMobile');
});

btn.on('click', function () {
    $(this).toggleClass('clicked');
    $(this).toggleClass('active');
    $(this).toggleClass('not-active');
    $('.wrapperMobile').toggleClass('blur');
    $('.content').toggleClass('blur');
    $('.box').toggleClass('clicked');
    $('.background').toggleClass('not-active');
    if ($('.sliding2').has('opacityMobile')) {
        $('.sliding2').removeClass('opacityMobile');
    }
});