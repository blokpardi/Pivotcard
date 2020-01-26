﻿<%@ Page Title="Pivotcard Home" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PivotcardSite.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script language="javascript" type="text/javascript">
    $(document).bind("ready", function () {
        $("#learnbutton").click(function () {
            window.location.href = "learn-about-pivotcard.aspx";
        });
    });
</script>
<div id="herobox">
<div id="herocta" class="titletext"><span class="herotext">Meeting new friends and business contacts is about to get a lot easier</span><input type="button" id="learnbutton" value="Learn more" /></div>
<div id="heroimage"><img alt="Pivotcard - One Card for All Your Identities" src="images/home_hero.png" /></div>
</div>
</asp:Content>
