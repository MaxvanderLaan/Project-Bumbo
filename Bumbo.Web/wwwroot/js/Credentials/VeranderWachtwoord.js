function readUrl() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    if (urlParams.has('email')) {
        document.getElementById('form-veranderwachtwoord-email').value = urlParams.get('email');
    }
    else {
        document.getElementById('form-veranderwachtwoord-email').value = "";
    }
    if (urlParams.has('token')) {
        document.getElementById('form-veranderwachtwoord-token').value = urlParams.get('token');
    }
    else {
        document.getElementById('form-veranderwachtwoord-token').value = "";
    }
};

function togglePassword() {
    var eyeIcon = document.getElementById("toggle-password");
    var passwordField = document.getElementById("form-veranderwachtwoord-wachtwoord");
    if (eyeIcon.classList.contains('fa-eye')) {
        passwordField.setAttribute("type", "text");
        eyeIcon.classList.remove('fa-eye');
        eyeIcon.classList.add('fa-eye-slash');
    } else {
        passwordField.setAttribute("type", "password");
        eyeIcon.classList.remove('fa-eye-slash');
        eyeIcon.classList.add('fa-eye');
    }
};

function togglePassword2() {
    var eyeIcon = document.getElementById("toggle-password-2");
    var passwordField = document.getElementById("form-veranderwachtwoord-wachtwoord-2");
    if (eyeIcon.classList.contains('fa-eye')) {
        passwordField.setAttribute("type", "text");
        eyeIcon.classList.remove('fa-eye');
        eyeIcon.classList.add('fa-eye-slash');
    } else {
        passwordField.setAttribute("type", "password");
        eyeIcon.classList.remove('fa-eye-slash');
        eyeIcon.classList.add('fa-eye');
    }
};
