﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PivotCardGen._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <style>
	#feedback { font-size: 1.4em; }
	#selectable .ui-selecting { background: #FECA40; }
	#selectable .ui-selected { background: #F39814; color: white; }
	#selectable { list-style-type: none; margin: 0; padding: 0; width: 60%; }
	#selectable li { margin: 3px; padding: 0.4em; font-size: 1.4em; height: 18px; }
	</style>
	<script>
	    $(function () {
	        $("#selectable").selectable();
	    });
	</script>



<div class="demo">

<ol id="selectable">
	<li class="ui-widget-content">Item 1</li>
	<li class="ui-widget-content">Item 2</li>
	<li class="ui-widget-content">Item 3</li>
	<li class="ui-widget-content">Item 4</li>
	<li class="ui-widget-content">Item 5</li>
	<li class="ui-widget-content">Item 6</li>
	<li class="ui-widget-content">Item 7</li>
</ol>

</div><!-- End demo -->



<div style="display: none;" class="demo-description">
<p>Enable a DOM element (or group of elements) to be selectable. Draw a box with your cursor to select items. Hold down the Ctrl key to make multiple non-adjacent selections. </p>
</div><!-- End demo-description -->

</asp:Content>
