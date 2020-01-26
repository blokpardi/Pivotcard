var pers = false;
var pTimer;
var pnValidator;
var tooltip;

$(document).bind("ready", function () {
    signInPageCheck();
    setupTooltips();
    setupSignupValidation();
});

function setupSignupValidation() {
    $("#masterForm").validate({
        rules: {
            pNameInput: {
                required: true,
                pcnospace: true,
                remote: function () {
                    var r = {
                        type: "GET",
                        url: baseUrl + 'DataService.svc/checkPivot/' + $("#pNameInput").val(),
                        contentType: "application/json",
                        dataType: "jsonp"
                    };
                    return r;
                }
            },
            uNameInput: {
                required: true,
                email: true,
                pcnospace: true,
                remote: function () {
                    var u = {
                        type: "GET",
                        url: baseUrl + 'DataService.svc/checkUser/' + PivotEncode($("#uNameInput").val()),
                        contentType: "application/json",
                        dataType: "jsonp"
                    };
                    return u;
                }
            },
            pwInput: {
                required: true,
                pcnospace: true
            }
        },
        messages: {
            pNameInput: {
                required: "A Pivot name is required.",
                pcnospace: "Pivot names cannot contain spaces.",
                remote: "Name already taken. Please try again."
            },
            uNameInput: {
                required: "A user name is required.",
                email: "User names must be an email address.",
                pcnospace: "User names cannot contain spaces.",
                remote: "User name already taken. Please try again."
            },
            pwInput: {
                required: "A password is required.",
                pcnospace: "Passwords cannot contain spaces."
            }
        },
        // the errorPlacement has to take the table layout into account
        errorPlacement: function (error, element) {
            error.appendTo(element.next().next().next());
        }
    });
}

function setupSigninValidation() {
    $('#uNameInput').rules('remove', 'remote');
}

function setupTooltips()
{
    $('#loginBox .helpbubble').mouseenter(function () {
        $("#hovertip")
            .css({
                  top: $(this).position().top - 25,
                  left: $(this).position().left + $(this).width() + 10
              })
            .text($(this).attr('htext'))
            .fadeIn('fast');
    })
    .mouseleave(function(){
      $("#hovertip").fadeOut('fast');
    });

}

function signInPageCheck() {
    $("#pNameEdit").hide(), $("#logoutBox").hide(), $("#signinText").hide(),$("#pNameInput").val("");
    if (isLoggedIn()) {
        $("#logoutBox").show();
    }
    else if (getCookie('login') != null) {
        $("#signupText").hide(), $("#signinText").show(), $("#loginBox").show();
    }
    else {
        $("#pNameEdit").show();
        $("#signinContinue").click(function () {
            var isValid
            $(".signinValidate").each(function (i) {
                //alert(!$(this).valid());
                if ($(this).is(':visible')) {
                    if (!$(this).valid())
                        isValid = false;
                    else {
                        if (isValid != false) {
                            isValid = true;
                        }
                    }
                }
            });
            if (isValid) {
                var pn = $("#pNameInput").val();
                var un = $("#uNameInput").val();
                var pw = $("#pwInput").val();
                signin(pn, un, pw);
            }
        });
        $("#pNameBox").css("display", "block");
        $("#pNameSignIn").click(function () {
            $("#signinText").show(), $("#loginBox").show(), $("#pNameEdit").hide(), $("#signupText").hide(), $("#pNameInput").val("");
            setupSigninValidation();
        });
        $("#pNameInput").focus();
    }
}

function signin(pn, un, pw) {
    var svcUrl;
    pw = $.base64.encode(pw);
    if (pn != "") {
        //new signup
        svcUrl = baseUrl + 'DataService.svc/addUserToDB/' + PivotEncode(un) + "/" + pn + "/" + pw;
    }
    else {
        svcUrl = baseUrl + 'DataService.svc/pcLogin/' + PivotEncode(un) + '/' + pw;
    }
    //find pivotName to be able to create server token
    $.ajax({
        type: "GET",
        url: svcUrl,
        contentType: "application/json",
        dataType: "jsonp",
        success: function (T) {
            if (T[0].status == "ok") {
                loginUser(T[0].username, T[0].token, pers);
            }
            else if (T[0].status != "ok") {
                $("#alertboxtext").text("User doesn't exist, please use an existing account or create a new account.");
                $("#alertbox").dialog({
                    resizable: true,
                    height: 200,
                    width: 300,
                    modal: true,
                    close: function () {
                        deleteCookie('login');
                        deleteCookie('pcToken');
                        signInPageCheck();
                    },
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                            $("#pNameEdit").hide(), $("#logoutBox").hide(), $("#signinText").hide(), $("#pNameInput").val("");
                            if (isLoggedIn()) {
                                $("#logoutBox").show();
                            }
                            else if (getCookie('login') != null) {
                                $("#signupText").hide(), $("#signinText").show(), $("#loginBox").show();
                            }
                            else {
                                $("#pNameEdit").show();
                            }
                        }
                    }
                });
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert('error.');
        }
    });
}

function changePers(val) {
    pers = val;
}