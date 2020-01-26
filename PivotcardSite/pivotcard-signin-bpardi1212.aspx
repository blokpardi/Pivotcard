<%@ Page Title="Pivotcard Signin" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="pivotcard-signin.aspx.cs" Inherits="PivotcardSite.pivotcard_signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

<script type="text/javascript" src="scripts/pivotcard-signin.js"></script>
  
<div id="heroboxNarrow">
<div id="pNameBox">
    <div id="pNameEdit" style="margin-top:30px;">
        <span style="float:left; width:400px; font-size:16pt; margin-bottom:15px">Welcome to Pivotcard!</span>
        <span name="urlBox">Pivotcard Name</span>
        <input type="text" id="pNameInput" style="width:220px"/><br />
        <div id="pNameError" class="errorText" style="margin-left:150px; margin-top:5px;">&nbsp;</div>
        <div class="editButtons"><div id="pNameContinue" style="margin-top:0px">Continue</div></div>
        <div style="font-size:9pt; margin:5px 0px 0px 110px; float:left"><div style="float:left">Already have an account?</div><div id="pNameSignIn" style="cursor:pointer;float:left; text-decoration:underline; margin-left:10px">Sign-in</div></div>
    </div>
    <div class="heroctaNarrow" style="margin-top:45px;">
        <div class="titletext" style="font-size:20pt">Create a unique Pivotcard name. This will be part of your address, as in pivotcard.com/YOURNAME. </div>
    </div>
</div>
<div id="loginBox">
<div id="janrainEngage">
<div id="janrainEngageEmbed"></div>
</div>
<div class="heroctaNarrow" style="margin-top:45px;">
    <div id="signupText" class="titletext" style="font-size:20pt">Signup using a login you already have, or create a new Pivotcard login. Easy.</div>
    <div id="signinText" class="titletext" style="font-size:20pt; display:none">Welcome back! Sign-in to Pivotcard or create a new account.</div>
</div>
</div>

<div id="logoutBox" style="display:none">
Hi there. You're logged in.
</div>
</div>
<div id="status"></div>

</asp:Content>
