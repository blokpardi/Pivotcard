<%@ Page Title="" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="servicetest.aspx.cs" Inherits="PivotcardSite.servicetest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript" src="scripts/jquery.base64.min.js"></script>
    <script>
        function login() {

            $.ajax({
                type: "GET",
                url: baseUrl + 'DataService.svc/addUserToDB/billtest/foobar/Google',
                contentType: "application/json",
                dataType: "jsonp",
                success: function (R) {
                    alert(R)
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert('error.');
                }
            });
//        requestStr = "http://localhost:59671/DataService.svc/loginUser/jodad/foo/jodaddy/Joe?callback=jscallback"
//        var script = document.createElement('script');
//        script.src = requestStr;
//        script.type = 'text/javascript';
//        var head = document.getElementsByTagName('head').item(0);
//        head.appendChild(script);
        }

        function LoginCallCompleted(result, context, methodName) {
           alert("completed: " + result);
       }

       function onLoginFailed(result, context, methodName) {
           alert("failed: "+ result);
       }

       function getSinglePivotCallback(d) {
           alert(d[0].PivotCode);
       }

       function getPivotDataCallback(d) {
           alert(d == "");
       }

       function login2(un, pw) {
           //Sys.Services.AuthenticationService.login(un, pw, false, null, null, LoginCallCompleted, onLoginFailed, un);
           loginUser(un, pw, false);
       }

       function execUser() {
           jQuery("#btnNewUser").click();
       }

       function makeCookies(sName, sValue) {
           var cookieStr = document.cookie.split();
           var theDate = new Date();
           var oneYearLater = new Date(theDate.getTime() + 31536000000);
           var expiryDate = oneYearLater.toGMTString();
           newValStr = sName + "=" + sValue;
           if (cookieStr[0].length > 1) {
               for (i = 0; i < cookieStr.length; i++) {
                   if (cookieStr[i].split('=')[0] == sName) {
                       cookieStr[i] = newValStr;
                       break;
                   }
               }
               cookieStr +=  ";" + newValStr;
           }
           else {
               cookieStr = newValStr;
           }
           cookieStr += ";expires=" + expiryDate;
           document.cookie = cookieStr;
       }

       function getCookies() {
           var siteCookies = document.cookie.split();
           alert(document.cookie);
       }

       function addPivotName() {
       alert(PivotEncode('https://www.google.com/profiles/103196419386017633518'));
       var un = PivotEncode('https://www.google.com/profiles/103196419386017633518');
           $.ajax({
               type: "GET",
               url: baseUrl + 'DataService.svc/addPivotName/' + un + '/' + 'billdad',
               contentType: "application/json",
               dataType: "jsonp",
               success: function (R) {
                   alert(R);
               },
           
           error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    //alert('error.');
                }
           });
        }

        function savePivot() {
            $.ajax({
                type: "GET",
                //the save function requires {pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}
                //url: baseUrl + 'DataService.svc/savePivot/' + 'billpardi' + '/' + 'fb' + '/' + '3456' + '/' + PivotEncode('<b>hi</b>') + '/' + 'pl' + '/' + 'false',
                url: baseUrl + 'DataService.svc/savePagePivot/' + 'billpardi' + '/' + 'hi' + '/' + '9864' + '/' + 'pp' + '/' + 'false?content=<b>hi</b>',
                contentType: "application/json",
                dataType: "jsonp",
                success: function (R) {
                    alert(R);
                },

                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    //alert('error.');
                }
            });
        }

       
       // To use, simple do: Get_Cookie('cookie_name'); 
       // replace cookie_name with the real cookie name, '' are required
       function Get_Cookie(check_name) {
           // first we'll split this cookie up into name/value pairs
           // note: document.cookie only returns name=value, not the other components
           var a_all_cookies = document.cookie.split(';');
           var a_temp_cookie = '';
           var cookie_name = '';
           var cookie_value = '';
           var b_cookie_found = false; // set boolean t/f default f
           var i = '';

           for (i = 0; i < a_all_cookies.length; i++) {
               // now we'll split apart each name=value pair
               a_temp_cookie = a_all_cookies[i].split('=');


               // and trim left/right whitespace while we're at it
               cookie_name = a_temp_cookie[0].replace(/^\s+|\s+$/g, '');

               // if the extracted name matches passed check_name
               if (cookie_name == check_name) {
                   b_cookie_found = true;
                   // we need to handle case where cookie has no value but exists (no = sign, that is):
                   if (a_temp_cookie.length > 1) {
                       cookie_value = unescape(a_temp_cookie[1].replace(/^\s+|\s+$/g, ''));
                   }
                   // note that in cases where cookie is initialized but no value, null is returned
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

       /*
       only the first 2 parameters are required, the cookie name, the cookie
       value. Cookie time is in milliseconds, so the below expires will make the 
       number you pass in the Set_Cookie function call the number of days the cookie
       lasts, if you want it to be hours or minutes, just get rid of 24 and 60.

       Generally you don't need to worry about domain, path or secure for most applications
       so unless you need that, leave those parameters blank in the function call.
       */
       function Set_Cookie(name, value, expires, path, domain, secure) {
           // set time, it's in milliseconds
           var today = new Date();
           today.setTime(today.getTime());
           // if the expires variable is set, make the correct expires time, the
           // current script below will set it for x number of days, to make it
           // for hours, delete * 24, for minutes, delete * 60 * 24
           if (expires) {
               expires = expires * 1000 * 60 * 60 * 24;
           }
           //alert( 'today ' + today.toGMTString() );// this is for testing purpose only
           var expires_date = new Date(today.getTime() + (expires));
           //alert('expires ' + expires_date.toGMTString());// this is for testing purposes only

           document.cookie = name + "=" + escape(value) +
		((expires) ? ";expires=" + expires_date.toGMTString() : "") + //expires.toGMTString()
		((path) ? ";path=" + path : "") +
		((domain) ? ";domain=" + domain : "") +
		((secure) ? ";secure" : "");
       }

       // this deletes the cookie when called
       function Delete_Cookie(name, path, domain) {
           if (Get_Cookie(name)) document.cookie = name + "=" +
			((path) ? ";path=" + path : "") +
			((domain) ? ";domain=" + domain : "") +
			";expires=Thu, 01-Jan-1970 00:00:01 GMT";
       }
       function alertme() {
           pcalert('This is a test of the emergency broadcast system.');
       }

       function getPivotNameCallback(T) {
           alert(T)
       }

       function getSinglePivotCallback(T) {
           alert(T[0].PivotDefault);
       }

       function checkMyPivot() {
           pivotChecker();
       }

       function pivotChecker() {
           
//          $.ajax({
//               type: "GET",
//               url: baseUrl + 'DataService.svc/checkPivot/billpardi',
////               url: 'http://pardiserv2/DataService.svc/checkPivot/billpardi',
//               contentType: "application/json",
//               dataType: "jsonp",
//               success: function (T) {
//                    alert(T);
//                },
//               error: function(xhr, ajaxoptions, errorThrown) {
//                    alert(errorThrown);
//               }
           //          });
//           userName = PivotEncode("https://www.google.com/profiles/103196419386017633518");
//           pcToken = "52345363536234534563245363345345";
//           var url = baseUrl + 'DataService.svc/checkToken/' + userName + '/' + pcToken;
//                     $.ajax({
//                          type: "GET",
//                          url: url,
//                          contentType: "application/json",
//                          dataType: "jsonp",
//                          success: function (T) {
//                               alert(T);
//                           },
//                          error: function(xhr, ajaxoptions, errorThrown) {
//                               alert(errorThrown);
//                          }
//                     });

           //           url = baseUrl + 'DataService.svc/checkPivot/' + 'foobar' + "?" + getPca();
           url = baseUrl + 'DataService.svc/checkToken/' + PivotEncode(userName) + '/' + pcToken
           $.getJSON(url, null, function (data) {
               alert(data);
           });
       }

       function aestest() {
           var bstr = $.base64.encode("this is a test");
           $.ajax({
               type: "GET",
               url: baseUrl + 'DataService.svc/decryptVal/' + bstr,
               contentType: "application/json",
               dataType: "jsonp",
               success: function (R) {
                   alert(R);
               },

               error: function (xhr, ajaxOptions, thrownError) {
                   alert(xhr.responseText);
                   //alert('error.');
               }
           });

       }

</script>
<div id="status"></div>
<input type="button" value="Encryption" onclick="aestest()" />
<input type="button" value="Login" onclick="login2('PC1', 'JG01')" />
<input type="button" value="Login Service" onclick="login()" />
<input type="button" value="Alert" onclick="alertme()" />
<input type="button" value="Check Pivot" onclick="checkMyPivot()" />
<input type="button" value="Logout" onclick="logoutUser()" />
<input type="button" value="IsLoggedIn?" onclick="isLoggedIn()" />
<input type="button" value="Add Pivot name" onclick="addPivotName()" />
<input type="button" value="Get user name" onclick="alert(getUserName())" />
<input type="button" value="Get pivot name" onclick="getPivotName('https://www.google.com/profiles/103196419386017633518')" />
<input type="button" value="Get pivot data" onclick="getPivotData('foobar')" />
<input type="button" value="Get single pivot" onclick="getSinglePivot('foobar', '1730')" />
<input type="button" value="Save Pivot" onclick="savePivot()" />
    <asp:Button ID="Button1" runat="server" Text="CreateUser" 
        onclick="Button1_Click" />

        <input type="button" value="testajax" onclick="testajax()" />

    <div style="display:none"><asp:TextBox ID="un" runat="server">https://www.google.com/profiles/103196419386017633518</asp:TextBox>
    <asp:TextBox ID="pw" runat="server">Google</asp:TextBox>
    <asp:Button ID="btnNewUser" runat="server" Text="Create User" ClientIDMode="Static" onclick="btnNewUser_Click" /></div>
    <input id="Button2" type="button" onclick="execUser()" value="Clickit" />
    
    <asp:Button ID="Button3" runat="server" Text="login asp" 
    onclick="Button3_Click" />

    <p><input type="button" value="Make a login cookie" onclick="Set_Cookie('login','Google','360')" /><input type="button" value="Make a test cookie" onclick="Set_Cookie('test','this','360')" /><input type="button" value="Get login" onclick="alert(Get_Cookie('login'))" /><input type="button" value="Get test" onclick="alert(Get_Cookie('test'))" />
    <asp:Button ID="testXdoc" runat="server" Text="XDoc" onclick="testXdoc_Click" />
    </p>
    <p>
        <asp:Button ID="mkPF" runat="server" Text="Make Pivot File" 
            onclick="mkPF_Click" />
        <asp:Button ID="ckUser" runat="server" onclick="ckUser_Click" 
            Text="Check User" />
    </p>
</asp:Content>
