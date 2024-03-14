<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="ScannerApp.Language" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <apan class="toplabel">LANGUAGE CHOICE</apan>
        <asp:Button ID="btnEnglish" runat="server" Text="English" OnClick="btnEnglish_Click" />
        <asp:Button ID="btnSpanish" runat="server" Text="Español" OnClick="btnSpanish_Click" />
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="scanresponse"></asp:Label>
        <a href="default">Home</a>
    </div>
</asp:Content>


