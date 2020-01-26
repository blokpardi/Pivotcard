<%@ Page Title="" Language="C#" MasterPageFile="PCM.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="PivotcardSite.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script type="text/javascript" language="javascript">
    function adminLogin() {
        //Sys.Services.AuthenticationService.login(un, pw, false, null, null, LoginCallCompleted, onLoginFailed, un);
        var un = $("#userName").val();
        var pw = $("#passWord").val();
        loginUser(un, pw, false);
    }
    </script>
    <div style="float:left;">
        <label>Username: </label><input id="userName" type="text" /><br />
        <label>Password: </label><input id="passWord" type="password" /><br />
        <input id="login" type="button" value="Login" onclick="adminLogin()" />  
    </div>
</asp:Content>
