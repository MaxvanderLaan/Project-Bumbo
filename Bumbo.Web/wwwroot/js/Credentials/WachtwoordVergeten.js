function readUrl() {
    const urlProtocol = window.location.protocol;
    const urlHostname = window.location.hostname;
    let urlPort = window.location.port;
    if (urlPort) {
        document.getElementById('form-wachtwoordvergeten-url').value = urlProtocol + urlHostname + ":" + urlPort.toString();
    }
    else {
        document.getElementById('form-wachtwoordvergeten-url').value = "";
    }
};
