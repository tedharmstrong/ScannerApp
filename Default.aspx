<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScannerApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <apan class="toplabel">T.H.E.M. Automation</apan>
        <asp:HyperLink ID="hypReceive" runat="server" Text="" NavigateUrl="receive"></asp:HyperLink>
        <asp:HyperLink ID="hypMove" runat="server" Text="" NavigateUrl="move"></asp:HyperLink>
        <asp:HyperLink ID="hypProd" runat="server" Text="" NavigateUrl="prod"></asp:HyperLink>
        <asp:HyperLink ID="hypReturn" runat="server" Text="" NavigateUrl="return"></asp:HyperLink>
        <asp:HyperLink ID="hypShip" runat="server" Text="" NavigateUrl="ship"></asp:HyperLink>
        <asp:HyperLink ID="hypPhysical" runat="server" Text="" NavigateUrl="physical"></asp:HyperLink>
        <asp:HyperLink ID="hypLanguage" runat="server" Text="" NavigateUrl="language"></asp:HyperLink>
        <asp:HyperLink ID="hypDisposition" runat="server" Text="" NavigateUrl="language"></asp:HyperLink>
        <asp:HyperLink ID="hypLogoff" runat="server" Text="" NavigateUrl="logon"></asp:HyperLink>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="scanresponse"></asp:Label>
    </div>

</asp:Content>
