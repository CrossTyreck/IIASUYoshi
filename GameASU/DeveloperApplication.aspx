<%@ Page Title="Developer Application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeveloperApplication.aspx.cs" Inherits="GameASU.DeveloperApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-10">
            <section id="devApplicationForm">

                <asp:PlaceHolder runat="server" ID="devApplicationHolder">
                    <p>You're logged in as <strong><%: User.Identity.GetUserName() %></strong>.</p>
                    <div class="form-horizontal">
                        <h4>Game Developer Application</h4>
                        <hr />
                        <div class="col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:CheckBox ID="acceptTerms" text="Accept Terms" runat="server" />
                                </div>
                            <asp:Label ID="TermsLabel" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-6">
                                    <asp:Button runat="server" Text="Submit Application"  OnClick="CheckDevRole_Click" CssClass="btn btn-default" />
                                </div>
                                <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
        </div>
        </section>

     
    </div>
    </div>

</asp:Content>
