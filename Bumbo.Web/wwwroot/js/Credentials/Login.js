function readUrl() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    if (urlParams.has('ReturnUrl')) {
        document.getElementById('form-login-returnurl').value = urlParams.get('ReturnUrl');
    }
    else {
        document.getElementById('form-login-returnurl').value = "/";
    }
};

function togglePassword() {
    var eyeIcon = document.getElementById("toggle-password");
    var passwordField = document.getElementById("form-login-wachtwoord");
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
