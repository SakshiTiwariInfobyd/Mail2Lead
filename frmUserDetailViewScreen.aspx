<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmUserDetailViewScreen.aspx.cs" Inherits="AdminTool.frmUserDetailViewScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
        .style6
        {
            height: 18px;
            width: 474px;
        }
        .style7
        {
            width: 474px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:ImageButton ID="ImageGoBack1" ValidationGroup="text" runat="server" ImageUrl="~/Images/goBack.png"
                Style="height: 30px; width: 30px; vertical-align: middle; margin: 5px;" OnClick="ImageGoBack1_Click"
                align="left" />
            <asp:Label ID="lblHeader" runat="server" Text="General Account Settings" Font-Size="18"
                Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">
                <tr colspan="3">
                    <td class="style1">
                        <div id="DivExport" runat="server" style="text-align: right;">
                            <asp:Button ID="ImgViewSubject" runat="server" Text="View Subject" CssClass="btn"
                                EnableViewState="false" CausesValidation="true" ValidationGroup="Group1" OnClick="ImgViewSubject_Click"
                                Width="163px" BackColor="#3E75CD" ForeColor="White" />
                            <asp:Button ID="ImgViewLeadColumnHeader" runat="server" Text="View Lead Columns"
                                CssClass="btn" EnableViewState="false" CausesValidation="true" ValidationGroup="Group1"
                                OnClick="ImgViewLeadColumnHeader_Click" BackColor="#3E75CD" ForeColor="White" />
                            <asp:Button ID="ImgSync" runat="server" Text=" Force Sync" CssClass="btn" EnableViewState="false"
                                CausesValidation="true" ValidationGroup="Group1" 
                                OnClick="ImgTestApi_Click" BackColor="#3E75CD"
                                ForeColor="White" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <table style="align: Left; height: 176px; width: 488px; width: 520px; min-width: 520px;"
                            cellpadding="5" cellspacing="1">
                            <asp:HiddenField ID="hiddenpassword" runat="server" Value='<%# Eval("password") %>'>
                            </asp:HiddenField>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMessage" runat="server" Font-Size="15" ForeColor="Red" Style="display: none;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="lblFirstName" AssociatedControlID="tbFirstName" CssClass="col-md-8 control-label">First Name</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="tbFirstName" ValidationGroup="Group1" CssClass="form-control"
                                        BorderColor="#bbd3e9" Style="background-color: #e5eef6" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbFirstName"
                                        ValidationGroup="Group1" ErrorMessage="The field is required." />
                                </div>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="lblLastName" AssociatedControlID="tbLastName" CssClass="col-md-8 control-label">Last Name</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="tbLastName" ValidationGroup="Group1" CssClass="form-control"
                                        BorderColor="#bbd3e9" Style="background-color: #e5eef6" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbLastName"
                                        ValidationGroup="Group1" ErrorMessage="The field is required." />
                                </div>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="lblEmail" AssociatedControlID="tbEmail" CssClass="col-md-8 control-label">Email</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="tbEmail" ValidationGroup="Group1" CssClass="form-control"
                                        BorderColor="#bbd3e9" Style="background-color: #e5eef6" autocomplete="off" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail"
                                        ValidationGroup="Group1" ErrorMessage="The field is required." />
                                </div>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="lblChangePassword" AssociatedControlID="tbPassword"
                                    CssClass="col-md-8 control-label">Password</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" TextMode="Password"
                                        BorderColor="#bbd3e9" Style="background-color: #e5eef6" autocomplete="off" />
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbPassword"
                                        ValidationGroup="Group1" ErrorMessage="The field is required." />--%>
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
                                    <asp:TextBox runat="server" ID="tbConfigurationToken" ValidationGroup="Group1" CssClass="form-control"
                                        BorderColor="#bbd3e9" Style="background-color: #e5eef6" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbConfigurationToken"
                                        ValidationGroup="Group1" ErrorMessage="The field is required." />
                                </div>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="lblApiLimit" AssociatedControlID="dropdownAPiLimit"
                                    CssClass="col-md-8 control-label">API Limit</asp:Label>
                                <div class="col-md-12">
                                    <asp:DropDownList ID="dropdownAPiLimit" runat="server" BorderColor="#bbd3e9" Style="background-color: #e5eef6">
                                    </asp:DropDownList>
                                </div>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div id="UpdateDiv" visible="false" runat="server">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" EnableViewState="false"
                                            Width="125" CausesValidation="false" OnClick="btnUpdate_Click1" BackColor="#3E75CD"
                                            ForeColor="White" />
                                        <asp:Button ID="btnUpdateCancel" runat="server" Text="Cancel" CssClass="btn" Width="125"
                                            CausesValidation="true" OnClick="btnSaveCancel_Click" BackColor="#3E75CD" ForeColor="White" />
                                    </div>
                                    <div id="AddNewUser" visible="false" runat="server">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" EnableViewState="false"
                                            Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="btnSave_Click"
                                            BackColor="#3E75CD" ForeColor="White" />
                                        &nbsp;<asp:Button ID="btnSaveCancel" runat="server" Text="Cancel" CssClass="btn"
                                            Width="125" CausesValidation="true" OnClick="btnSaveCancel_Click" BackColor="#3E75CD"
                                            ForeColor="White" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
