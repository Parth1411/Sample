<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="WebForms.CustomerDetails" MasterPageFile="~/Master.Master" %>

<asp:Content ID="PageHeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="PageMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6">
        <div class="form-horizontal">
            <div class="form-group">
                <div id="divNoRecord" runat="server" class="hide">
                    <div class="alert alert-danger fade in">
                        <strong>Sorry!</strong> Record(s) not found.
                    </div>
                </div>
                <div id="divResult" runat="server" class="hide">
                    <ul class="list-group">
                        <li class="list-group-item active">
                            <strong class="padRight10">Customer Details</strong>
                        </li>
                        <li class="list-group-item">
                            <asp:HiddenField ID="hdnCustomerID" runat="server" />
                            <strong class="padRight10">First Name</strong><asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <strong class="padRight10">Last Name</strong><asp:Label ID="lblLastName" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <strong class="padRight10">Birth Date</strong><asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <strong class="padRight10">Email</strong><asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <strong class="padRight10">Address</strong><asp:Label ID="lblAddress" runat="server"></asp:Label>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
