<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmCategory.aspx.cs" Inherits="AdminTool.frmCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:Label ID="lblHeader" runat="server" Text="Chosse the Any one Category" Font-Size="18"
                Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Button ID="ImgButtonIAssist" runat="server" Text="i-Assist" CssClass="btn" EnableViewState="false"
                            Width="125" CausesValidation="true" OnClick="ImgButtonIAssist_Click" />
                    </td>
                    <td colspan=3>
                    <td>
                        <asp:Button ID="ImgButtonITest" runat="server" Text="i-Test" CssClass="btn" EnableViewState="false"
                            Width="125" CausesValidation="true" OnClick="ImgButtonITest_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
