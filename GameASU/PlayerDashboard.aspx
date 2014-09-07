<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerDashboard.aspx.cs" Inherits="GameASU.PlayerDashboard" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <h1 class="page-header">GAMES!!!</h1>

        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="width: 800px; margin: 0 auto">
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
                    <img src="Images/carouselWolv1.png" alt="Wolverine1">
                    <%--<div class="carousel-caption">
                                    </div>--%>
                </div>
                <div id="1" class="item">
                    <img src="Images/carouselWolv2.png" alt="Wolverine2">
                    <%--<div class="carousel-caption">
                                    </div>--%>
                </div>
                <div id="2" class="item">
                    <img src="Images/carouselWolv3.png" alt="Wolverine3">
                    <%--<div class="carousel-caption">
                                    </div>--%>
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

    </div>
    <div class="container">
        <div class="row top5">
            <div class="col-sm-3">
                <img class="img-responsive" src="Images/gametileexample.jpg" alt="..." />
                <p>Test</p>
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />

            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
        </div>
        <div class="row top5">
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
        </div>
        <div class="row top5">
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
            <div class="col-sm-3">
                <img class="media-object" src="Images/gametileexample.jpg" alt="..." />
            </div>
        </div>
    </div>


</asp:Content>
