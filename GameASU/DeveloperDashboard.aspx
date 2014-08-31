<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Dashboard.Master" CodeBehind="DeveloperDashboard.aspx.cs" Inherits="GameASU.DeveloperDashboard" %>
<%@ MasterType VirtualPath="~/Dashboard.Master" %>

<asp:Content ID="DevBodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar" id="sidebar" role="navigation">
                <ul class="nav nav-sidebar">
                    <li><a href="UploadGame.aspx">Upload a game</a></li>
                    <li><a href="#">Analytics</a></li>
                    <li><a href="#">Export</a></li>
                </ul>
            </div>
            <div class="col-sm-9 col-md-10 main">
                <h1 class="page-header">Dashboard</h1>

                <div class="row placeholders">
                    <div class="col-sm-9 col-sm-offset-3 col-md-8 col-md-offset-1 main">
                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                            <!-- Indicators -->
                            <ol class="carousel-indicators">
                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                            </ol>

                            <!-- Wrapper for slides -->
                            <!-- Image content size W=600px H=400px -->
                            <div class="carousel-inner">
                                <div id="0" class="item active">
                                    <img src="Images/CrossKnight.jpg" alt="CrossKnight">
                                    <div class="carousel-caption">
                                        Cross Knight
                                    </div>
                                </div>
                                <div id="1" class="item">
                                    <img src="Images/wolverine.png" alt="Wolverine">

                                    <div class="carousel-caption">
                                        Wolverine 2
                                    </div>
                                </div>
                                <div id="2" class="item">
                                    <img src="Images/wolverine.png" alt="Wolverine">

                                    <div class="carousel-caption">
                                        Wolverine 3
                                    </div>
                                </div>
                                ...
                            </div>

                            <!-- Controls -->
                            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                            </a>
                            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right"></span>
                            </a>
                        </div>

                        <div class="row">
                            <div class="col-lg-8">
                                <h2>About ASU Gaming</h2>
                                <p>
                                    This site was created for ASU Game developers to share their games with others to receive feedback/kudos!
                                </p>
                            </div>
                            <div class="col-md-4">
                                <h2>Game Developers Wanted.</h2>
                                <p>
                                    Register/Login and get your game uploaded for play. Review feedback from users and engage in developer/player driven critiques.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>




