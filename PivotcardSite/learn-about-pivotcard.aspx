<%@ Page Title="Learn about Pivotcard" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="learn-about-pivotcard.aspx.cs" Inherits="PivotcardSite.learn_about_pivotcard" %>
<asp:Content ID="maincontent" ContentPlaceHolderID="main" runat="server">
<script type="text/javascript" src="scripts/fadingcontentglider.js"></script>
<link rel="stylesheet" type="text/css" href="stylesheets/featuredcontentglider.css" />
<script type="text/javascript">

    featuredcontentglider.init({
        gliderid: "herobox", //ID of main glider container
        contentclass: "glidecontent", //Shared CSS class name of each glider content
        togglerid: "p-select", //ID of toggler container
        remotecontent: "", //Get gliding contents from external file on server? "filename" or "" to disable
        selected: 0, //Default selected content index (0=1st)
        persiststate: false, //Remember last content shown within browser session (true/false)?
        speed: 1000, //Glide animation duration (in milliseconds)
        direction: "rightleft", //set direction of glide: "updown", "downup", "leftright", or "rightleft"
        autorotate: true, //Auto rotate contents (true/false)?
        autorotateconfig: [7000, 2] //if auto rotate enabled, set [milliseconds_btw_rotations, cycles_before_stopping]
    })

   </script>

    <div id="herobox" class="glidecontentwrapper" style="height:510px">

    <div class="glidecontent" >
        <div class="bluefield" style="float:left; width:890px; height:110px;"><div style="margin:10px 10px 10px 10px;">Many of us have several online "identities" we use <br />for both work and play.</div></div>
        <div style="width:890px; float:left; padding-top:20px; text-align:center"><img alt="Logos" src="images/logos.png" /></div>
    </div>

    <div class="glidecontent" >
        <div style="float:left; width:890px; height:110px;"><div style="font-size:22pt;text-align:center; margin:10px 10px 10px 10px;">Each contact may need to know something specific about you <br /> so you want to make sure you give them the right information.</div></div>
        <div style="float:left"><img alt="Collage" src="images/collage_2.png" /></div><div class="bluefield" style="float:left; width:410px; height:350px;"><div style=" text-align:left;margin:100px 10px 10px 50px;">And business cards are great, but haven't been a "one size fits all" solution.</div></div>
    </div>
    
    <div class="glidecontent" >
        <div class="bluefield" style="float:left; width:890px; height:110px;"><div style="margin:10px 10px 10px 10px;">Welcome to Pivotcard. Share only the <i>you</i> they <br /> need to see. It’s simple and flexible.</div></div>
        <div style="width:890px; float:left; padding-top:20px; text-align:center"><img alt="Logos" src="images/steps.png" /></div>
        <div style="float:left; width:890px; height:96px;"><div style="font-size:22pt;text-align:center; margin:10px 10px 10px 10px;">All your contacts sees is the identity you chose!</div></div>
        <div class="bluefield" style="float:left; width:890px; height:75px;"></div>
    </div>

    <div class="glidecontent" >
            <div style="float:left; width:890px; height:75px;"><div style="font-size:22pt;text-align:center; margin:10px 10px 10px 10px;">Use Pivotcard everywhere!</div></div>
            <div class="bluefield" style="float:left; width:890px; height:350px;">
                <div style="width:890px; float:left; padding-top:30px; text-align:center"><img alt="Logos" src="images/devices.png" /></div>
                <div style="float:left; margin:30px 10px 10px 55px;">
                      <div style="font-size:16pt; float:left; margin:10px 10px 10px 10px;">Use on a business card</div>
                    <div style="font-size:16pt; float:left; margin:10px 10px 10px 70px;">Get the Pivotcard app</div>
                    <div style="font-size:16pt; float:left; margin:10px 10px 10px 45px;">Use the Pivotcard website</div>
                </div>
            </div>    
     </div>
     
    <div id="p-select" class="glidecontenttoggler">
    <%--<a href="#" class="prev">Prev</a> --%>
    <%--<svg version="1.1" xmlns="http://www.w3.org/2000/svg"><a xlink:href="#"><circle fill="orange" stroke="black" stroke-width="3" cx="40" cy="25" r="20"/></a></svg>--%>
    <a href="#" class="toc">&nbsp;</a> <a href="#" class="toc">&nbsp;</a> <a href="#" class="toc">&nbsp;</a> <a href="#" class="toc">&nbsp;</a>
    <%--<a href="#" class="next">Next</a>--%>
    </div>
    </div>
    
</asp:Content>
