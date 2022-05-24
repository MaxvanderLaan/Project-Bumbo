function readUrl() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    if (urlParams.has('email')) {
        document.getElementById('form-verifieren-email').value = urlParams.get('email');
    }
    else {
        document.getElementById('form-verifieren-email').value = "";
    }
    if (urlParams.has('token')) {
        document.getElementById('form-verifieren-token').value = urlParams.get('token');
    }
    else {
        document.getElementById('form-verifieren-token').value = "";
    }
};
