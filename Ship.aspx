<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ship.aspx.cs" Inherits="ScannerApp.Ship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <apan class="toplabel">SHIPPING FINISHED GOODS</apan>
        <input type="text" id="Barcode" size="40" style="height: 50px;" oninput="try2()" />
        <div id="response-message" style="font-size:60px"></div>
        <a href="default">Home</a>
    </div>
</asp:Content>
