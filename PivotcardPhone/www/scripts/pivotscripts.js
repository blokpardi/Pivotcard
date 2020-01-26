String.prototype.replaceAll = function (s1, s2) { return this.split(s1).join(s2) }
String.prototype.boolean = function () { return "True" == this; };
pTypes = { "pl": "pivotlink", "pp": "pivotpage" };
var userName, pivotName, pcToken;
var baseUrl = "http://next.pivotcard.com/";

$(document).bind("ready", function () {
    setupNavButtons();
    setupTooltips();
    jQuery.validator.addMethod("pcnospace", function (value, element) {
        return value.indexOf(" ") < 0 && value != "";
    }, "Spaces are not allowed");
});

function startActivity() {
    navigator.notification.activityStart();
}

function stopActivity() {
    navigator.notification.activityStop();
}

function pgalert(val) {
    navigator.notification.alert(val);
}

function setFooterContent(val) {
    $("#footercontent").html(val);
}
function setupTooltips() {
    $('.helpbubble').click(function () {
        var bloc = $(this).offset();
        $("#tiptext").text($(this).attr('htext'));
        $("#tipmask")
            .css({
                top: 0,
                left: 0,
                height: $(document).height()
            });
        $("#tiptext")
            .css({
                top: ($(this).position().top + $(window).scrollTop()) - 5,
                left: $(this).position().left - ($("#tiptext").width() + 20)
            });
        $(".hovertip")
        .fadeIn("fast")
        .click(function () {
            $(".hovertip").fadeOut("fast");
        });
    });
}
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
        initHome();
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
    stopActivity();
    var cookietimeout = "20";
    if (pers) {
        cookietimeout = "525300"
    }
    setCookie('login', un, cookietimeout);
    userName = un;
    setCookie('pcToken', token, cookietimeout);
    pcToken = token;
    initMyPivots();
}

function getUserName() {
    return getCookie('login');
}

function getToken() {
    return getCookie("pcToken");
}

function logoutUser() {
    deleteCookie("login");
    deleteCookie("pcToken");
    window.location.href = "pivotcard-signin.aspx";
}


function getCookie(name) {

    if (window.localStorage.getItem(name) == null) {
        return null;
    }
    else {
        return window.localStorage.getItem(name);
    }

}

function setCookie(name, value, vexpires, vpath, domain, secure) {

    window.localStorage.setItem(name, value);
}

// this deletes the cookie when called
function deleteCookie(name, path, domain) {
    window.localStorage.removeItem(name);
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
    if (checkConnection()) {
        startActivity();
        $.ajax({
            type: "GET",
            url: baseUrl + 'DataService.svc/getPivotData/' + pName + "?" + getPca(),
            contentType: "application/json",
            dataType: "jsonp",
            success: function (T) {
                getPivotDataCallback(T);
            }
        });
    }
    else {
        fwdNav('#nonet');
    }
}

function getSinglePivot(pName, pId) {
    startActivity();
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/getSinglePivot/' + pName + '/' + pId + "?" + getPca(),
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            getSinglePivotCallback(T);
        }
    });
}

function deleteSinglePivot(pName, pId) {
    startActivity();
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/deleteSinglePivot/' + pName + '/' + pId + "?" + getPca(),
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            deleteSinglePivotCallback(T);
        }
    });
}


function getPivotName(uname) {
    startActivity();
    uname = PivotEncode(uname);
    var result = "error";
    $.ajax({
        type: "GET",
        url: baseUrl + 'DataService.svc/getPivotName/' + uname + "?" + getPca(),
        contentType: "application/json",
        cache: false,
        dataType: "jsonp",
        success: function (T) {
            getPivotNameCallback(T);
        }
    });
}

function pcalert(message) {
    $("#alertboxtext").text(message);
    $("#alertbox").dialog({
        resizable: true,
        height: 200,
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