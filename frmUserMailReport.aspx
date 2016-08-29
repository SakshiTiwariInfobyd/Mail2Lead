<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUserMailReport.aspx.cs" Inherits="AdminTool.frmUserMailReport" %>

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
                            <asp:GridView ID="GridUserMailReport" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="true" GridLines="None" DataKeyNames="Id">
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
