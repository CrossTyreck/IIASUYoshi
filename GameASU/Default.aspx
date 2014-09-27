<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameASU._Default" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASU Gaming</h1>
        <p class="lead">Welcome to the only website dedicated to Arizona State University's Ira Fulton School of Engineering Game Design students!</p>
        <p><a href="" class="btn btn-primary btn-lg">Interested in Game Development? &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>About ASU Gaming</h2>
            <p>
                This site was created for ASU Game developers to share their games with others to receive feedback/kudos!
            </p>
            <%--<p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>--%>
        </div>
        <div class="col-md-4">
            <h2>Game Developers Wanted.</h2>
            <p>
                Register/Login and get your game uploaded for play. Review feedback from users and engage in developer/player driven critiques.
            </p>
           <%-- <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>--%>
        </div>
        <div class="col-md-4">
            <h2>Lets Play!</h2>
            <p>
                Want to play a game? Register/Login to browse through games hosted on this site. 
            </p>
            <p>
                Remember to download the Unity WebPlayer plugin. 
            </p>
            <p>
                <a class="btn btn-default" href="http://webplayer.unity3d.com/download_webplayer-3.x/UnityWebPlayer.exe">Unity WebPlayer Plugin Windows &raquo;</a>
                <a class="btn btn-default" href="http://webplayer.unity3d.com/download_webplayer-3.x/webplayer-mini.dmg">Unity WebPlayer Plugin Mac &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
