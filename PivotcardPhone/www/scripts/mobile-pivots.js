
/***************************
setup functions
***************************/
function setupMyPivots() {
    setupAddButton();
    setupEditDialog()
    setupPivotValidation();
    setFooterContent("Logged in as " + userName);
    getPivotName(userName);

    $(window).scroll(function () {
        if ($('#editDialog').is(':visible')) {
            centerPopup();
        }
    });
}

function setupCards(d) {
    stopActivity();
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
}

function setupPivotValidation() {
    //validation rules
    $("#editDialog").validate({
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
        closeEditBox();
    });

    //if save button is clicked
    $('#editDialog .save').click(function (e) {
        //Cancel the link behavior

        e.preventDefault();
        var pType;
        var isValid
        if ($("#shortcutPage").is(':visible')) {

            $(".pcValidate").each(function (i) {
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
                startActivity();
                $.ajax({
                    type: "GET",
                    //the save function requires {pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}
                    url: baseUrl + 'DataService.svc/savePivot/' + pivotName + '/' + pCode + '/' + pId + '/' + PivotEncode(pContent) + '/' + pType + '/' + pDefault + "?" + getPca(),
                    contentType: "application/json",
                    dataType: "jsonp",
                    success: function (R) {
                        getPivotData(pivotName);
                    }
                });
                closeEditBox();
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
                startActivity();
                $.ajax({
                    type: "GET",
                    //the save function requires {pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}
                    url: baseUrl + 'DataService.svc/savePagePivot/' + pivotName + '/' + pCode + '/' + pId + '/' + pType + '/' + pDefault + '?content=' + pContent + "&" + getPca(),
                    contentType: "application/json",
                    dataType: "jsonp",
                    success: function (R) {
                        getPivotData(pivotName);
                    }
                });
                closeEditBox();
            }
        }

    });
}

function closeEditBox() {
    clearEditBox();
    $('#mask').hide();
    $('#editDialog').hide();
    backScript.pop();
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
        showEditBox();
        //        centerPopup();
        //        
        //        $('#mask').fadeIn(100);
        //        //transition effect
        //        $("#editDialog").fadeIn(500);
    });
}

function setPivotEditLink(val) {
    $("#pivotEditLink").text(pivotName + "/" + val);
}

function setupAddButton() {

    //select all the a tag with name equal to modal
    $('#btnAddPivot').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();
        clearEditBox();
        showEditBox();

    });

    //if mask is clicked
    $('#mask').click(function () {
        $(this).hide();
        $('#editDialog').hide();
    });
}

function showEditBox() {
    backScript.push('closeEditBox()')
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
    var maskHeight = $(document).height(); //getViewportHeight(); // $(document).height();
    var maskWidth = getViewportWidth(); // $(window).width();

    //Set heigth and width to mask to fill up the whole screen
    $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

    //Get the window height and width
    var winH = getViewportHeight()//($(document).height() - $(window).scrollTop());
    var winW = $(document).width();

    //Set the popup window to center
    $("#editDialog").css('top', ((winH / 2) + $(window).scrollTop()) - $("#editDialog").height() / 2);
    $("#editDialog").css('left', winW / 2 - $("#editDialog").width() / 2);
}

/***************************
callback functions
***************************/

function getSinglePivotCallback(d) {
    stopActivity();
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
    stopActivity();
    getPivotData(pivotName);
}

function getPivotNameCallback(d) {
    stopActivity();
    pivotName = d;
    getPivotData(pivotName);
}

function getPivotDataCallback(d) {
    stopActivity();
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
