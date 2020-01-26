
$(document).bind("ready", function () {
    if (!isLoggedIn()) {
        window.location.href = 'pivotcard-signin.aspx';
    }
    else {
        setupPage();
    }
});

/***************************
setup functions
***************************/
function setupPage() {
    userName = getUserName();
    setupAddButton();
    setupEditDialog()
    $("#pivotCodeInput").keyup(function () {
        setPivotEditLink($(this).val());
        $("#pivotPageCodeInput").val($(this).val());
    });
    $("#pivotPageCodeInput").keyup(function () {
        setPivotEditLink($(this).val());
        $("#pivotCodeInput").val($(this).val());
    });
    $(window).resize(function () {
        centerPopup();
    });
    $(window).scroll(function () {
        centerPopup();
    });

    getPivotName(userName);
}

function setupCards(d) {
    $("#myTitleName").text(pivotName);
    $("#myTitleLink").text(pivotName);
    $("#myCardContainer").empty();
    for (x in d) {
        var pivotContent = "";
        if (d[x].PivotType == "pl") {
            pivotContent = d[x].PivotContent;
        }
        else if (d[x].PivotType = "pp") {
            var pivotURL = baseUrl + pivotName + "/" + d[x].PivotCode;
            pivotContent = "Custom HTML. Click <a href='" + pivotURL + "' target='_blank'>here</a> to preview.";
        }
        var cardHTML = "<div id='" + d[x].PivotId + "' class='myCardBox'>" +
            "<div class='cardContent'><div class='cardTitle'>" + d[x].PivotCode + "</div><div class='cardLink'>" + pivotContent + "</div></div>" +
            "<div class='cardButtons'><a id='a" + x + "' href='#" + d[x].PivotId + "' name='edit'>Edit</a><a id='d" + x + "' href='#" + d[x].PivotId + "' name='delete'>Delete</a><div>" +
            "<div>";
        $("#myCardContainer").append(cardHTML);
    }
    setupEditButtons();
    setupDeleteButtons();
    $("#nscontain").fadeIn("slow").click(function () {
        window.location.href = "gear.aspx";
    });
}

function setupEditDialog() {
    //$('#shortcut').toggleClass('a', true);
    $('#pivotpage').toggleClass('inactive');
    $('#pivotPagePage').hide();
    $('.typeButton').click(function () {
        if ($(this).hasClass('inactive')) {
            $('.typeButton').toggleClass('inactive');
            $('.typePage').toggle();
        }
    })

    //if close button is clicked
    $('#editDialog .cancel').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();
        clearEditBox();
        $('#mask').hide();
        $('#editDialog').hide();
    });

    //if save button is clicked
    $('#editDialog .save').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();
        var pType;
        var isValid
        if ($("#shortcutPage").is(':visible')) {

            $(".pcValidate").each(function (i) {
                //alert(!$(this).valid());
                if (!$(this).valid()) {
                    isValid = false;
                }
                else {
                    if (isValid != false) {
                        isValid = true;
                    }
                }
            });

            if (isValid) {
                pType = 'pl';
                pId = $("#pivotIdInput").val();
                pCode = $("#pivotCodeInput").val();
                pContent = $("#pivotUrlInput").val();
                pDefault = $("#pivotDefaultInput").is(":checked");
                $.ajax({
                    type: "GET",
                    //the save function requires {pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}
                    url: baseUrl + 'DataService.svc/savePivot/' + pivotName + '/' + pCode + '/' + pId + '/' + PivotEncode(pContent) + '/' + pType + '/' + pDefault + "?" + getPca(),
                    contentType: "application/json",
                    dataType: "jsonp",
                    success: function (R) {
                        getPivotData(pivotName);
                    },

                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.responseText);
                        //alert('error.');
                    }
                });
                $('#mask').hide();
                $('#editDialog').hide();
            }
        }

        else {
            $(".ppValidate").each(function (i) {
                //alert(!$(this).valid());
                if (!$(this).valid())
                    isValid = false;
                else {
                    if (isValid != false) {
                        isValid = true;
                    }
                }
            });
            if (isValid) {
                pType = 'pp';
                pId = $("#pivotIdInput").val();
                pCode = $("#pivotPageCodeInput").val();
                pContent = $("#pivotPageHTMLInput").val();
                pContent = encodeHtml(pContent);
                pDefault = $("#ppDefaultInput").is(":checked");
                urrll = baseUrl + 'DataService.svc/savePagePivot/' + pivotName + '/' + pCode + '/' + pId + '/' + pType + '/' + pDefault + '?content=' + pContent + "&" + getPca();
                $.ajax({
                    type: "GET",
                    //the save function requires {pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}
                    url: baseUrl + 'DataService.svc/savePagePivot/' + pivotName + '/' + pCode + '/' + pId + '/' + pType + '/' + pDefault + '?content=' + pContent + "&" + getPca(),
                    contentType: "application/json",
                    dataType: "jsonp",
                    success: function (R) {
                        getPivotData(pivotName);
                    },

                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.responseText);
                        //alert('error.');
                    }
                });
                $('#mask').hide();
                $('#editDialog').hide();
            }
        }

    });

    //validation rules
    var pcValidator = $("#masterForm").validate({
        rules: {
            pivotCodeInput: {
                required: true,
                pcnospace: true
            },
            pivotUrlInput: {
                required: true,
                url: true
            },
            pivotPageCodeInput: {
                required: true,
                pcnospace: true
            },
            pivotPageHTMLInput: "required"
        },
        messages: {
            pivotCodeInput: {
                required: "Please enter a Pivot code",
                pcnospace: "Spaces are not allowed"
            },
            pivotUrlInput: {
                required: "Please enter a valid URL"
            },
            pivotPageCodeInput: {
                required: "Please enter a Pivot code",
                pcnospace: "Spaces are not allowed"
            },
            pivotPageHTMLInput: {
                required: "Please enter valid HTML"
            }
        },
        // the errorPlacement has to take the table layout into account
        errorPlacement: function (error, element) {
            error.appendTo(element.next().next());
        }
    });
}

function setupDeleteButtons() {

    //select all the a tag with name equal to modal
    $('a[name=delete]').click(function (e) {
        e.preventDefault();
        var id = $(this).attr('href');
        $("#dialog-confirm").dialog({
            resizable: false,
            height: 180,
            modal: true,
            buttons: {
                Yes: function () {
                    var idnum = id.split('#')[1];
                    deleteSinglePivot(pivotName, idnum);
                    $(this).dialog("close");
                },
                No: function () {
                    $(this).dialog("close");
                }
            }
        });

    });
}

function setupEditButtons() {

    //select all the a tag with name equal to modal
    $('a[name=edit]').click(function (e) {

        //Cancel the link behavior
        e.preventDefault();

        //Get the A tag
        var id = $(this).attr('href');
        var idnum = id.split('#')[1];
        getSinglePivot(pivotName, idnum);
        setPivotEditLink($(id).find(".cardTitle").text());
        var sHeight = $(id).height() + 40;
        var sWidth = $(id).width() + 40;

        var offset = $(id).offset();
        var sLeft = offset.left;
        var sTop = offset.top;
        $("#animbox").show();
        $('#animbox').css({ 'width': sWidth, 'height': sHeight });
        $('#animbox').offset({ top: sTop, left: sLeft });

        //$('#mask').fadeIn(250);
        //transition effect
        $("#animbox").show(); //.fadeIn(250);

        centerPopup();

        var fHeight = $("#editDialog").height();
        var fWidth = $("#editDialog").width();

        var winH = $(window).height();
        var winW = $(window).width();

        //var doffset = $("#dialog").offset();
        var fLeft = winW / 2 - $("#editDialog").width() / 2; //doffset.left;
        var fTop = winH / 2 - $("#editDialog").height() / 2; //doffset.top;

        $("#animbox").animate({ width: fWidth, height: fHeight, top: fTop, left: fLeft }, 1000,
            function () {
                $("#animbox").hide();
                $('#mask').fadeIn(100);
                //transition effect
                $("#editDialog").fadeIn(100);
            });

    });
}

function setPivotEditLink(val) {
    $("#pivotEditLink").text(pivotName + "/" + val);
}

function setupAddButton() {

    //select all the a tag with name equal to modal
    $('a[name=modal]').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();
        showEditBox();

    });

    //if mask is clicked
    $('#mask').click(function () {
        $(this).hide();
        $('#editDialog').hide();
    });
}

function showEditBox() {
    clearEditBox();
    centerPopup();

    $('#mask').fadeIn(250);
    //transition effect
    $("#editDialog").fadeIn(250);
}

function clearEditBox() {
    $("#pivotCodeInput").val("");
    $("#pivotPageCodeInput").val("");
    $("#pivotPageHTMLInput").val("");
    $("#pivotUrlInput").val("");
    $("#pivotIdInput").val('null');
    $("#pivotDefaultInput").attr('checked', false)
    $("#ppDefaultInput").attr('checked', false)
    $(".errorText").text("");
}

function centerPopup() {
    //Get the screen height and width
    var maskHeight = getViewportHeight(); // $(document).height();
    var maskWidth = getViewportWidth(); // $(window).width();

    //Set heigth and width to mask to fill up the whole screen
    $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

    //Get the window height and width
    var winH = $(window).height();
    var winW = $(window).width();

    //Set the popup window to center
    $("#editDialog").css('top', winH / 2 - $("#editDialog").height() / 2);
    $("#editDialog").css('left', winW / 2 - $("#editDialog").width() / 2);
}

/***************************
callback functions
***************************/

function getSinglePivotCallback(d) {
    if (d[0].PivotType == "pl") {
        $("#pivotCodeInput").val(d[0].PivotCode);
        $("#pivotPageCodeInput").val(d[0].PivotCode);
        $("#pivotUrlInput").val(d[0].PivotContent);
        $("#pivotDefaultInput").attr('checked', (d[0].PivotDefault).boolean());
        $('#pivotPagePage').hide();
        $('#shortcutPage').show();
        $('#shortcut').toggleClass('inactive', false);
        $('#pivotpage').toggleClass('inactive', true);
    }
    else {
        $("#pivotCodeInput").val(d[0].PivotCode);
        $("#pivotPageCodeInput").val(decodeHtml(d[0].PivotCode));
        $("#pivotPageHTMLInput").val(d[0].PivotContent);
        $("#ppDefaultInput").attr('checked', (d[0].PivotDefault).boolean());
        $('#shortcutPage').hide();
        $('#pivotPagePage').show(); 
        $('#shortcut').toggleClass('inactive', true);
        $('#pivotpage').toggleClass('inactive', false);
    }
    $("#pivotIdInput").val(d[0].PivotId);
    
}

function deleteSinglePivotCallback(d) {
    getPivotData(pivotName);
}

function getPivotNameCallback(d) {
    pivotName = d;
    getPivotData(pivotName);
}

function getPivotDataCallback(d) {
    if (d == "") {
        $("#noCardContainer").show();
        $("#cardContainer").hide(); 
    }
    else {
        if (d.length > 1) {
            $("#nowwhat").text("Ok, I have some Pivots. Now what?");
        }
        $("#noCardContainer").hide();
        $("#cardContainer").show();
        setupCards(d);
    }
}
