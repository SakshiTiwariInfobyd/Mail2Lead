﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmViewSubjectInfo.aspx.cs" Inherits="AdminTool.frmViewSubjectInfo" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:Label ID="lblHeader" runat="server" Text="Manage Subjects Information" Font-Size="18" Font-Names="Forum"></asp:Label>
        </div>

        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td align="left" colspan="2">
                        <asp:ImageButton ID="ImageGoBack" ValidationGroup="text" runat="server" ImageUrl="~/Images/goBack.png" Style="height: 30px; width: 30px; vertical-align: middle;" OnClientClick="if(!ValidateSearch()) return false;" OnClick="ImageGoBack_Click" />
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
                            <asp:Button ID="ImgAddSubject" runat="server" Text="Add New Subject" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="ImgAddSubject_Click" />
                            <asp:Button runat="server" ID="ImgExportToExcel" Text="Export EXCEL" OnClick="ImgExportToExcel_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                            <asp:Button runat="server" ID="ImgExportToCSV" Text="Export CSV" OnClick="ImgExportToCSV_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                            <asp:Button runat="server" ID="ImgExportToPDF" Text="Export PDF" OnClick="ImgExportToPDF_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div>
                            <asp:Panel ID="AddNewSubject" runat="server">
                                <asp:TextBox ID="tbNewSubjectLine" placeholder="Add New Subject Info" ValidationGroup="text" runat="server" tyle="padding-left: 20px;  padding-right: 20px;" Style="width: 30%; height: 25px;" Width="150px" onkeyup="OnsearchtextChanged();" MaxLength="50" CssClass="txtbox" />
                                <asp:Button ID="imgBtnNewSubjectLine" runat="server" Text="Add" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="imgBtnNewSubjectLine_Click" />
                                <asp:Button ID="imgBtnNewSubjectLineCancel" runat="server" Text="Cancel" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="imgBtnNewSubjectLineCancel_Click" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                        <div id="GroupDetails" runat="server" width="100%" style="border: 1px solid #4090fd;">
                            <asp:GridView ID="GridSubjectDetail" runat="server" Width="100%" AllowPaging="True" OnPageIndexChanging="GridSubjectDetail_PageIndexChanging" AutoGenerateColumns="False" GridLines="None" DataKeyNames="Id" OnRowEditing="GridSubjectDetail_RowEditing"
                                OnRowDeleting="GridSubjectDetail_RowDeleting" OnRowCancelingEdit="GridSubjectDetail_RowCancelingEdit" OnRowUpdating="GridSubjectDetail_RowUpdating"
                                OnRowDataBound="GridSubjectDetail_RowDataBound">
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
                                            <asp:HiddenField ID="hiddenSubjectId" runat="server" Value='<%# Eval("id") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Subject Line
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectLine" runat="server" Text='<%# Eval("subjectLine") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbSubjectLine" runat="server" Text='<%# Eval("subjectLine") %>' Width="70%" CssClass="txtbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEmailId" runat="server" ControlToValidate="tbSubjectLine" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                            <asp:ImageButton ID="imgBtnSubjectDetail" runat="server" OnClick="imgBtnSubjectDetail_Click" OnClientClick="return ConfirmAction(this);" CommandArgument='<%# Eval("Id") %>' ImageUrl="~/Images/view_userDetail.png" />
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
</asp:Content>
