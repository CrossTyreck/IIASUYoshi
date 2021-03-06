﻿<%@ Page Title="Upload a Unity Web Player Game" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="UploadGame.aspx.cs" Inherits="GameASU.UploadGame" %>

<asp:Content ID="DevBodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="col-md-4">
        <asp:Panel ID="UploadPanel" runat="server">
            <asp:Label ID="lblGameName" for="txtGamename" runat="server" Text="Game Name:"></asp:Label>
            <asp:TextBox ID="txtGameName" CssClass="form-control" placeholder="Enter Game Name" runat="server" Width="837px"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatortxtGameName" runat="server"
  ControlToValidate="txtGameName"
  ErrorMessage="Last name is a required field."
  ForeColor="Red">
</asp:RequiredFieldValidator>
            <p class="lead">Game&#39;s Main Camera Viewing Dimensions:</p>
            <asp:Label ID="lblWidth" for="txtWidth" runat="server" Text="Width: "></asp:Label>
            <asp:TextBox ID="txtWidth" type="number" CssClass="form-control" placeholder="Enter Width" runat="server"></asp:TextBox>
            <div class="form-group has-feedback">
                <asp:Label ID="lblHeight" for="txtHeight" CssClass="control-label" runat="server" Text="Height: "></asp:Label>
                <asp:TextBox ID="txtHeight" type="number" CssClass="form-control" placeholder="Enter Height" runat="server"></asp:TextBox>
            </div>
            <asp:Label ID="lblGameUpload" for="GameUpload" runat="server">Upload your Game!</asp:Label>
            <asp:FileUpload ID="GameUpload" runat="server" Width="389px" />
            <h3><asp:Label ID="lblFileStatus" CssClass="label label-success" runat="server"></asp:Label></h3>
            <br />
            <asp:Label ID="lblGameImageUpload" for="GameImageUpload" runat="server">Upload an image for your game! This is a tile image with dimensions 165px by 165px.</asp:Label>
            <asp:FileUpload ID="GameImageUpload" runat="server" Width="389px" />
            <h3><asp:Label ID="lblFileImageStatus" CssClass="label label-success" runat="server"></asp:Label></h3>
            <br />
            <asp:Button ID="SubmitGame" runat="server" CssClass="btn btn-primary btn-lg" Text="Upload" />
        </asp:Panel>
    </div>
</asp:Content>
