<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Dashboard.Master" CodeBehind="DeveloperDashboard.aspx.cs" Inherits="GameASU.DeveloperDashboard" %>

<%@ MasterType VirtualPath="~/Dashboard.Master" %>

<asp:Content ID="DevBodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar" id="sidebar" role="navigation">
                <ul class="nav nav-sidebar">
                    <li><a href="UploadGame.aspx" class="lead">Upload a game</a></li>
                </ul>
            </div>
            <div class="col-sm-9 col-md-10 main">
                <h1 class="page-header">GAMES!!!</h1>
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="width: 800px; margin: 0 auto">
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                    </ol>
                    <!-- Image content size W=800px H=400px -->
                    <div class="carousel-inner">
                        <div id="0" class="item active">
                            <img src="Images/carouselWolv1.png" alt="Wolverine1">
                        </div>
                        <div id="1" class="item">
                            <img src="Images/carouselWolv2.png" alt="Wolverine2">
                        </div>
                        <div id="2" class="item">
                            <img src="Images/carouselWolv3.png" alt="Wolverine3">
                        </div>
                    </div>
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                </div>
                <asp:Panel ID="GameList" runat="server" CssClass="container">
            </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>




