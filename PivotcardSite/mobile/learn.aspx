<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/pcmobile.Master" AutoEventWireup="true" CodeBehind="learn.aspx.cs" Inherits="PivotcardSite.mobile.learn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script type="text/javascript" src="scripts/mobilecontentfader.js"></script>
<link rel="stylesheet" type="text/css" href="stylesheets/mobilecontentfader.css" />

<script type="text/javascript" language="javascript">
    featuredcontentglider.init({
        gliderid: "gliderbox", //ID of main glider container
        contentclass: "glidecontent", //Shared CSS class name of each glider content
        togglerid: "p-select", //ID of toggler container
        remotecontent: "", //Get gliding contents from external file on server? "filename" or "" to disable
        selected: 0, //Default selected content index (0=1st)
        persiststate: false, //Remember last content shown within browser session (true/false)?
        speed: 1000, //Glide animation duration (in milliseconds)
        direction: "rightleft", //set direction of glide: "updown", "downup", "leftright", or "rightleft"
        autorotate: true, //Auto rotate contents (true/false)?
        autorotateconfig: [5000, 2] //if auto rotate enabled, set [milliseconds_btw_rotations, cycles_before_stopping]
    })

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-27994758-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>

<div id="bodyContent">
    <%--<div style="width:100%;float:left; text-align:center; margin:10px auto 5px auto;"><img alt="logo" style="margin-right:7px" src="images/pc_logo_136x49.jpg"  /></div>--%>
    
    <div id="gliderbox" class="glidecontentwrapper" style="text-align:center; width:100%;">

    <div class="glidecontent" >
        <img alt="" src="images/learn_mobile_p1.jpg" />
    </div>

    <div class="glidecontent" >
        <img alt="" src="images/learn_mobile_p2.jpg" />
    </div>
    
    <div class="glidecontent" >
     <img alt="" src="images/learn_mobile_p3.jpg" />
    </div>
     
    <div id="p-select" class="glidecontenttoggler">
    <a href="#" class="toc">&nbsp;</a> <a href="#" class="toc">&nbsp;</a> <a href="#" class="toc">&nbsp;</a>
    </div>
    </div>
</div>

</asp:Content>
