<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Move.aspx.cs" Inherits="ScannerApp.Move" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <apan class="toplabel">MOVE ITEMS</apan>
        <asp:TextBox ID="ScanValue" runat="server" OnTextChanged="ScanValue_TextChanged" AutoPostBack="true"></asp:TextBox>
        <%--<input type="text" id="Barcode" size="40" style="height: 50px;" onchange="ProcessScan" />--%>
        <asp:Label ID="lblResponseMessage" runat="server" Text=""></asp:Label>
        <a href="default">Home</a>
    </div>
</asp:Content>
