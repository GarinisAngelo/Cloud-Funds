// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const scrollPositions = {
    'multi-carousel1': 0,
    'multi-carousel2': 0
}

function data(id) {
    const multiCarousel = document.querySelector(`#${id}`);
    const carouselInner = multiCarousel.querySelector('.carousel-inner');
    const item = carouselInner.querySelector('.carousel-item');

    const itemWidth = item.scrollWidth;
    const carouselWidth = multiCarousel.scrollWidth;

    return {
        carouselInner: carouselInner,
        itemWidth: itemWidth,
        carouselWidth: carouselWidth
    };
}

function scroll(carouselInner, distance) {
    carouselInner.scroll({
        left: distance,
        top: 0,
        behavior: "smooth",
    });
}


function next(id) {
    const { carouselInner, itemWidth, carouselWidth } = data(id);

    if (scrollPositions[id] < carouselWidth) scrollPositions[id] += itemWidth;
    else scrollPositions[id] = 0;

    scroll(carouselInner, scrollPositions[id]);
}

function previous(id) {
    const { carouselInner, itemWidth, carouselWidth } = data(id);

    if (scrollPositions[id] > 0) scrollPositions[id] -= itemWidth;
    else scrollPositions[id] = carouselWidth;

    scroll(carouselInner, scrollPositions[id]);
}