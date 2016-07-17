<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="eCommercePlatform.Controls.NavBar" %>
<nav class="navbar navbar-inverse" style="background-color: darkred; color: white;">
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/Index.aspx" style="color: white; font-size: large;">Kontorsprylar AB</a>
        </div>
        <div class="collapse navbar-collapse" id="myNavbar">
            <ul class="nav navbar-nav">
                <li><a href="#"><span class="glyphicon glyphicon-book"></span>&nbsp;&nbsp;Books</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-print"></span>&nbsp;&nbsp;Electronics</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-paperclip"></span>&nbsp;&nbsp;Supplies</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-wrench"></span>&nbsp;&nbsp;Tools</a></li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li>
                    <a data-toggle="modal" href="Index.aspx#signupModal">
                        <span class="glyphicon glyphicon-user"></span>
                        &nbsp;&nbsp;Sign Up
                    </a>
                </li>
                <li>
                    <a data-toggle="modal" href="Index.aspx#loginModal">
                        <span class="glyphicon glyphicon-log-in"></span>
                        &nbsp;&nbsp;Login
                    </a>
                </li>
                <li>
                    <a href="/Pages/Cart.aspx">
                        <span class="glyphicon glyphicon-shopping-cart"></span>
                        &nbsp;&nbsp;Cart&nbsp;
                                    <span class="badge">1</span>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</nav>
