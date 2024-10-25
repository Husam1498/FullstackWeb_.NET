// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


"use strict";
const addEventOnElements = function (elements, eventType, callback) {
    for (let i = 0, len = elements.length; i < len; i++) {
        elements[i].addEventListener(eventType, callback);
    }
};

/** mobile navbar tooggle */

const navbar = document.querySelector("[data-navbar]");
const navTogglers = document.querySelectorAll("[data-nav-toggler]");
//const myDiv = document.getElementById('myDiv');
//const links = myDiv.getElementsByTagName('a');
//if (links.length > 6) {
//    navbar.classList.toggle("actives");
/*}*/

const toggleNav = () => {
    navbar.classList.toggle("actives");
};

addEventOnElements(navTogglers, "click", toggleNav);

/* Filtre buttonları */
/* Fiyatbtn*/
const btn_filtre = document.querySelectorAll("[filtre-button]");
const btn_filtreDiv = document.querySelector("[filtre-Div]");
const btn_filtreBtn = document.querySelector("[btn-filtre]");

const toggleNav2 = () => {
    btn_filtreDiv.classList.toggle("actives");
    btn_filtreBtn.classList.toggle("actives");

};
addEventOnElements(btn_filtre, "click", toggleNav2);

const btn_filtre_categori = document.querySelectorAll("[filtre-button-categori]");
const btn_filtreDiv_catgeori = document.querySelector("[filtre-Div-Categori]");
const btn_filtreBtn_categori = document.querySelector("[btn-filtre-categori]");

const toggleNav3 = () => {
    btn_filtreDiv_catgeori.classList.toggle("actives");
    btn_filtreBtn_categori.classList.toggle("actives");

};
addEventOnElements(btn_filtre_categori, "click", toggleNav3);




/* header anmation */
const header = document.querySelector("[data-header]");
const bacTopBtn = document.querySelector("[data-back-top-btn]");
window.addEventListener("scroll", () => {
    if (window.scrollY > 80) {
        header.classList.add("actives");
        bacTopBtn.classList.add("actives");
    } else {
        header.classList.remove("actives");
        bacTopBtn.classList.remove("actives");
    }
});

/** SLider items toopics*/

const slider = document.querySelector("[data-slider]");
const sliderContainer = document.querySelector("[data-slider-container]");
const sliderPrevBtn = document.querySelector("[data-slider-prev]");
const sliderNextBtn = document.querySelector("[data-slider-next]");

let totalSliderVisibleItems = Number(
    getComputedStyle(slider).getPropertyValue("--slider-items")
);

let totalSlidableItems =
    sliderContainer.childElementCount - totalSliderVisibleItems;

let currentSlidePos = 0;

const moveSliderItem = function () {
    sliderContainer.style.transform = `translateX(-${sliderContainer.children[currentSlidePos].offsetLeft - 20}px)`;
};

/** NEXT SLider */
const slideNext = function () {
    const slideEnd = currentSlidePos >= totalSlidableItems;
    if (slideEnd) {
        currentSlidePos = 0;
    } else {
        currentSlidePos++;
    }
    moveSliderItem();
};
sliderNextBtn.addEventListener("click", slideNext);

/** Previous SLider */
const slidePrev = function () {
    if (currentSlidePos <= 0) {
        currentSlidePos = totalSlidableItems;
    } else {
        currentSlidePos--;
    }
    moveSliderItem();
};
sliderPrevBtn.addEventListener("click", slidePrev);

/*responsive*/
window.addEventListener("resize", function () {
    totalSliderVisibleItems = Number(
        getComputedStyle(slider).getPropertyValue("--slider-items")
    );

    totalSlidableItems =
        sliderContainer.childElementCount - totalSliderVisibleItems;
    moveSliderItem();
});


/* filtre buttonları için*/




/* PRODUCT DETAİLS İMG */

//const image = document.getElementById('productId');
//const btnn = document.getElementsByClassName('btnn');



