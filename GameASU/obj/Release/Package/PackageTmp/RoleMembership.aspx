<%@ Page Title="Role Membership" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleMembership.aspx.cs" Inherits="GameASU.RoleMembership" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3>Role Membership</h3>
  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />
  <table cellpadding="3" border="0">
    <tr>
      <td valign="top">Roles:</td>
      <td valign="top"><asp:ListBox id="RolesListBox" runat="server" Rows="8" /></td>
      <td valign="top">Users:</td>
      <td valign="top"><asp:ListBox id="UsersListBox" DataTextField="Username" 
                                  Rows="8" runat="server" /></td>
      <td valign="top"><asp:Button Text="Add User to Role" id="AddUserButton"
                                 runat="server" OnClick="AddUser_OnClick" /></td>
        <td valign="top"><asp:Button Text="Remove User from Role" id="RemoveUserButton"
                                 runat="server" OnClick="RemoveUser_OnClick" /></td>
    </tr>
  </table>
</asp:Content>
