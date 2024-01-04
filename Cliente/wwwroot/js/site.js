// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(() => {
    let _menu = $("#menu-app")
    let _userLogin = localStorage.getItem("userlogin")
    if (!_userLogin) {
        _menu.removeClass("form-show").addClass("form-hidden")
        // window.location.href = "/";
    } else _menu.removeClass("form-hidden").addClass("form-show")
})