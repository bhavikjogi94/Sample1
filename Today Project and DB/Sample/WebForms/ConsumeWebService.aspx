﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumeWebService.aspx.cs" Inherits="WebForms.ConsumeWebService" MasterPageFile="~/Master.Master" %>

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
                    Email
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="5" MaxLength="320" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Not a valid email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Country
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" TabIndex="7" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Required" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Active
                </div>
                <div class="col-margin-left-3 col-md-6">
                    <div class="checkbox">
                        <asp:CheckBox ID="chkIsActive" runat="server" TabIndex="9" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-4 col-md-6">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="vgSave" TabIndex="10" CssClass="btn btn-success" />
                    <a id="btnCancel" class="col-md-offset-2 btn btn-primary" tabindex="11">Cancel</a>
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
                    Phone
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtPhone" runat="server" TabIndex="4" MaxLength="25" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Not a valid phone#" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$" CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Address
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAddress" runat="server" TabIndex="6" MaxLength="100" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label col-md-4">
                    Province
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlProvince" runat="server" TabIndex="8" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqProvince" runat="server" ControlToValidate="ddlProvince" ErrorMessage="Required" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgSave" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

        </div>
    </div>

    <div id="divGrid" runat="server">
        <asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" OnRowCommand="grdCustomer_RowCommand" OnRowDataBound="grdCustomer_RowDataBound" OnSelectedIndexChanged="grdCustomer_SelectedIndexChanged" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary">
            <Columns>
                <asp:TemplateField>
                    <AlternatingItemTemplate>
                        <asp:CheckBox ID="chkItem" runat="server" />
                        <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%# Bind("CustomerID") %>' />
                    </AlternatingItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkHeader" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkItem" runat="server" />
                        <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%# Bind("CustomerID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <AlternatingItemTemplate>
                        <asp:LinkButton ID="lnkFirstName" runat="server" Text='<%# Bind("FirstName") %>' CommandName="SELECT"></asp:LinkButton>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
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
                <asp:TemplateField HeaderText="Phone">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="Province">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                        <asp:HiddenField ID="hdnProvinceID" runat="server" Value='<%# Bind("ProvinceID") %>' />
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                        <asp:HiddenField ID="hdnProvinceID" runat="server" Value='<%# Bind("ProvinceID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                        <asp:HiddenField ID="hdnCountryID" runat="server" Value='<%# Bind("CountryID") %>' />
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                        <asp:HiddenField ID="hdnCountryID" runat="server" Value='<%# Bind("CountryID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Active">
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Bind("IsActive") %>'></asp:Label>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Bind("IsActive") %>'></asp:Label>
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
        function GetCustomerByIDByAjax() {
            $.ajax({
                url: 'http://localhost:63976/CustomerService.asmx/GetCustomerByIDByAjax',
                type: 'POST',
                //headers: { "Access-Control-Allow-Origin": "*" },
                //contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: { id: '1' },
                success: function (data) {
                    alert(JSON.stringify(data));
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    alert(xmlHttpRequest.responseText);
                    alert(textStatus);
                    alert(errorThrown);
                }
            });
        }

        $(document).ready(function () {
            $('#<%=txtFirstName.ClientID%>').focus();
            //GetCustomerByIDByAjax();
            $('#btnCancel').click(function () {
                $('#<%=hdnCustomerID.ClientID%>').val('0');
                $('#<%=txtFirstName.ClientID%>').val('');
                $('#<%=txtLastName.ClientID%>').val('');
                $('#<%=txtBirthDate.ClientID%>').val('');
                $('#<%=txtPhone.ClientID%>').val('');
                $('#<%=txtEmail.ClientID%>').val('');
                $('#<%=txtAddress.ClientID%>').val('');
                $('#<%=ddlProvince.ClientID%>').val('0');
                $('#<%=ddlCountry.ClientID%>').val('0');
                $('#<%=chkIsActive.ClientID%>').prop('checked', false);
            });
            $('#grdStudent_chkHeader').click(
                function () {
                    if ($(this).is(':checked')) {
                        $('input[id*="grdStudent_chkItem"]:checkbox').each(
                            function () {
                                $(this).prop('checked', true);
                            });
                    }
                    else {
                        $('input[id*="grdStudent_chkItem"]:checkbox').each(
                            function () {
                                $(this).prop('checked', false);
                            });
                    }
                });
            $('input[id*="grdStudent_chkItem"]:checkbox').click(
                function () {
                    if ($(this).is(':checked') == false) {
                        $('#grdStudent_chkHeader').prop('checked', false);
                    }
                    else {
                        if ($('input[id*="grdStudent_chkItem"]:checkbox').length == $('input[id*="grdStudent_chkItem"]:checkbox:checked').length) {
                            $('#grdStudent_chkHeader').prop('checked', true);
                        }
                    }
                });
        });
    </script>
</asp:Content>
