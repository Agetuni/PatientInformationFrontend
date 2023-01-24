// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function moveRight(leftValue, rightValue) {
    var leftSelect = document.forms["add_patient"].elements[leftValue];
    var rightSelect = document.forms["add_patient"].elements[rightValue];
    if (leftSelect.selectedIndex == -1) {
        window.alert("You must first select an item on the left side.")
    } else {
        var option = leftSelect.options[leftSelect.selectedIndex];
        rightSelect.appendChild(option);
    }
}