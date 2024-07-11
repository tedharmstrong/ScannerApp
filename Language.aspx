<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="ScannerApp.Language" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTitle" runat="server" Text="" CssClass="Scantitle"></asp:Label>
        <asp:Button ID="btnEnglish" runat="server" Text="English" CssClass="MyButton" OnClick="btnEnglish_Click" />
        <asp:Button ID="btnSpanish" runat="server" Text="Español" CssClass="MyButton" OnClick="btnSpanish_Click" />
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="Scanresponse"></asp:Label>
        <asp:HyperLink ID="hypHome" CssClass="MenuItems" runat="server" Text="Home" NavigateUrl="default"></asp:HyperLink>
    </div>
</asp:Content>


