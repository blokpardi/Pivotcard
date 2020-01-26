<%@ Page Title="Pivotcard - Upgrade Your Business Card" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="upgrade.aspx.cs" Inherits="PivotcardSite.upgrade" %>
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
<div id="herocta" class="titletext">
    <span class="herotext" style="margin-left:45px; width:405px; margin-top:45px">Upgrade Your Business Card</span>
    <span class="herotext" style="font-size:14pt;margin-left:45px; width:405px; text-align:center; margin-top:30px">No more scribbling your Facebook address on a<br />corporate business card, or handing out work<br />information at a hobbyist meeting.</span>
    <span class="herotext" style="font-weight:bold;font-size:14pt;margin-left:45px; width:405px; text-align:center; margin-top:25px">One virtual card for work, play, and<br />everything in between.</span>
    <input type="button" id="startbutton" style="margin-top:30px; margin-left:157px" value="Get started" />
    <span style="margin-left:175px; margin-top:15px; width:380px;font-size:12pt;float:inherit">Or <a href="learn-about-pivotcard.aspx">learn more</a> now</span>
</div>
<div id="heroimage"><img alt="Pivotcard - One Card for All Your Identities" src="images/home_hero.png" /></div>
</div>
</asp:Content>
