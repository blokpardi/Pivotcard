<%@ Page Title="Pivotcard Signin" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="pivotcard-signin.aspx.cs" Inherits="PivotcardSite.pivotcard_signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

<script type="text/javascript" src="scripts/jquery.base64.min.js"></script>
<script type="text/javascript" src="scripts/pivotcard-signin.js"></script>
  
<div id="heroboxNarrow">
    <div id="loginBox">
        <span style="float:left; text-align:center; width:400px; height:auto; font-size:16pt; margin-top:10px;margin-bottom:15px">Welcome to Pivotcard!</span>
        <div id="pNameEdit">
            <span class="label">Pivotcard Name</span>
            <input type="text" id="pNameInput" name="pNameInput" class="signinValidate" style="width:200px"/><span htext="This should be a unique name you use to identify yourself. It will be part of your Pivotcard address as in pivotcard.com/YOURNAME" class="helpbubble" style="float:right;">?</span><br />
            <div id="pNameError" class="errorText" style="margin-left:122px;">&nbsp;</div>
        </div>
        <div id="uNameEdit">
            <span class="label" >User Name</span>
            <input type="text" id="uNameInput" name="uNameInput" class="signinValidate" style="width:200px"/><span htext="User name must be a valid email address" class="helpbubble" style="float:right;">?</span><br />
            <div id="uNameError" class="errorText" style="margin-left:88px;">&nbsp;</div>
        </div>
        <div id="pwEdit">
            <span class="label" >Password</span>
            <input type="password" id="pwInput" name="pwInput" class="signinValidate" style="width:200px"/><span htext="No spaces in your password, please!" class="helpbubble" style="float:right;">?</span><br />
            <div id="pwError" class="errorText" style="margin-left:77px;">&nbsp;</div>
        </div>
        <div class="editButtons">
            <div class="persist" style="font-weight:normal; margin:0px 10px 0px 90px"><input id='ckPersist' onclick='changePers(this.checked)' type='checkbox'>stay logged in</input></div>
            <div id="signinContinue" style="margin-top:0px">Continue</div>
        </div>
        <div style="font-size:9pt; margin:5px 0px 0px 110px; float:left"><div style="float:left">Already have an account?</div><div id="pNameSignIn" style="cursor:pointer;float:left; text-decoration:underline; margin-left:10px">Sign-in</div>
        </div>
    </div>
    <div class="heroctaNarrow" style="margin-top:60px;margin-left:20px">
        <div id="signupText" class="titletext" style="font-size:20pt">Signup using a login you already have, or create a new Pivotcard login. Easy.</div>
        <div id="signinText" class="titletext" style="font-size:20pt; display:none">Welcome back! Sign-in to Pivotcard or create a new account.</div>
    </div>
<div id="logoutBox" style="display:none">
Hi there. You're logged in.
</div>
</div>
<div id="status"></div>
<div id="hovertip" class="hovertip">this is a tip</div>

</asp:Content>
