<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="eCommercePlatform.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

    <h1 style="text-align: center">Välkommen! </h1>
    <table class="table table-condensed">
        <thead>
            <tr>
                <th>&nbsp;</th>
                <th>&nbsp;</th>
                <th>&nbsp;</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="productsLit" runat="server"></asp:Literal>
        </tbody>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="litFootLinks" runat="server">
    <li class="active"><a href="Index.aspx">Home</a></li>
    <li><a href="Pages/About.aspx">About Us</a></li>
    <li><a href="Pages/ContactUs.aspx">Contact Us</a></li>
</asp:Content>
