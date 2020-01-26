String.prototype.replaceAll = function (s1, s2) { return this.split(s1).join(s2) }
String.prototype.boolean = function () { return "True" == this; };
pTypes = { "pl": "pivotlink", "pp": "pivotpage" };
var userName, pivotName, pcToken;
var baseUrl = "http://" + window.location.host + "/";

$(document).bind("ready", function () {

    jQuery.support.cors = true; setupNavButtons();
    jQuery.validator.addMethod("pcnospace", function (value, element) {
        return value.indexOf(" ") < 0 && value != "";
    }, "Spaces are not allowed");
});

function setupNavButtons() {
    if (isLoggedIn()) {
        $("#acctButton").text("Sign out").click(function () {
            logoutUser();
        });
    }
    else {
        $("#acctButton").text("Sign in").click(function () {
            window.location.href = "pivotcard-signin.aspx";
        });
    }

    $("#navLogo").css("cursor", "pointer").click(function () {
        window.location.href = "home.aspx";
    });
}
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
    var res = false;
    var lcookie = getCookie("login");
    if (lcookie != null) {
        res = true;
        
    }
    return res;
}

function getPca() {
    var pca = "un=" + PivotEncode(userName) + "&tk=" + pcToken;
    return pca;
}

function loginUser(un, token, pers) {
    //Sys.Services.AuthenticationService.login(userName, password, isPersistent, customInfo, redirectUrl, loginCompletedCallback, failedCallback, userContext)
    //Sys.Services.AuthenticationService.login(un, pw, pers, null, "my-pivots.aspx", onLoginCallCompleted, onFailedLoginCallCompleted, un);
    var cookietimeout = "20";
    if (pers) {
        cookietimeout = "525300"
    }
    setCookie('login', un, cookietimeout);
    userName = un;
    setCookie('pcToken', token, cookietimeout);
    pcToken = token;
    window.location.href = "my-pivots.aspx";
//    $.getJSON(baseUrl + 'DataService.svc/checkToken/' + PivotEncode(userName) + '/' + pcToken, null, function () {
//        //window.location.href = "my-pivots.aspx";
//    });
}

function getUserName() {
    //Sys.Services.AuthenticationService.login(userName, password, isPersistent, customInfo, redirectUrl, loginCompletedCallback, failedCallback, userContext)
    return getCookie('login');
}

function logoutUser() {
    //Sys.Services.AuthenticationService.logout(redirectUrl, logoutCompletedCallback, failedCallback, userContext)
    //Sys.Services.AuthenticationService.logout("pivotcard-signin.aspx", null, null, null);
    deleteCookie("login");
    deleteCookie("pcToken");
    window.location.href = "pivotcard-signin.aspx";
}


function getCookie(check_name) {
    // note: document.cookie only returns name=value, not the other components
    var a_all_cookies = document.cookie.split(';');
    var a_temp_cookie = '';
    var cookie_name = '';
    var cookie_value = '';
    var b_cookie_found = false; // set boolean t/f default f
    var i = '';

    for (i = 0; i < a_all_cookies.length; i++) {
        a_temp_cookie = a_all_cookies[i].split('=');

        cookie_name = a_temp_cookie[0].replace(/^\s+|\s+$/g, '');

        if (cookie_name == check_name) {
            b_cookie_found = true;
            // we need to handle case where cookie has no value but exists (no = sign, that is):
            if (a_temp_cookie.length > 1) {
                cookie_value = unescape(a_temp_cookie[1].replace(/^\s+|\s+$/g, ''));
            }
            // in cases where cookie is initialized but no value, null is returned
            return cookie_value;
            break;
        }
        a_temp_cookie = null;
        cookie_name = '';
    }
    if (!b_cookie_found) {
        return null;
    }
}

/*only the first 2 parameters are required, the cookie name, the cookie
value. 

Generally you don't need to worry about domain, path or secure for most applications
so unless you need that, leave those parameters blank in the function call.*/
function setCookie(name, value, expires, path, domain, secure) {
    // set time, it's in milliseconds
    var today = new Date();
    today.setTime(today.getTime());
    // if the expires variable is set, make the correct expires time, the
    // current script below will set it for x number of days, to make it
    // for hours, delete * 24, for minutes, delete * 60 * 24
    if (expires) {
        expires = expires * 1000 * 60;// * 60 * 24;
    }
    var expires_date = new Date(today.getTime() + (expires));
    var newexp = expires_date.toGMTString();
    
    document.cookie = name + "=" + escape(value) +
		((expires) ? ";expires=" + expires_date.toGMTString() : "") + //expires.toGMTString()
		((path) ? ";path=" + path : "") +
		((domain) ? ";domain=" + domain : "") +
		((secure) ? ";secure" : "");
}

// this deletes the cookie when called
function deleteCookie(name, path, domain) {
    if (getCookie(name)) document.cookie = name + "=" +
			((path) ? ";path=" + path : "") +
			((domain) ? ";domain=" + domain : "") +
			";expires=Thu, 01-Jan-1970 00:00:01 GMT";
} 

function getViewportHeight() {
    if (window.innerHeight != window.undefined) return window.innerHeight;
    if (document.compatMode == 'CSS1Compat') return document.documentElement.clientHeight;
    if (document.body) return document.body.clientHeight;
    return window.undefined;
}
function getViewportWidth() {
    var offset = 17;
    var width = null;
    if (window.innerWidth != window.undefined) return window.innerWidth;
    if (document.compatMode == 'CSS1Compat') return document.documentElement.clientWidth;
    if (document.body) return document.body.clientWidth;
}

function PivotEncode(val) {
   
    val = val.replaceAll('/', '!pcfs!');
    val = val.replaceAll('.', '!pcd!');
    val = val.replaceAll(':', '!pcc!');
    val = val.replaceAll('@', '!pca!');
    val = val.replaceAll('#', '!pcp!');
    val = val.replaceAll('\\', '!pcbs!');
    val = val.replaceAll('?', '!pcqm!');
    val = val.replaceAll('=', '!pce!');
    return val;
}

function getPivotData(pName) {
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/getPivotData/' + pName + "?" + getPca(),
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            getPivotDataCallback(T);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            //alert('error.');
        }
    });
}

function getSinglePivot(pName, pId) {
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/getSinglePivot/' + pName + '/' + pId + "?" + getPca(),
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            getSinglePivotCallback(T);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            //alert('error.');
        }
    });
}

function deleteSinglePivot(pName, pId) {
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/deleteSinglePivot/' + pName + '/' + pId + "?" + getPca(),
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            deleteSinglePivotCallback(T);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            //alert('error.');
        }
    });
}


function getPivotName(uname) {
    uname = PivotEncode(uname);
    var result = "error";
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/getPivotName/' + uname + "?" + getPca(),
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            getPivotNameCallback(T);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert('error.');
        }
    });
}

function pcalert(message) {
    $("#alertboxtext").text(message);
    $("#alertbox").dialog({
        resizable: true,
        height: 210,
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}

function encodeHtml(htmlSrc) {
    encodedHtml = escape(htmlSrc);
    encodedHtml = encodedHtml.replace(/\//g, "%2F");
    encodedHtml = encodedHtml.replace(/\?/g, "%3F");
    encodedHtml = encodedHtml.replace(/=/g, "%3D");
    encodedHtml = encodedHtml.replace(/&/g, "%26");
    encodedHtml = encodedHtml.replace(/@/g, "%40");
    return encodedHtml;
}

function decodeHtml(htmlSrc) {
    decodedHtml = unescape(htmlSrc);
    return decodedHtml;
}