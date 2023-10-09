// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// GetFullYear by JS
const year = document.getElementById("year");
year.innerHTML = new Date().getFullYear();

// Toggle Password Attribute
const togglePassword = document.querySelector('#togglePassword');
const password = document.querySelector('#password');

togglePassword.addEventListener('click', () => {
    var className = togglePassword.getAttribute("class");
    if (className == "bi bi-eye-slash position-absolute top-50 end-0 pe-2") {
        togglePassword.className = "bi bi-eye position-absolute top-50 end-0 pe-2";
    }
    else if (className == "bi bi-eye position-absolute top-50 end-0 pe-2") {
        togglePassword.className = "bi bi-eye-slash position-absolute top-50 end-0 pe-2";
    }

    const type = password
        .getAttribute('type') === 'password' ?
        'text' : 'password';
    password.setAttribute('type', type);
});