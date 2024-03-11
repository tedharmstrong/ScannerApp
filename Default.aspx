<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScannerApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
                <div class="row" style="padding-bottom:15px; text-align:center">
                    <div class="col-xs-12">
                        <apan class="toplabel">Welcome to THEM Automation!</apan>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <a href="move">Move Items</a>
                    </div>
                    <div class="col-xs-6">
                        <a href="prod">Finished Goods Production</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <a href="return">Return Materials</a>
                    </div>
                    <div class="col-xs-6">
                        <a href="ship">Shipping Finished Goods</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <a href="physical">Physical Inventory</a>
                    </div>
                    <div class="col-xs-6">
                        <a href="language">Language Choice</a>
                    </div>
                </div>
        </div>

</asp:Content>
