function createXHR() {
    // a memoizing XMLHttpRequest factory. 
    var xhr;
    var factories = [
                    function () { return new XMLHttpRequest(); },
                    function () { return new ActiveXObject("Msxml2.XMLHTTP"); },
                    function () { return new ActiveXObject("Msxml3.XMLHTTP"); },
                    function () { return new ActiveXObject("Microsoft.XMLHTTP"); } ];
    for (var i = 0; i < factories.length; i++) {
        try {
            xhr = factories[i]();
            // memoize the factory so we don't have to look for it again. 
            createXHR = factories[i];
            return xhr;
        } catch (e) { }
    }
}

function isLoggedIn() {
    var xhr = createXHR();
    xhr.open("POST", "/Authentication_JSON_AppService.axd/IsLoggedIn", true);
    xhr.onreadystatechange = function () {
        if (this.readyState === 4) {
            if (this.status != 200) {
                alert(xhr.statusText);
            } else {
                alert("IsLoggedIn = " + xhr.responseText);
            }
            xhr = null;
        }
    };
    xhr.setRequestHeader("content-type", "application/json");
    xhr.send(null);
}

function loginUser() {
    var username = "billdad";
    var password = "shuhite";
    Sys.Services.AuthenticationService.login(username, password, false, null, null, onLoginCallCompleted, null, username);
}
