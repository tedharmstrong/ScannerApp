<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="ScannerApp.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTitle" runat="server" Text="LOGON" CssClass="toplabel"></asp:Label>
        <asp:Label ID="lblScanDirection" runat="server" Text="Scan Your User Tag" CssClass="scandirection"></asp:Label>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true"></asp:TextBox>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="scanresponse"></asp:Label>
    </div>
</asp:Content>
