$(document).bind("ready", function () {
    if ((isLoggedIn()) || (getCookie('login') != null)) {
        userName = getCookie('login');
        pcToken = getCookie("pcToken");
        $.getJSON(baseUrl + 'DataService.svc/checkToken/' + PivotEncode(userName) + '/' + pcToken, null, null);
        $("#startlink").text("My Pivots").click(function (e) {
            e.preventDefault();
            window.location.href = "my-pivots.aspx";
        });
    }
    else {
        $("#startlink").text("Get Started").click(function (e) {
            e.preventDefault();
            window.location.href = "pivotcard-signin.aspx";
        });

    }
});