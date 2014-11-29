<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ManageGames.aspx.cs" Inherits="GameASU.ManageGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="GameListPanel" CssClass="panel panel-primary col-md-3" runat="server">
        <asp:Panel ID="GameListPanelHeader" CssClass="panel-heading" runat="server">Your Game List</asp:Panel>
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
            <asp:Button ID="RemoveGames" runat="server" OnClick="DeleteSelectedGames_Click" Text="Remove Selected Games" />
            <br />
            <asp:Label ID="DeleteGameMessage" runat="server"></asp:Label>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
