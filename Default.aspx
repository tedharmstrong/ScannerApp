<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScannerApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="**** TESTING ****" style="font-size:48px; font-weight:bolder; color:black; text-align:center;" Visible="false"></asp:Label>
        <asp:HyperLink CssClass="MenuItems" ID="hypReceive" runat="server" Text="" NavigateUrl="receive"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypMove" runat="server" Text="" NavigateUrl="move"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypProd" runat="server" Text="" NavigateUrl="prod"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypInfo" runat="server" Text="" NavigateUrl="info"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypActivate" runat="server" Text="" NavigateUrl="StartProd"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypShip" runat="server" Text="" NavigateUrl="ship"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypPhysical" runat="server" Text="" NavigateUrl="physical"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypLanguage" runat="server" Text="" NavigateUrl="language"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypDisposition" runat="server" Text="" NavigateUrl="disposition"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypProdStage" runat="server" Text="" NavigateUrl="prodstage"></asp:HyperLink>
        <asp:HyperLink CssClass="MenuItems" ID="hypLogoff" runat="server" Text="" NavigateUrl="logon"></asp:HyperLink>
        <asp:Label ID="lblResponseMessage" runat="server" Text="" CssClass="Scanresponse"></asp:Label>
    </div>

</asp:Content>
