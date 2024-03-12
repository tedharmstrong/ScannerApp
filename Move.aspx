<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Move.aspx.cs" Inherits="ScannerApp.Move" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <apan class="toplabel">MOVE ITEMS</apan>
        <asp:Label ID="lblScanDirection" runat="server" Text="Scan Location or Item" CssClass="scandirection"></asp:Label>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true"></asp:TextBox>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="scanresponse"></asp:Label>
        <a href="default">Home</a>
    </div>
</asp:Content>
