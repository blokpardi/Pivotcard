<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PivotCardAdmin._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to PivotCard Administration
    </h2>
    <p>
        You must be an administrator on this system to use this service.</p>
    <p>
        If you are not an administrator, please visit <a href="http://pivotcard.com">Pivotcard</a> and set up some pivots!</p>
</asp:Content>
