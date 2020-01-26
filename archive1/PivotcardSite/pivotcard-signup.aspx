<%@ Page Title="" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="pivotcard-signup.aspx.cs" Inherits="PivotcardSite.pivotcard_signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    
<script type="text/javascript">
    (function () {
        if (typeof window.janrain !== 'object') window.janrain = {};
        window.janrain.settings = {};

        janrain.settings.tokenUrl = 'http://localhost:59671/janraintest.aspx';
        janrain.settings.tokenAction = 'event';

        function isReady() { janrain.ready = true; };
        if (document.addEventListener) {
            document.addEventListener("DOMContentLoaded", isReady, false);
        } else {
            window.attachEvent('onload', isReady);
        }

        var e = document.createElement('script');
        e.type = 'text/javascript';
        e.id = 'janrainAuthWidget';

        if (document.location.protocol === 'https:') {
            e.src = 'https://rpxnow.com/js/lib/pivotcard/engage.js';
        } else {
            e.src = 'http://widget-cdn.rpxnow.com/js/lib/pivotcard/engage.js';
        }

        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(e, s);
    })();


    function janrainWidgetOnload() {
        janrain.events.onProviderLoginToken.addHandler(function (tokenResponse) {
            //var jsonUrl = 'http://localhost:50752/DataService.svc/janrainLogin/' + tokenResponse.token;// +'?callback=jscallback';
            //jQuery.getJSON(jsonUrl, null, function jscallback(retVal) {
            //    alert(retVal);
            //            });
            requestStr = 'http://localhost:50752/DataService.svc/janrainLogin/' + tokenResponse.token +'?callback=jscallback';
            var script = document.createElement('script');
            script.src = requestStr;
            script.type = 'text/javascript';
            var head = document.getElementsByTagName('head').item(0);
            head.appendChild(script);

        })
    }

    function jscallback(retVal) {
        alert(retVal);
    }
</script>

<div id="janrainEngage">
<div id="janrainEngageEmbed"></div>
</div>


</asp:Content>
