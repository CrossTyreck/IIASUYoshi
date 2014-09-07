<%@ Page Language="C#" MasterPageFile="~/PlayGame.Master" AutoEventWireup="true" CodeBehind="GameHost.aspx.cs" Inherits="GameASU.GameHost" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
  
     <p class="header"><span>Unity Web Player | </span>Space Shooter</p>
        
    <asp:Panel ID="Container" runat="server">
       
    </asp:Panel>
    
   
    </asp:Content>