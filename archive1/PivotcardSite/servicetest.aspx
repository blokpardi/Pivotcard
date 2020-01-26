<%@ Page Title="" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="servicetest.aspx.cs" Inherits="PivotcardSite.servicetest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script>
    function login() {
        requestStr = "http://localhost:50752/DataService.svc/loginUser/jodad/foo/Joe?callback=jscallback"
        var script = document.createElement('script');
        script.src = requestStr;
        script.type = 'text/javascript';
        var head = document.getElementsByTagName('head').item(0);
        head.appendChild(script);
        }

        function onLoginCallCompleted(result, context, methodName) {
           alert(result);
       }

       function testajax() {
           var jsonUrl = 'http://localhost:50752/DataService.svc/janrainLogin/6eb2fe2d759f4b6b67a87d21c59ea9a9c5434bf8?callback=jscallback';
           jQuery.getJSON(jsonUrl, null, function jscallback(retVal) {
               alert(retVal);
           });
       }

       function jscallback(retVal) {
           alert(retVal);
       }
</script>
<input type="button" value="Login" onclick="loginUser()" />
<input type="button" value="IsLoggedIn?" onclick="isLoggedIn()" />
    <asp:Button ID="Button1" runat="server" Text="CreateUser" 
        onclick="Button1_Click" />

        <input type="button" value="testajax" onclick="testajax()" />
</asp:Content>
