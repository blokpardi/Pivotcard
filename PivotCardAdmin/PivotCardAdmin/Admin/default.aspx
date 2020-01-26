<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PivotCardAdmin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 91px;
        }
        .style2
        {
            width: 96px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <b>Add User<br />
    </b>
    <table style="width:100%;">
        <tr>
            <td class="style1">
                Username:
            </td>
            <b>
            <td>
                <asp:TextBox ID="tbUserName" runat="server" BackColor="#CCCCCC" 
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Pivotname:</td>
            <td>
                <asp:TextBox ID="tbPivotName" runat="server" BackColor="#CCCCCC" 
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Password:
            </td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" BackColor="#CCCCCC" 
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" AccessKey="A" onclick="Button1_Click" 
        Text="Add" />
    </b>
    <br />
&nbsp;<br />
&nbsp;<br />
    <b>Delete User</b><br />
    <table style="width:100%;">
        <tr>
            <td class="style2">
                Username:</td>
            <td>
                <asp:TextBox ID="tbUserNameDel" runat="server" BackColor="#CCCCCC" 
                    BorderStyle="None"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button2" runat="server" AccessKey="D" Text="Delete" 
        onclick="Button2_Click" />
    <br />
    <b>
    <br />
    </b>&nbsp;<asp:TextBox ID="tbError" runat="server" BorderStyle="None" 
        ForeColor="Red" Height="20px" Visible="False" Width="868px"></asp:TextBox>
    <br />
&nbsp;
</asp:Content>
