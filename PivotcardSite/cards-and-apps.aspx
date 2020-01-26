<%@ Page Title="" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="cards-and-apps.aspx.cs" Inherits="PivotcardSite.cards_and_apps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script language="javascript" type="text/javascript">
    $(document).bind("ready", function () {
        $("#promocards").fadeIn("slow");
    });
</script>
<div id="heroboxAd">
    <div id="contentContainer">
        <div style="float:left; margin:5px 0 10px 0; width:650px; font-size:16pt">Business Cards and Apps</div>
        <div style="float:left; margin:0 0 25px 0; width:640px; font-size:12pt">So you have some Pivots, now you want to do something with them, right? You've come to the right place. You can use your Pivots in a lot of different ways.</div>
        <div id="promocards" style="float:left; display:none;">
            <div id="pc1" class="promocard">
                <div class="promoheader">Use your Pivot link on business cards</div>
                <div class="promobody" style="float:left;margin:10px">
                    <img alt="Card" style="float:left;" src="images/card_sm.png" />
                    <div style="float:left; margin:11px 0px 20px 3px; font-size:10pt; width:155px">Just write in a Pivot at the end of the link and go!<br />pivotcard.com/name/<b>FB</b></div>
                    <div style="float:left; margin:10px 0px 0px 5px; font-weight:bold; font-size:11pt; width:285px">Need to order cards? Start here!</div>
                    <div style="float:left; margin:10px 0px 0px 5px; font-size:10pt; width:290px">We prefer <a style="WHITE-SPACE: nowrap" target="_blank" href="http://moo.com">Moo.com</a>, but the <a target="_blank" href="http://www.bing.com/search?q=business+card+printing">choice</a> is yours.</div>
                </div>
            </div>
            <div id="pc2" class="promocard">
                <div class="promoheader">Use the Pivotcard App</div>
                
                <div class="promobody" style="position:relative;float:left;">
                    <div id="promomask" style="position:absolute; width:100%; height:170px; top:0; left:0; z-index:8000; background-color:#000; opacity: 0.3"></div>
                    <div style="position:absolute; left:35px; top:50px;z-index:9000; -webkit-transform: rotate(-25deg);	-moz-transform: rotate(-25deg); -ms-transform: rotate(-25deg);-o-transform: rotate(-25deg);transform: rotate(-25deg); color:#ffffff; font-weight:bold;font-size:30pt">Coming Soon</div>
                    <img alt="Card" style="float:left; margin:-5px 0 0px 65px" src="images/phone_sm.png" />
                    <div style="float:left;width:300px; margin-left:10px; font-size:10pt;">Get the iPhone, Android or Windows Phone app, and have all your Pivots ready anytime!</div>
                </div>
            </div>
            <div id="pc3" class="promocard">
                <div class="promoheader">Use the Pivotcard website</div>
                <div class="promobody" style="float:left;">
                    <img alt="Card" style="float:left; margin:20px 0px 0px 10px" src="images/computer_sm.png" />
                    <div style="float:left;width:135px; margin-top:35px; font-size:10pt;">Create and edit your Pivots and connect to your social networks.</div>
                </div>
            </div>
            <div id="pc4" class="promocard">
                <div class="promoheader">Use anywhere!</div>
                <div class="promobody" style="float:left; margin:10px">
                    <div style="float:left;width:300px; margin-top:5px; margin-bottom:10px; font-size:11pt;">Use your Pivotcard links wherever convenient.</div>
                    <ul style="font-size:10pt; margin-top:25px;">
                        <li>Write them on existing business cards</li>
                        <li>Include as part of your email signature</li>
                        <li>Add to travel and luggage tags</li>
                        <li>Write one on a cocktai napkin</li>
                    </ul>
                    <div style="float:left;width:300px; margin-top:5px; margin-bottom:10px; font-size:11pt;">Create as many as you need, we don't mind.</div>
                </div>
            </div>
            </div>
          </div>
    </div>
    <div id="adbox" style="margin-left:10px;float:left;">
    <script type="text/javascript"><!--
        google_ad_client = "ca-pub-6589940799022935";
        /* Pivotcard_c&amp;a_side */
        google_ad_slot = "9386248087";
        google_ad_width = 160;
        google_ad_height = 600;
        //-->
        </script>
        <script type="text/javascript"
        src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>
    </div>
</asp:Content>
