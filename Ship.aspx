<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ship.aspx.cs" Inherits="ScannerApp.Ship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTitle" runat="server" Text="" CssClass="Scantitle"></asp:Label>
        <asp:Label ID="lblScanDirection" runat="server" Text="Scan Location or Item" CssClass="Scanresponse"></asp:Label>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true" CssClass="MyTextBox"></asp:TextBox>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="Scanresponse"></asp:Label>
        <asp:TextBox ID="txtLocation" runat="server" Visible="false" CssClass="MyTextBox"></asp:TextBox>
        <asp:TextBox ID="txtWorkOrder" runat="server" Visible="false" CssClass="MyTextBox"></asp:TextBox>
        <asp:Button ID="btn1" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btn1_Click" />
        <asp:Button ID="btn2" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btn2_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btnSubmit_Click" />
        <asp:HyperLink ID="hypHome" CssClass="MenuItems" runat="server" Text="Home" NavigateUrl="default"></asp:HyperLink>
    </div>
</asp:Content>
