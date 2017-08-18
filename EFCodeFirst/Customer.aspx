<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="EFCodeFirst.Customer" MasterPageFile="~/Master.Master" %>

<asp:Content ID="PageHeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="PageMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="col-md-6">
            <div class="form-group">
                <div class="control-label col-md-4">
                    First Name
                </div>
                <div class="col-md-8">
                    <asp:HiddenField ID="hdnCustomerID" runat="server" Value="0" />
                    <asp:TextBox ID="txtFirstName" runat="server" TabIndex="1" MaxLength="50" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Birth Date
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtBirthDate" runat="server" TabIndex="3" MaxLength="10" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Not a valid date, shoud be in DD/MM/YYYY" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$" CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Address
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAddress" runat="server" TabIndex="5" MaxLength="100" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

        </div>

        <div class="col-md-6">
            <div class="form-group">
                <div class="control-label col-md-4">
                    Last Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtLastName" runat="server" TabIndex="2" MaxLength="50" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Email
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="4" MaxLength="320" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Not a valid email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-8">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="vgSave" TabIndex="7" CssClass="btn btn-success" />
                            <a id="btnCancel" class="col-md-offset-2 btn btn-primary" tabindex="8">Cancel</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                </div>
            </div>
        </div>
    </div>

    <div id="divGrid" runat="server" class="table-responsive">
        <asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" OnRowCommand="grdCustomer_RowCommand" OnRowDataBound="grdCustomer_RowDataBound" OnSelectedIndexChanged="grdCustomer_SelectedIndexChanged" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary">
            <Columns>
                <asp:TemplateField HeaderText="First Name">
                    <AlternatingItemTemplate>
                        <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%# Bind("CustomerID") %>' />
                        <asp:LinkButton ID="lnkFirstName" runat="server" Text='<%# Bind("FirstName") %>' CommandName="SELECT"></asp:LinkButton>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%# Bind("CustomerID") %>' />
                        <asp:LinkButton ID="lnkFirstName" runat="server" Text='<%# Bind("FirstName") %>' CommandName="SELECT"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Birth Date">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Bind("BirthDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Bind("BirthDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit | Delete">
                    <AlternatingItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="EDT" Text="Edit"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="DLT" Text="Delete"></asp:LinkButton>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="EDT" Text="Edit"></asp:LinkButton>
                        | 
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="DLT" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div id="divNoRecords" runat="server" class="show alert alert-danger fade in">
        <strong>Sorry! </strong>No Record(s) found.
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#aCustomer').parent().addClass('active');

            $('#<%=txtFirstName.ClientID%>').focus();
            $('#btnCancel').click(function () {
                $('#<%=txtFirstName.ClientID%>').focus();
                $('#<%=hdnCustomerID.ClientID%>').val('0');
                $('#<%=txtFirstName.ClientID%>').val('');
                $('#<%=txtLastName.ClientID%>').val('');
                $('#<%=txtBirthDate.ClientID%>').val('');
                $('#<%=txtEmail.ClientID%>').val('');
                $('#<%=txtAddress.ClientID%>').val('');
            });
        });
    </script>
</asp:Content>

