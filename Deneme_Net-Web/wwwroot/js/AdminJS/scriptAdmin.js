let link = document.querySelectorAll(".link");


function activeLink() {
    link.forEach((element) => {
        element.classList.remove("hovered");
    });
    this.classList.add("hovered");
}
link.forEach((item) => item.addEventListener("click", activeLink));


let adminProfile = document.querySelector("[adminProfile]");
let silinen = document.querySelector("[adminProfileSil]");

adminProfile.addEventListener("click", function () {
    silinen.classList.remove("hovered"); 
});

/*Menu toggle */
let toggle = document.querySelector(".toggle");
let navigation = document.querySelector(".navigation");
let main = document.querySelector(".main");

toggle.onclick = function () {
    navigation.classList.toggle("active");
    main.classList.toggle("active");
};
