
var isSlide = document.getElementsByName("IsSlide");

var isFeatured = document.getElementsByName("IsFeatured");

isFeatured[0].addEventListener("change", function () {
    checkAvailablitiesOfPhotos();
})

var visible = true;
isSlide[0].addEventListener("change", function () {
    if (visible) {
        var slidePhoto = document.querySelector(".hide");
        slidePhoto.className = "show form-group";
        alert("Please select vertical photos");
        visible = false;
    } else {
        var slidePhoto = document.querySelector(".show");
        slidePhoto.className = "hide form-group";
        visible = true;
    }
    checkAvailablitiesOfPhotos();
})

function checkAvailablitiesOfPhotos() {
    var submit = document.getElementsByName("submit");
    if (isSlide[0].checked && isFeatured[0].checked) {
        submit[0].setAttribute("disabled", "disabled");
        alert("Select only one : Slide or Featured!");
    }
    else {
        submit[0].removeAttribute("disabled");
    }
}


