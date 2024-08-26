<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Physical.aspx.cs" Inherits="ScannerApp.Physical" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTitle" runat="server" Text="" CssClass="Scantitle"></asp:Label>
        <asp:Label ID="lblScanDirection" runat="server" Text="Scan Location or Item" CssClass="Scanresponse"></asp:Label>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true" CssClass="MyTextBox"></asp:TextBox>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="Scanresponse"></asp:Label>
        <asp:Button ID="btn1" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btn1_Click" />
        <asp:Button ID="btn2" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btn2_Click" />
        <asp:HyperLink ID="hypHome" CssClass="mainMenu" runat="server" Text="Home" NavigateUrl="default"></asp:HyperLink>
    </div>
</asp:Content>
