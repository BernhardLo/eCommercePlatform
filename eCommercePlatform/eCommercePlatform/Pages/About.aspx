<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="eCommercePlatform.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div id="about" class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <h2>About Us</h2>
                <br />
                <h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</h4>
                <br />
            </div>
            <div class="col-sm-8">
                <img src="../images/Kontor.jpg" alt="" style="max-width: 100%;"/>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="litFootLinks" runat="server">
    <li><a href="../Index.aspx">Home</a></li>
    <li class="active"><a href="About.aspx">About Us</a></li>
    <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>