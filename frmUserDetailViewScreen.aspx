﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmUserDetailViewScreen.aspx.cs" Inherits="AdminTool.frmUserDetailViewScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 116px;
        }
        .style2
        {
            height: 116px;
            width: 604px;
        }
        .style3
        {
            width: 604px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:Label ID="lblHeader" runat="server" Text="General Account Settings" Font-Size="18"
                Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td class="style1">
                        <asp:Button ID="ButtonGoBack" runat="server" Text="Go Back" CssClass="btn" EnableViewState="false"
                            CausesValidation="true" ValidationGroup="Group1" OnClick="ButtonGoBack_Click" />
                    </td>
                    <td colspan="2" class="style1">
                        <div id="DivExport" runat="server">
                            <asp:Button ID="ImgViewSubject" runat="server" Text="View Subject" CssClass="btn"
                                EnableViewState="false" CausesValidation="true" ValidationGroup="Group1" OnClick="ImgViewSubject_Click" />
                            <asp:Button ID="ImgViewLeadColumnHeader" runat="server" Text="View Lead Columns"
                                CssClass="btn" EnableViewState="false" CausesValidation="true" ValidationGroup="Group1"
                                OnClick="ImgViewLeadColumnHeader_Click" />
                            <asp:Button ID="ImgSync" runat="server" Text="Sync" CssClass="btn" EnableViewState="false"
                                CausesValidation="true" ValidationGroup="Group1" OnClick="ImgTestApi_Click" />
                            <asp:Button ID="ImgViewUserReport" runat="server" Text="View Report" CssClass="btn"
                                EnableViewState="false" CausesValidation="true" ValidationGroup="Group1" OnClick="ImgViewUserReport_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <div style="min-width: 550px; margin: 10px auto; padding-bottom: 30px; width: 600px;">
                            <table style="align: Left" cellpadding="5" cellspacing="1" style="width: 520px; min-width: 520px;">
                                <asp:HiddenField ID="hiddenpassword" runat="server" Value='<%# Eval("password") %>'>
                                </asp:HiddenField>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblMessage" runat="server" Font-Size="15" ForeColor="Red" Style="display: none;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblFirstName" AssociatedControlID="tbFirstName" CssClass="col-md-8 control-label">First Name</asp:Label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="tbFirstName" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbFirstName" ErrorMessage="The field is required." />
                                    </div>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblLastName" AssociatedControlID="tbLastName" CssClass="col-md-8 control-label">Last Name</asp:Label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="tbLastName" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbLastName"
                                            ErrorMessage="The field is required." />
                                    </div>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblEmail" AssociatedControlID="tbEmail" CssClass="col-md-8 control-label">Email</asp:Label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail"
                                            ErrorMessage="The field is required." />
                                    </div>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblChangePassword" AssociatedControlID="tbPassword"
                                        CssClass="col-md-8 control-label">Password</asp:Label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" TextMode="Password" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbPassword"
                                            ErrorMessage="The field is required." />
                                    </div>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblIsApproved" AssociatedControlID="chkIsApproved"
                                            CssClass="col-md-8 control-label">IsApproved</asp:Label>
                                        <asp:CheckBox runat="server" ID="chkIsApproved" />
                                    </td>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblConfigurationToken" AssociatedControlID="tbConfigurationToken"
                                        CssClass="col-md-8 control-label">CRM Token</asp:Label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="tbConfigurationToken" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbConfigurationToken"
                                            ErrorMessage="The field is required." />
                                    </div>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblApiLimit" AssociatedControlID="dropdownAPiLimit"
                                        CssClass="col-md-8 control-label">API Limit</asp:Label>
                                    <div class="col-md-12">
                                        <asp:DropDownList ID="dropdownAPiLimit" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <div id="AddNewUser" visible="false" runat="server">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" EnableViewState="false"
                                                Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="btnSave_Click" />
                                            &nbsp;<asp:Button ID="btnSaveCancel" runat="server" Text="Cancel" CssClass="btn"
                                                Width="125" CausesValidation="true" OnClick="btnSaveCancel_Click" />
                                        </div>
                                        <div id="UpdateDiv" visible="false" runat="server">
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" EnableViewState="false"
                                                Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="btnUpdate_Click1" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
