﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUserList.aspx.cs" Inherits="AdminTool.frmUserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style>
        .ListRowGrid {
            border-bottom: 10px #fff solid;
            background-color: #efefef;
            Height: 50px;
            margin-left: 10px;
        }

            .ListRowGrid td {
                padding-left: 15px;
            }

        .ListHeaderGrid {
            background-color: #FFFFFF;
            height: 50px;
        }

            .ListHeaderGrid th {
                padding-left: 15px;
            }
    </style>
    <script type="text/javascript">

        function onlyAlphabets(e, t) {
            try {
                var msg = document.getElementById("<%= emptyListMsg.ClientID %>");
                msg.style.color = "Red";
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32)) {
                    $(msg).text("");
                    return true;
                }
                else {
                    $(msg).text("Invalid Name>");
                    return false;
                }
            }
            catch (err) {
                alert(err.Description);
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:Label ID="lblHeader" runat="server" Text="Manage Users" Font-Size="18" Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">

                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                    <td align="right">
                        <div>
                            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
                                <asp:TextBox ID="txtSearchBox" placeholder="Search here" runat="server" Style="padding-left: 20px; padding-right: 20px; width: 200px; height: 25px;" Width="150px" MaxLength="50" CssClass="form-control" />
                                <asp:ImageButton ID="btnSearch" ValidationGroup="text" runat="server" ImageUrl="~/Images/search_User.png" Style="height: 30px; width: 30px; vertical-align: middle; display: none;" OnClientClick="if(!ValidateSearch()) return false;" OnClick="btnSearch_Click" />
                                <asp:HiddenField ID="hdnSearchTxt" runat="server" />
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td colspan="2" align="right">
                        <div id="DivExport" runat="server">
                            <asp:Button runat="server" ID="ImgAddNewUser" Text="Add New User" OnClick="ImgAddNewUser_Click1" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                            <asp:Button runat="server" ID="ImgExportToExcel" Text="Export EXCEL" OnClick="ImgExportToExcel_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                            <asp:Button runat="server" ID="ImgExportToCSV" Text="Export CSV" OnClick="ImgExportToCSV_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                            <asp:Button runat="server" ID="ImgExportToPDF" Text="Export PDF" OnClick="ImgExportToPDF_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                        </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <br />
                        <div id="GroupDetails" runat="server" width="100%">
                            <asp:GridView ID="GridUserDetails" runat="server" Width="100%" AllowPaging="True" OnPageIndexChanging="GridUserDetails_PageIndexChanging" AutoGenerateColumns="False" GridLines="None" DataKeyNames="Id" OnRowEditing="GridUserDetails_RowEditing"
                                OnRowDeleting="GridUserDetails_RowDeleting" OnRowCancelingEdit="GridUserDetails_RowCancelingEdit" OnRowUpdating="GridUserDetails_RowUpdating"
                                OnRowDataBound="GridUserDetails_RowDataBound">
                                <HeaderStyle CssClass="ListHeaderGrid" HorizontalAlign="Left" />
                                <RowStyle CssClass="ListRowGrid" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" Height="40" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>S No.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hiddenIsApproved" runat="server" Value='<%# Eval("isApproved") %>'></asp:HiddenField>
                                            <asp:HiddenField ID="hiddenUserId" runat="server" Value='<%# Eval("id") %>'></asp:HiddenField>
                                            <asp:HiddenField ID="hiddenPassword" runat="server" Value='<%# Eval("password") %>'></asp:HiddenField>
                                            <asp:HiddenField ID="hiddenAPIlimit" runat="server" Value='<%# Eval("apiLimit") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Email Id
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmailId" runat="server" Text='<%# Eval("emailId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbEmailId" runat="server" Text='<%# Eval("emailId") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEmailId" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            First Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbFirstName" runat="server" Text='<%# Eval("FirstName") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbFirstName" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Last Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbLastName" runat="server" Text='<%# Eval("LastName") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbLastName" runat="server" ControlToValidate="tbLastName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Configuration AuthToken
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfigurationAuthToken" runat="server" Text='<%# Eval("configurationAuthToken") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbconfigurationAuthToken" runat="server" Text='<%# Eval("configurationAuthToken") %>' Width="120" CssClass="txtbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbconfigurationAuthToken" runat="server" ControlToValidate="tbLastName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/edit.png" CancelImageUrl="~/Images/cancel_new.png"
                                        DeleteImageUrl="~/Images/delete.png" UpdateImageUrl="~/Images/save.png" ShowCancelButton="true" ShowDeleteButton="true"
                                        ShowEditButton="true" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                                    </asp:CommandField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgBtnUserDetail" runat="server" OnClick="imgBtnUserDetail_Click" OnClientClick="return ConfirmAction(this);" CommandArgument='<%# Eval("Id") %>' ImageUrl="~/Images/view_userDetail.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </td>
                </tr>

            </table>
        </div>
        <br />
    </div>
    <asp:Label ID="emptyListMsg" runat="server" Text="NA"></asp:Label>
</asp:Content>
