<%@ Page Title="My Pivots" Language="C#" MasterPageFile="~/PCM.Master" AutoEventWireup="true" CodeBehind="my-pivots.aspx.cs" Inherits="PivotcardSite.my_pivots" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js" type="text/javascript" language="javascript"></script>
<%--<script type="text/javascript" language="javascript" src="http://jquery.bassistance.de/validate/jquery.validate.js"></script>--%>
<script type="text/javascript" src="scripts/my-pivots.js"></script>

<div id="heroboxNarrow">
    <div id="noCardContainer">You haven't created any Pivots yet. Let's get <a href="#" name="modal" id="createCard">started</a>!</div>
    <div id="cardContainer" style="float:left; display:none">
        <div id="myTitleContainer">
            <div class="myTitleName">Pivots for&nbsp;</div><div class="myTitleName" id="myTitleName"></div>
            <div class="myTitleLink" style="margin-left:22px;">Pivotcard link: http://www.pivotcard.com/ </div><div class="myTitleLink" id="myTitleLink">/</div>
            <a href="#" name="modal" id="myTitleAdd">Add new Pivot</a>
        </div>
        <div id="myCardContainer">
   
        </div>
        <div id="nscontain">
            <div id="nextstep">
                <div id="nowwhat" class="whitebluefield">Ok, I have a Pivot. Now what?</div>
            </div>
        </div>
    </div>
</div>


<div id="editDialog">
<div id="typeButtons"><div class="typeButton" id="shortcut">Shortcut</div><div class="typeButton" id="pivotpage">Pivotpage</div></div>

<div id="shortcutPage" class="typePage">
    
    <div style="float:left; margin: 30px auto 20px auto; width:100%; font-size:12pt; text-align:center;">Create a shortcut to any web address and use it with your Pivotcard link</div>
     <div class="shortcutInput" >   
        <span class="labelText">Pivot shortcut</span>
        <input type="text" id="pivotCodeInput" name="pivotCodeInput" maxlength="10" class="pcValidate"  style="float:left; width:200px"/>
        <span class="exampleText">(e.g. FB or # or 123)</span>
        <div id="pcInputError" class="errorText"></div>
        <br /><br />
        <span name="urlBox" class="labelText">Web Address</span>
        <input type="text" id="pivotUrlInput" name="pivotUrlInput" class="pcValidate" style="width:200px"/>
        <span class="exampleText">(e.g. http://twitter.com/yourname)</span>
        <div id="puInputError" class="errorText"></div>
        <br /><br />
        <span class="labelText">Set as default</span><input id="pivotDefaultInput" style="margin-top:3px" type='checkbox'/>
     
        <div style="float:left; padding-left:30px; width:100%; margin-top:15px;  margin-bottom:25px; font-size:14pt; color:#434343;"><div style="float:left">This Pivot is: http://pivotcard.com/ </div><div id="pivotEditLink" style="float:left;"></div></div>
        <div class="editButtons"><div style="float:left; margin-left:170px" class="save">Save</div><div style="float:left; margin-left:170px" class="cancel">Cancel</div></div>

     </div>
</div>

<div id="pivotPagePage" class="typePage">
    <div style="float:left; margin: 30px auto 15px auto; width:100%; font-size:12pt; text-align:center;">Add HTML to create your own page on Pivotcard</div>
    <div class="shortcutInput">
        <span class="labelText">Pivot shortcut</span>
        <input id="pivotPageCodeInput" type="text" class="ppValidate" style="float:left; width:200px"/>
        <div id="ppcInputError" class="errorText"></div>
        <span class="exampleText">(e.g. FB or # or 123)</span>
        <br /><br />
        <span name="urlBox" class="labelText" style="margin-right:50px">HTML</span>
        <br />
        <textarea id="pivotPageHTMLInput" cols="0" rows="0" class="ppValidate" style="margin-left:0px; width:475px; height:100px"></textarea>
        <div id="pphInputError" class="errorText"></div>
        <div class="editButtons" style="margin-top:10px;"><div style="float:left; margin-left:170px" class="save">Save</div><div style="float:left; margin-left:170px" class="cancel">Cancel</div></div>
     </div>

</div>
<input type="text" id="pivotIdInput" style="float:left; width:0px; visibility:hidden"/>
<!--<div class="editButtons"><div style="float:left; margin-left:170px" class="save">Save</div><div style="float:left; margin-left:170px" class="cancel">Cancel</div></div>-->
</div>

<!--Delete confirmation box-->
<div id="dialog-confirm" style="display:none" title="Are you sure?">
	<p><span class="ui-icon ui-icon-alert" style="float:left; margin:5px 7px 20px 0;"></span>Delete this Pivot?</p>
</div>

<!-- Box that performs the animation -->
<div id="animbox" class="animbox"></div>

<!-- Mask to cover the whole screen -->
  <div id="mask"></div>

</asp:Content>
