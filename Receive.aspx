<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receive.aspx.cs" Inherits="ScannerApp.Receive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTitle" runat="server" Text="" CssClass="Scantitle"></asp:Label>
        <asp:Label ID="lblScanDirection" runat="server" Text="Scan Location or Item" CssClass="Scanresponse"></asp:Label>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true" CssClass="MyTextBox"></asp:TextBox>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="Scanresponse"></asp:Label>
        <asp:TextBox ID="Quantity" runat="server" AutoPostBack="false" Visible="false" CssClass="MyTextBox"></asp:TextBox>
        <asp:RegularExpressionValidator ID='vldQuantity' ControlToValidate='Quantity' Display='Dynamic' ErrorMessage='Not a number' ValidationExpression='(^([0-9]*|\d*\d{1}?\d*)$)' Runat='server'>
        </asp:RegularExpressionValidator>
        <asp:Button ID="btn1" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btn1_Click" />
        <asp:Button ID="btn2" runat="server" Text="" CssClass="MyButton" Visible="false" OnClick="btn2_Click" />
        <asp:Button ID="btnSendQty" runat="server" Text="Save Quantity" CssClass="MyButton" Visible="false" OnClick="btnSendQty_Click" />
        <asp:HyperLink ID="hypHome" CssClass="MenuItems" runat="server" Text="Home" NavigateUrl="default"></asp:HyperLink>
    </div>
</asp:Content>
