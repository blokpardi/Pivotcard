<%@ Page Title="Pivotcard Home" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PivotcardSite.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script language="javascript" type="text/javascript">
    $(document).bind("ready", function () {
        $("#startbutton").click(function () {
            if (isLoggedIn) {
                window.location.href = "my-pivots.aspx";
            }
            else {
                window.location.href = "pivotcard-signin.aspx";
            }
        });
    });
</script>
<div id="herobox">
<div id="herocta" class="titletext"><span class="herotext">One business card.<br />Multiple identities.</span><input type="button" id="startbutton" value="Get started" /><span style="margin-left:143px; margin-top:15px; width:380px;font-size:12pt;float:inherit">Or <a href="learn-about-pivotcard.aspx">learn more</a> now</span></div>
<div id="heroimage"><img alt="Pivotcard - One Card for All Your Identities" src="images/home_hero.png" /></div>
</div>
</asp:Content>
