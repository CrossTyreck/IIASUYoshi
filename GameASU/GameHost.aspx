<%@ Page Language="C#" MasterPageFile="~/PlayGame.Master" AutoEventWireup="true" CodeBehind="GameHost.aspx.cs" Inherits="GameASU.GameHost" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
  
     <p class="header"><span>Unity Web Player | </span>Space Shooter</p>
        
    <asp:Panel ID="Container" runat="server">
         <%--Used to test before dynamically creating in code behind
             <div id="Space_Shooter">
            <a href="#Space_Shooter">
                <img alt="No image submitted"
                    src="Images/wolverine.png"
                    onclick="javascript:LoadUnityAfterClick('https://gameasublob.blob.core.windows.net/games/Space_Shooter.unity3d', '375', '750', 'Space_Shooter')" />
            </a>
        </div>--%>
    </asp:Panel>
    
   
    </asp:Content>