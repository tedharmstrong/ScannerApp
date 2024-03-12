<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="ScannerApp.Language" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <apan class="toplabel">LANGUAGE CHOICE</apan>
        <asp:RadioButtonList ID="radLanguage" runat="server" CssClass="radiobuttons" OnSelectedIndexChanged="radLanguage_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text ="English" Value="EN" />
            <asp:ListItem Text ="Spanish" Value="SP" />
        </asp:RadioButtonList>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="scanresponse"></asp:Label>
        <a href="default">Home</a>
    </div>
</asp:Content>

