<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Physical.aspx.cs" Inherits="ScannerApp.Physical" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <apan class="toplabel">MOVE ITEMS</apan>
        <asp:Label ID="lblScanDirection" runat="server" Text="Scan Location or Item" CssClass="scandirection"></asp:Label>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true"></asp:TextBox>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="scanresponse"></asp:Label>
        <asp:HyperLink ID="hypHome" runat="server" Text="Home" NavigateUrl="default"></asp:HyperLink>
    </div>
</asp:Content>
