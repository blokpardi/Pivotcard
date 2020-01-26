<%@ Page Title="Pivotcard Social" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="pivotcard-social.aspx.cs" Inherits="PivotcardSite.pivotcard_social" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=208010555941571";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>

<div id="heroboxNarrow">
    <div id="contentContainer">
    <div style="float:left; margin:5px 0 10px 0; width:650px; font-size:16pt">Connect with Pivotcard</div>
    <div style="float:left; margin:0 0 25px 0; width:640px; font-size:12pt">Find us on Facebook and Twitter. Or, <a href="mailto:feedback@pivotcard.com">contact us</a> if you prefer the email route.</div>
        
    <div id="facebookBox" style="float:left; width:430px">
        <div class="fb-like-box" data-href="http://www.facebook.com/pivotcard" data-width="400" data-show-faces="true" data-stream="true" data-header="true"></div>
    </div>
    <div id="twitterbox" style="float:left; width:auto">
        <script src="http://widgets.twimg.com/j/2/widget.js"></script>
        <script>
            new TWTR.Widget({
                version: 2,
                type: 'profile',
                rpp: 9,
                interval: 30000,
                width: 400,
                height: 590,
                theme: {
                    shell: {
                        background: '#838c93',
                        color: '#ffffff'
                    },
                    tweets: {
                        background: '#ffffff',
                        color: '#000000',
                        links: '#ed895a'
                    }
                },
                features: {
                    scrollbar: false,
                    loop: false,
                    live: false,
                    behavior: 'all'
                }
            }).render().setUser('Pivotcard').start();
        </script>
    </div>
    </div>
</div>
</asp:Content>
