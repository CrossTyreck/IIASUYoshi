<%@ Page Language="C#" MasterPageFile="~/PlayGame.Master" AutoEventWireup="true" CodeBehind="GameHost.aspx.cs" Inherits="GameASU.GameHost" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
  

     <asp:Label ID="GameNameHeader" runat="server" CssClass="headers"></asp:Label>
        
    <asp:Panel ID="Container" runat="server">
        
    </asp:Panel>
    <asp:Label ID="ClickPlay" runat="server">CLICK GAME TO PLAY!</asp:Label>
   
    </asp:Content>