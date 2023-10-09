// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Toggle Password Attribute
const togglePassword = document.querySelector('#togglePassword');
const password = document.querySelector('#password');

togglePassword.addEventListener('click', () => {
    const type = password
        .getAttribute('type') === 'password' ?
        'text' : 'password';
    password.setAttribute('type', type);
});

// Toggle eye-class
function toggleEye(togglePassword) {
    var className = togglePassword.getAttribute("class");
    if (className == "bi bi-eye-slash position-absolute top-50 end-0 px-2") {
        togglePassword.className = "bi bi-eye position-absolute top-50 end-0 px-2";
    }
    else {
        togglePassword.className = "bi bi-eye-slash position-absolute top-50 end-0 px-2";
    }
}