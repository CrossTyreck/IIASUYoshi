<%@ Page Title="Role Membership" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleMembership.aspx.cs" Inherits="GameASU.RoleMembership" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel>
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
        </asp:Panel>
    <asp:Panel>
            <h3>Game Management</h3>
     <asp:Panel ID="GameListPanel" CssClass="panel panel-primary" runat="server">
        <asp:Panel ID="GameListPanelHeader" CssClass="panel-heading" runat="server">Game List</asp:Panel>
        <asp:Panel ID="GameListPanelResponsive" CssClass="table-responsive" runat="server">
            <asp:GridView ID="GameList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="SelectedGame" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            
            <asp:Label ID="DeleteGameMessage" runat="server"></asp:Label>
        </asp:Panel>
    </asp:Panel>
        <asp:Button ID="RemoveGames" runat="server" OnClick="DeleteSelectedGames_Click" Text="Remove Selected Games" />
        </asp:Panel>
</asp:Content>
