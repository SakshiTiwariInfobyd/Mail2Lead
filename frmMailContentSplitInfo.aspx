<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmMailContentSplitInfo.aspx.cs" Inherits="AdminTool.frmMailContentSplitInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .ListRowGrid
        {
            border-bottom: 10px #fff solid;
            background-color: #efefef;
            height: 50px;
            margin-left: 10px;
        }
        
        .ListRowGrid td
        {
            padding-left: 15px;
            vertical-align: middle;
        }
        
        .ListHeaderGrid
        {
            background-color: #BDC9D6;
            height: 50px;
        }
        
        .ListHeaderGrid th
        {
            padding-left: 15px;
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:ImageButton ID="ImageGoBack" ValidationGroup="text" runat="server" ImageUrl="~/Images/goBack.png"
                Style="height: 30px; width: 30px; vertical-align: middle; margin: 5px;" OnClientClick="if(!ValidateSearch()) return false;"
                OnClick="ImageGoBack_Click" align="left" />
            <asp:Label ID="lblHeader" runat="server" Text="Manage Mail Content Split Information"
                Font-Size="18" Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td align="left" colspan="2">
                        &nbsp;
                    </td>
                    <td align="right">
                        <div>
                            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
                                <asp:TextBox ID="txtSearchBox" placeholder="Search here" runat="server" Style="padding-left: 20px;
                                    padding-right: 20px; width: 200px; height: 25px; background-color: #e5eef6;"
                                    Width="150px" MaxLength="50" CssClass="form-control" BorderColor="#bbd3e9" />
                                <asp:ImageButton ID="btnSearch" ValidationGroup="text" runat="server" ImageUrl="~/Images/search_User.png"
                                    Style="height: 30px; width: 30px; vertical-align: middle; display: none;" OnClientClick="if(!ValidateSearch()) return false;"
                                    OnClick="btnSearch_Click" />
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
                            <asp:Button ID="ImgAddSplitInfo" runat="server" Text="Add New Info" CssClass="btn"
                                EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1"
                                OnClick="ImgAddNewSplitInfo_Click" BackColor="#3E75CD" ForeColor="White" />
                            <asp:Button runat="server" ID="ImgExportToExcel" Text="Export EXCEL" OnClick="ImgExportToExcel_Click"
                                CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1"
                                BackColor="#3E75CD" ForeColor="White" />
                            <asp:Button runat="server" ID="ImgExportToCSV" Text="Export CSV" OnClick="ImgExportToCSV_Click"
                                CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1"
                                BackColor="#3E75CD" ForeColor="White" />
                            <asp:Button runat="server" ID="ImgExportToPDF" Text="Export PDF" OnClick="ImgExportToPDF_Click"
                                CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1"
                                BackColor="#3E75CD" ForeColor="White" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div>
                            <asp:Panel ID="PnlAddNewSplitInfo" runat="server">
                                <asp:Label runat="server" Text="Select Lead Column : "></asp:Label>
                                <asp:DropDownList ID="MailToLeadColumnHeader" runat="server">
                                </asp:DropDownList>
                                <asp:TextBox ID="tbStartText" placeholder="Start Text To Split" ValidationGroup="text"
                                    runat="server" tyle="padding-left: 20px;  padding-right: 20px;" Style="background-color: #e5eef6;"
                                    Width="240px" onkeyup="OnsearchtextChanged();" MaxLength="50" CssClass="txtbox"
                                    BorderColor="#bbd3e9" />
                                <asp:TextBox ID="tbEndText" placeholder="End Text To Split" ValidationGroup="text"
                                    runat="server" tyle="padding-left: 20px;  padding-right: 20px;" Style="background-color: #e5eef6;"
                                    Width="240px" onkeyup="OnsearchtextChanged();" MaxLength="50" CssClass="txtbox"
                                    BorderColor="#bbd3e9" />
                                <asp:Button ID="imgBtnAddNew" runat="server" Text="Add" CssClass="btn" EnableViewState="false"
                                    Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="imgBtnAddNew_Click"
                                    BackColor="#3E75CD" ForeColor="White" />
                                <asp:Button ID="imgBtnCancel" runat="server" Text="Cancel" CssClass="btn" EnableViewState="false"
                                    Width="125" CausesValidation="true" ValidationGroup="Group1" OnClick="imgBtnCancel_Click"
                                    BackColor="#3E75CD" ForeColor="White" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Panel ID="PnlisValueSplitInfo" runat="server">
                            <asp:Label ID="lblIsValueSplit" runat="server" Text="Is Value Split"></asp:Label>
                            <asp:CheckBox ID="chkisValueSplit" runat="server" Checked="false" AutoPostBack="true"
                                EnableViewState="true" OnCheckedChanged="Check_Clicked"></asp:CheckBox>
                            <asp:DropDownList ID="dropdownIsValueSplit" runat="server" AutoPostBack="true" EnableViewState="true"
                                OnSelectedIndexChanged="dropdownIsValueSplit_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtValueToSplit" placeholder="Enter the char to split value" ValidationGroup="text"
                                runat="server" tyle="padding-left: 20px;  padding-right: 20px;" Style="background-color: #e5eef6;"
                                Width="240px" MaxLength="50" CssClass="txtbox" BorderColor="#bbd3e9" />
                            <asp:Label ID="lblIndex" runat="server" Text="Select Index :"></asp:Label>
                            <asp:DropDownList ID="dropdownValueIndex" runat="server">
                            </asp:DropDownList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                        <div id="GroupDetails" runat="server" width="100%" style="border: 1px solid #4090fd;">
                            <asp:GridView ID="GridSplitDetail" runat="server" Width="100%" AllowPaging="True"
                                OnPageIndexChanging="GridSplitDetail_PageIndexChanging" AutoGenerateColumns="False"
                                GridLines="None" DataKeyNames="Id" OnRowEditing="GridSplitDetail_RowEditing"
                                OnRowDeleting="GridSplitDetail_RowDeleting" OnRowCancelingEdit="GridSplitDetail_RowCancelingEdit"
                                OnRowUpdating="GridSplitDetail_RowUpdating" OnRowDataBound="GridSplitDetail_RowDataBound"
                                PageSize="20">
                                <HeaderStyle CssClass="ListHeaderGrid" HorizontalAlign="Left" BorderColor="#bbd3e9"
                                    BackColor="#e5eef6" />
                                <RowStyle CssClass="ListRowGrid" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" Height="40" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            S No.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hiddenSplitId" runat="server" Value='<%# Eval("id") %>'></asp:HiddenField>
                                            <asp:HiddenField ID="hiddenColumnHeaderId" runat="server" Value='<%# Eval("columnHeaderId") %>'>
                                            </asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Lead Column Header
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeadColumnHeader" runat="server" Text='<%# Eval("leadColumnHeader") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Mail Column Header
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMailColumnHeader" runat="server" Text='<%# Eval("mailColumnHeader") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Start Text
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartText" runat="server" Text='<%# Eval("startText") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbStartText" runat="server" Text='<%# Eval("startText") %>' Width="70%"
                                                    CssClass="txtbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbStartText" runat="server"
                                                    ControlToValidate="tbStartText" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            End Text
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndText" runat="server" Text='<%# Eval("endText") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbEndText" runat="server" Text='<%# Eval("endText") %>' Width="70%"
                                                    CssClass="txtbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEndText" runat="server" ControlToValidate="tbEndText"
                                                    ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Is Value Split
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsValueSplit1" runat="server" Text='<%# Eval("IsValueSplit") %>'
                                                Width="70%" CssClass="txtbox"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:CheckBox ID="tbIsValueSplit1" runat="server" Checked="false" Width="70%" CssClass="txtbox">
                                                </asp:CheckBox>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Split Type
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsValueSplit" runat="server" Text='<%# Eval("SplitType") %>' Width="70%"
                                                CssClass="txtbox"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:DropDownList ID="editDropdownSplitType" runat="server" EnableViewState="true">
                                                    <asp:ListItem Text="Space"></asp:ListItem>
                                                    <asp:ListItem Text="NewLine"></asp:ListItem>
                                                    <asp:ListItem Text="Other"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Split Value
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSplitValueText" runat="server" Text='<%# Eval("splitValueText") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbSplitValueText1" runat="server" Text='<%# Eval("splitValueText") %>'
                                                    Width="70%" CssClass="txtbox"></asp:TextBox>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Split Index
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="dropdownSplitIndex" runat="server" Text='<%# Eval("SplitIndex") %>'
                                                Width="70%" CssClass="txtbox"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:DropDownList ID="editDropdownSplitIndex" runat="server">
                                                    <asp:ListItem Text="0"></asp:ListItem>
                                                    <asp:ListItem Text="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/edit.png" CancelImageUrl="~/Images/cancel_new.png"
                                        DeleteImageUrl="~/Images/delete.png" UpdateImageUrl="~/Images/save.png" ShowCancelButton="true"
                                        ShowDeleteButton="true" ShowEditButton="true" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Right"
                                        HeaderText="Action">
                                        <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                                    </asp:CommandField>
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
